using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace TenkiApp {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        // 住所から緯度・経度を取得し、天気情報を表示する処理
        private async void GetWeatherButton_Click(object sender, RoutedEventArgs e) {
            string prefecture = prefectureTextBox.Text.Trim();
            string city = cityTextBox.Text.Trim();

            if (string.IsNullOrEmpty(prefecture) || string.IsNullOrEmpty(city)) {
                MessageBox.Show("都道府県と市町村を入力してください。");
                return;
            }

            string fullAddress = prefecture + " " + city;

            // 住所から緯度・経度を取得
            var coordinates = await GetCoordinatesAsync(fullAddress);
            if (coordinates == null) {
                MessageBox.Show("住所から緯度経度を取得できませんでした。");
                return;
            }

            // 緯度・経度を使って天気予報データを取得
            var weatherForecast = await GetWeatherDataAsync(coordinates.Value.Latitude, coordinates.Value.Longitude);
            if (weatherForecast == null) {
                MessageBox.Show("天気予報の取得に失敗しました。");
                return;
            }

            // 天気情報をUIに表示
            DisplayWeatherData(weatherForecast);
        }

        // 住所から緯度・経度を取得する（OpenCage Geocoderを使用）
        private async Task<(double Latitude, double Longitude)?> GetCoordinatesAsync(string address) {
            try {
                var client = new HttpClient();
                string apiKey = "221ae854797f4b26aca04eaf62eceaf1";  // OpenCage APIキーを入力
                string requestUrl = $"https://api.opencagedata.com/geocode/v1/json?q={Uri.EscapeDataString(address)}&key={apiKey}";

                var response = await client.GetStringAsync(requestUrl);
                var jsonDoc = JsonDocument.Parse(response);
                var root = jsonDoc.RootElement;

                if (root.GetProperty("results").GetArrayLength() > 0) {
                    double latitude = root.GetProperty("results")[0].GetProperty("geometry").GetProperty("lat").GetDouble();
                    double longitude = root.GetProperty("results")[0].GetProperty("geometry").GetProperty("lng").GetDouble();
                    return (latitude, longitude);
                }
                return null;
            }
            catch (Exception ex) {
                MessageBox.Show($"住所から緯度経度を取得できませんでした: {ex.Message}");
                return null;
            }
        }

        // 緯度・経度を使って7日間の天気予報を取得（Open-Meteo API）
        private async Task<WeatherForecastResponse> GetWeatherDataAsync(double latitude, double longitude) {
            try {
                var client = new HttpClient();
                string requestUrl = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&daily=temperature_2m_max,temperature_2m_min,precipitation_sum&timezone=Asia%2FTokyo";

                var response = await client.GetStringAsync(requestUrl);
                var jsonDoc = JsonDocument.Parse(response);
                var root = jsonDoc.RootElement;

                var forecastData = new WeatherForecastResponse {
                    daily = new DailyWeatherData {
                        temperature_2m_max = root.GetProperty("daily").GetProperty("temperature_2m_max").EnumerateArray().Select(e => e.GetDouble()).ToList(),
                        temperature_2m_min = root.GetProperty("daily").GetProperty("temperature_2m_min").EnumerateArray().Select(e => e.GetDouble()).ToList(),
                        precipitation_sum = root.GetProperty("daily").GetProperty("precipitation_sum").EnumerateArray().Select(e => e.GetDouble()).ToList(),
                    }
                };

                return forecastData;
            }
            catch (Exception ex) {
                MessageBox.Show($"天気情報の取得に失敗しました: {ex.Message}");
                return null;
            }
        }

        // 天気予報情報をUIに表示
        private void DisplayWeatherData(WeatherForecastResponse weatherForecast) {
            if (weatherForecast != null && weatherForecast.daily != null) {
                ForecastPanel.Children.Clear();  // 以前の予報をクリア

                for (int i = 0; i < 7; i++) {
                    var dayPanel = new StackPanel {
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center
                    };

                    var dateText = new TextBlock {
                        Text = DateTime.Now.AddDays(i).ToString("MM/dd"),
                        HorizontalAlignment = HorizontalAlignment.Center
                    };
                    dayPanel.Children.Add(dateText);

                    var tempMaxText = new TextBlock {
                        Text = $"最高気温: {weatherForecast.daily.temperature_2m_max[i]} ℃",
                        HorizontalAlignment = HorizontalAlignment.Center
                    };
                    dayPanel.Children.Add(tempMaxText);

                    var tempMinText = new TextBlock {
                        Text = $"最低気温: {weatherForecast.daily.temperature_2m_min[i]} ℃",
                        HorizontalAlignment = HorizontalAlignment.Center
                    };
                    dayPanel.Children.Add(tempMinText);

                    var precipitationText = new TextBlock {
                        Text = $"降水量: {weatherForecast.daily.precipitation_sum[i]} mm",
                        HorizontalAlignment = HorizontalAlignment.Center
                    };
                    dayPanel.Children.Add(precipitationText);

                    ForecastPanel.Children.Add(dayPanel);
                }
            } else {
                MessageBox.Show("天気予報の表示に失敗しました。");
            }
        }
    }

    // Open-Meteo APIのレスポンス用クラス
    public class WeatherForecastResponse {
        public DailyWeatherData daily { get; set; }
    }

    public class DailyWeatherData {
        public List<double> temperature_2m_max { get; set; }
        public List<double> temperature_2m_min { get; set; }
        public List<double> precipitation_sum { get; set; }
    }
}