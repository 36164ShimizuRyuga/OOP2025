using CustomerApp.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CustomerApp;

public partial class MainWindow : Window {
    private List<Customer> _customer = new List<Customer>();
    private byte[] _previewImageData; // 画像保持用

    public MainWindow() {
        InitializeComponent();
        ReadDatabase();
        CustomerListView.ItemsSource = _customer;
    }

    public void ReadDatabase() {
        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();
            _customer = connection.Table<Customer>().ToList();
        }
    }

    private void PictureButton_Click(object sender, RoutedEventArgs e) {
        var openFileDialog = new Microsoft.Win32.OpenFileDialog();
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
        if (openFileDialog.ShowDialog() == true) {
            string imagePath = openFileDialog.FileName;
            byte[] imageData = ConvertImageToByteArray(imagePath);

            _previewImageData = imageData;
            PreviewImage.Source = ConvertByteArrayToImage(imageData);
        }
    }

    private byte[] ConvertImageToByteArray(string imagePath) {
        try {
            return File.ReadAllBytes(imagePath);
        }
        catch (Exception ex) {
            MessageBox.Show($"画像の読み込みに失敗しました: {ex.Message}");
            return null;
        }
    }

    private BitmapImage ConvertByteArrayToImage(byte[] imageData) {
        if (imageData == null || imageData.Length == 0) return null;
        using (var stream = new MemoryStream(imageData)) {
            var image = new BitmapImage();
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.StreamSource = stream;
            image.EndInit();
            return image;
        }
    }

    private void saveButton_Click(object sender, RoutedEventArgs e) {
        var customer = new Customer() {
            Name = NameTextBox.Text,
            Phone = PhoneTextBox.Text,
            Address = AddressTextBox.Text,
            Picture = _previewImageData
        };

        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();
            connection.Insert(customer);
        }

        ReadDatabase();
        CustomerListView.ItemsSource = _customer;
    }

    private void deleteButton_Click(object sender, RoutedEventArgs e) {
        var item = CustomerListView.SelectedItem as Customer;
        if (item == null) {
            MessageBox.Show("行を選択してください");
            return;
        }
        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();
            connection.Delete(item);
        }
        ReadDatabase();
        CustomerListView.ItemsSource = _customer;
    }

    private void updateButton_Click(object sender, RoutedEventArgs e) {
        var selectedCustomer = CustomerListView.SelectedItem as Customer;
        if (selectedCustomer == null) {
            MessageBox.Show("更新する顧客を選択してください");
            return;
        }

        selectedCustomer.Name = NameTextBox.Text;
        selectedCustomer.Phone = PhoneTextBox.Text;
        selectedCustomer.Address = AddressTextBox.Text;
        selectedCustomer.Picture = _previewImageData;

        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();
            connection.Update(selectedCustomer);
        }

        ReadDatabase();
        CustomerListView.ItemsSource = _customer;
    }

    private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
        var selectedCustomer = CustomerListView.SelectedItem as Customer;
        if (selectedCustomer == null) return;

        NameTextBox.Text = selectedCustomer.Name;
        PhoneTextBox.Text = selectedCustomer.Phone;
        AddressTextBox.Text = selectedCustomer.Address;
        PreviewImage.Source = ConvertByteArrayToImage(selectedCustomer.Picture);
        _previewImageData = selectedCustomer.Picture;
    }
}