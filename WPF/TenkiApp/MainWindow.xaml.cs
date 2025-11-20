using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TenkiApp {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private const string GeocodeApiUrl = "https://maps.googleapis.com/maps/api/geocode/json?address={0}&key=YOUR_GOOGLE_API_KEY";
        private const string WeatherApiUrl =
            "https://api.open-meteo.com/v1/forecast?latitude={0}&longitude={1}" +
            "&current=temperature_2m,wind_speed_10m,relative_humidity_2m,weathercode" +
            "&daily=temperature_2m_max,temperature_2m_min,precipitation_probability_max,weathercode" +
            "&timezone=Asia/Tokyo";

        public MainWindow() {
            InitializeComponent();
        }

        private async void GetWeatherButton_Click(object sender, RoutedEventArgs e) {
            string city = tosiTextBox.Text.Trim();
            if (string.IsNullOrEmpty(city)) {
                MessageBox.Show("都市名を入力してください。");
                return;
            }

            var coordinates = await GetCoordinatesAsync(city);
            if (coordinates == null) {
                MessageBox.Show("住所から緯度経度を取得できませんでした。");
                return;
            }

            var weather = await GetWeatherDataAsync(coordinates.Value.Latitude, coordinates.Value.Longitude);
            if (weather == null) {
                MessageBox.Show("天気情報の取得に失敗しました。");
                return;
            }

            // 現在の天気表示
            TemperatureText.Text = $"現在の気温：{weather.current.temperature_2m} ℃";
            WindSpeedText.Text = $"風速：{weather.current.wind_speed_10m} m/s";
            HumidityText.Text = $"湿度：{weather.current.relative_humidity_2m} ％";
            TimeText.Text = $"取得時刻：{weather.current.time}";
            WeatherIcon.Text = GetJapaneseWeatherSymbol(weather.current.weathercode);

            // 未来予報表示
            ForecastPanel.Children.Clear();
            for (int i = 0; i < weather.daily.Length; i++) {
                var day = weather.daily[i];
                var dayPanel = new StackPanel {
                    Width = 80,
                    Margin = new Thickness(5),
                    HorizontalAlignment = HorizontalAlignment.Center
                };

                // 日付
                dayPanel.Children.Add(new TextBlock {
                    Text = day.date,
                    FontSize = 12,
                    HorizontalAlignment = HorizontalAlignment.Center
                });

                // 天気アイコン（絵文字）
                dayPanel.Children.Add(new TextBlock {
                    Text = GetJapaneseWeatherSymbol(day.weathercode),
                    FontSize = 32,
                    HorizontalAlignment = HorizontalAlignment.Center
                });

                // 気温
                dayPanel.Children.Add(new TextBlock {
                    Text = $"↑{day.temperature_2m_max}℃",
                    FontSize = 12,
                    HorizontalAlignment = HorizontalAlignment.Center
                });
                dayPanel.Children.Add(new TextBlock {
                    Text = $"↓{day.temperature_2m_min}℃",
                    FontSize = 12,
                    HorizontalAlignment = HorizontalAlignment.Center
                });

                // 降水確率
                dayPanel.Children.Add(new TextBlock {
                    Text = $"☔ {day.precipitation_probability_max}％",
                    FontSize = 12,
                    HorizontalAlignment = HorizontalAlignment.Center
                });

                ForecastPanel.Children.Add(dayPanel);
            }
        }

        private string GetJapaneseWeatherSymbol(int weatherCode) {
            return weatherCode switch {
                0 => "☀",   // 晴れ
                1 => "⛅",   // 一部晴れ
                2 => "☁",   // 曇り
                3 => "🌧",   // 雨
                4 => "⛈",   // 雷雨
                5 => "❄",   // 雪
                _ => "？",   // 不明
            };
        }

        private async Task<(double Latitude, double Longitude)?> GetCoordinatesAsync(string city) {
            using var http = new HttpClient();
            try {
                var response = await http.GetFromJsonAsync<GeocodingResponse>(string.Format(GeocodeApiUrl, city));
                var location = response?.Results?[0]?.Geometry?.Location;
                return location != null ? (location.Lat, location.Lng) : null;
            }
            catch { return null; }
        }

        private async Task<WeatherResponse> GetWeatherDataAsync(double lat, double lng) {
            using var http = new HttpClient();
            try {
                return await http.GetFromJsonAsync<WeatherResponse>(string.Format(WeatherApiUrl, lat, lng));
            }
            catch { return null; }
        }
    }
}
}