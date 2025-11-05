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
using System.IO;
using Microsoft.Win32;

namespace Exercise01WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();
    }

    // ボタンクリック時に非同期でテキストファイルを読み込む
    private async void Button_Click(object sender, RoutedEventArgs e) {
        TextBox.Text = await TextReaderSample.ReadTextAsync("吾輩は猫である.txt");
    }

}

static class TextReaderSample {
    public static async Task<string> ReadTextAsync(string filePath) {
        var sb = new StringBuilder();
        var sr = new StreamReader(filePath);
        while (!sr.EndOfStream) {
            var line = await sr.ReadLineAsync();
            sb.AppendLine(line);
            Thread.Sleep(2);
        }
        return sb.ToString();
    }
}
    