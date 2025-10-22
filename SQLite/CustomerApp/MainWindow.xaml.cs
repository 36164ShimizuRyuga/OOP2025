using CustomerApp.Data;
using SQLite;
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

namespace CustomerApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
    private List<Customer> _customer = new List<Customer>();
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

    }

    private void saveButton_Click(object sender, RoutedEventArgs e) {
        var costomer = new Customer() {
            Name = NameTextBox.Text,
            Phone = PhoneTextBox.Text,
            Address= AddressTextBox.Text,
        };
        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>(); 
            connection.Insert(costomer);
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
            ReadDatabase();
            CustomerListView.ItemsSource = _customer;
        }
    }

    private void updateButton_Click(object sender, RoutedEventArgs e) {
        var selectedCustomer = CustomerListView.SelectedItem as Customer;
        if (selectedCustomer == null) return;

        // 選択中の顧客情報を更新
        selectedCustomer.Name = NameTextBox.Text;
        selectedCustomer.Phone = PhoneTextBox.Text;
        selectedCustomer.Address = AddressTextBox.Text;

        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();
            connection.Update(selectedCustomer);
        }

        ReadDatabase();
        CustomerListView.ItemsSource = null;   
        CustomerListView.ItemsSource = _customer;  
    }


    private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
        var selectedCustomer = CustomerListView.SelectedItem as Customer;
        if (selectedCustomer is null) return;
        NameTextBox.Text = selectedCustomer.Name;
        PhoneTextBox.Text = selectedCustomer.Phone;
        AddressTextBox.Text = selectedCustomer.Address;
    }

   
}