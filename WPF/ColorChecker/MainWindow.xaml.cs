using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ColorChecker {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            DataContext = GetColorList();
        }

        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name }).ToArray();
        }

        //全てのスライダーから呼ばれるイベントハンドラ
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            int r = (int)rSlider.Value;
            int g = (int)gSlider.Value;
            int b = (int)bSlider.Value;

            colorArea.Background = new SolidColorBrush(Color.FromRgb((byte)r, (byte)g, (byte)b));
        }



        private void stockButton_Click(object sender, RoutedEventArgs e) {
            Color currentColor = Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value);
            string name;

            if (colorSelectComboBox.SelectedItem is MyColor selectedColor
                && selectedColor.Color == currentColor) {
                name = selectedColor.Name;
            } else {
                name = $"R:{currentColor.R * 100 / 255} G:{currentColor.G * 100 / 255} B:{currentColor.B * 100 / 255}";
            }

            // すでに同じ色がリストに存在するかをチェック
            foreach (MyColor item in colorListBox.Items) {
                if (item.Color == currentColor) {
                    MessageBox.Show("同じ色があります", "情報", MessageBoxButton.OK, MessageBoxImage.Information);
                    return; // 追加せずに終了
                }
            }

            var myColor = new MyColor { Color = currentColor, Name = name };
            colorListBox.Items.Add(myColor);
        }


        private void colorSelectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var comboSelectMyColor = (MyColor)((ComboBox)sender).SelectedItem;


            setSliderValue(comboSelectMyColor.Color);
        }
        private void setSliderValue(Color color) {
            rSlider.Value = color.R;
            gSlider.Value = color.G;
            bSlider.Value = color.B;
        }


        private void stockList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (colorListBox.SelectedItem is MyColor selectedColor) {
                var color = selectedColor.Color;
                rSlider.Value = color.R;
                gSlider.Value = color.G;
                bSlider.Value = color.B;
            }
        }

    }
}






