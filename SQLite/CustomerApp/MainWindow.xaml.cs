using System.IO;
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
using System.Windows.Controls.Primitives;

namespace CustomerApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
    private List<Customer> _customer = new List<Customer>();
    private byte[] _selectedImageBytes = null;

    public MainWindow() {
        InitializeComponent();
        ReadDatabase();
        PersonListView.ItemsSource = _customer;
    }

    private void ReadDatabase() {
        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();
            _customer = connection.Table<Customer>().ToList();
        }
    }

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e) {
        SaveButtonState();
        UpdateButtonState();
    }

    private void UpdateButtonState() {
        var selected = PersonListView.SelectedItem as Customer;
        if (selected == null) {
            UpdateButton.IsEnabled = false;
            return;
        }

        bool isNameChanged = selected.Name != NameTextBox.Text;
        bool isPhoneChanged = selected.Phone != PhoneTextBox.Text;
        bool isAddressChanged = selected.Address != AddressTextBox.Text;

        bool isImageChanged = false;
        if (selected.Picture == null && _selectedImageBytes != null) {
            isImageChanged = true;
        } else if (selected.Picture != null && _selectedImageBytes == null) {
            isImageChanged = true;
        } else if (selected.Picture != null && _selectedImageBytes != null && !selected.Picture.SequenceEqual(_selectedImageBytes)) {
            isImageChanged = true;
        }

        bool isModified = isNameChanged || isPhoneChanged || isAddressChanged || isImageChanged;
        bool isDuplicate = IsDuplicateEntry(selected);

        UpdateButton.IsEnabled = isModified && !isDuplicate;
    }





    private void SaveButtonState() {
        bool hasText =
            !string.IsNullOrWhiteSpace(NameTextBox.Text) &&
            !string.IsNullOrWhiteSpace(PhoneTextBox.Text) &&
            !string.IsNullOrWhiteSpace(AddressTextBox.Text);

        bool isDuplicate = IsDuplicateEntry();

        SaveButton.IsEnabled = hasText && !isDuplicate;
    }




    private void UpdateButton_Click(object sender, RoutedEventArgs e) {
        var selected = PersonListView.SelectedItem as Customer;
        if (selected == null) return;

        if (IsDuplicateEntry(selected)) {
            return;
        }

        selected.Name = NameTextBox.Text;
        selected.Phone = PhoneTextBox.Text;
        selected.Address = AddressTextBox.Text;
        selected.Picture = _selectedImageBytes;

        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();
            connection.Update(selected);
        }

        ClearForm();
        ReadDatabase();
        PersonListView.ItemsSource = _customer;
        SaveButtonState();
        UpdateButtonState();
    }


    private void SaveButton_Click(object sender, RoutedEventArgs e) {
        if (IsDuplicateEntry()) {
            return;
        }

        var customer = new Customer {
            Name = NameTextBox.Text,
            Phone = PhoneTextBox.Text,
            Address = AddressTextBox.Text,
            Picture = _selectedImageBytes
        };

        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();
            connection.Insert(customer);
        }

        ClearForm();
        ReadDatabase();
        PersonListView.ItemsSource = _customer;
        SaveButtonState();
        UpdateButtonState();
    }


    private void DeleteButton_Click(object sender, RoutedEventArgs e) {
        var item = PersonListView.SelectedItem as Customer;

        //データベース接続
        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();
            connection.Delete(item);                //データベースから選択されているレコードを削除
            ReadDatabase();
            PersonListView.ItemsSource = _customer;
        }

        NameTextBox.Text = string.Empty;
        PhoneTextBox.Text = string.Empty;
        AddressTextBox.Text = string.Empty;
        SelectedImage.Source = null;
        _selectedImageBytes = null;

        SaveButtonState();
        UpdateButtonState();

    }

    private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e) {
        var filterList = _customer.Where(x => x.Name.Contains(SearchTextBox.Text));

        if (filterList is null) {
            return;
        }
        PersonListView.ItemsSource = filterList;
    }

    private void PersonListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
        var Selecteditem = PersonListView.SelectedItem as Customer;

        var selected = PersonListView.SelectedItem as Customer;
        DeleteButton.IsEnabled = selected != null;

        if (selected != null) {
            NameTextBox.Text = selected.Name;
            PhoneTextBox.Text = selected.Phone;
            AddressTextBox.Text = selected.Address;
            SelectedImage.Source = ByteArrayToImage(selected.Picture);
            _selectedImageBytes = selected.Picture;
        }

        UpdateButtonState();
        SaveButtonState();

        SelectedImage.Source = ByteArrayToImage(Selecteditem?.Picture);

    }


    private void PictureButton_Click(object sender, RoutedEventArgs e) {
        var dialog = new Microsoft.Win32.OpenFileDialog {
            Filter = "画像ファイル (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg"
        };

        if (dialog.ShowDialog() ?? false) {
            _selectedImageBytes = File.ReadAllBytes(dialog.FileName);
            SelectedImage.Source = ByteArrayToImage(_selectedImageBytes);
            SaveButtonState();
            UpdateButtonState();

        }
    }
        
    private BitmapImage ByteArrayToImage(byte[] bytes) {
        if (bytes == null || bytes.Length == 0) return null;
        using var stream = new MemoryStream(bytes);
        var image = new BitmapImage();
        image.BeginInit();
        image.CacheOption = BitmapCacheOption.OnLoad;
        image.StreamSource = stream;
        image.EndInit();
        return image;
    }

    private bool IsDuplicateEntry(Customer exclude = null) {
        return _customer.Any(c =>
            (exclude == null || c.Id != exclude.Id) &&
            c.Name == NameTextBox.Text &&
            c.Phone == PhoneTextBox.Text &&
            c.Address == AddressTextBox.Text &&
            (
                (c.Picture == null && _selectedImageBytes == null) ||
                (c.Picture != null && _selectedImageBytes != null && c.Picture.SequenceEqual(_selectedImageBytes))
            )
        );
    }

    private void ClearForm() {
        NameTextBox.Text = string.Empty;
        PhoneTextBox.Text = string.Empty;
        AddressTextBox.Text = string.Empty;
        SelectedImage.Source = null;
        _selectedImageBytes = null;
        PersonListView.SelectedItem = null;
    }



}