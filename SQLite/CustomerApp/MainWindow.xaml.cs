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
        UpdateSaveButtonState();
        UpdateUpdateButtonState();
    }

    private void UpdateUpdateButtonState() {
        var selected = PersonListView.SelectedItem as Customer;
        if (selected == null) {
            UpdateButton.IsEnabled = false;
            return;
        }

        bool textChanged =
            NameTextBox.Text != selected.Name ||
            PhoneTextBox.Text != selected.Phone ||
            AddressTextBox.Text != selected.Address;

        bool imageChanged =
       (_selectedImageBytes != null && !selected.Picture.SequenceEqual(_selectedImageBytes)) ||
       (selected.Picture == null && _selectedImageBytes != null);

        UpdateButton.IsEnabled = textChanged || imageChanged;

    }

    private void UpdateSaveButtonState() {
        bool hasText =
            !string.IsNullOrWhiteSpace(NameTextBox.Text) ||
            !string.IsNullOrWhiteSpace(PhoneTextBox.Text) ||
            !string.IsNullOrWhiteSpace(AddressTextBox.Text);

        // 既存データと重複しているかチェック
        bool isDuplicate = _customer.Any(c =>
            c.Name == NameTextBox.Text &&
            c.Phone == PhoneTextBox.Text &&
            c.Address == AddressTextBox.Text &&
            (
                // 両方とも画像なし
                (c.Picture == null && _selectedImageBytes == null) ||
                // 両方とも画像ありで中身が同じ
                (c.Picture != null && _selectedImageBytes != null && c.Picture.SequenceEqual(_selectedImageBytes))
            )
        );

        // 条件：
        // ① 何か入力がある or 画像がある
        // ② 既存データと完全一致していない
        SaveButton.IsEnabled = (hasText || _selectedImageBytes != null) && !isDuplicate;
    }



    private void UpdateButton_Click(object sender, RoutedEventArgs e) {

        var Selecteditem = PersonListView.SelectedItem as Customer;
        if (Selecteditem is null) return;

        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();

            var customer = new Customer() {
                Id = (Selecteditem).Id,
                Name = NameTextBox.Text,
                Phone = PhoneTextBox.Text,
                Address = AddressTextBox.Text,
                Picture = _selectedImageBytes
            };

            connection.Update(customer);

            ReadDatabase();
            PersonListView.ItemsSource = _customer;
        }

    }
    private void SaveButton_Click(object sender, RoutedEventArgs e) {
        var customer = new Customer() {
            Name = NameTextBox.Text,
            Phone = PhoneTextBox.Text,
            Address = AddressTextBox.Text,
            Picture = _selectedImageBytes
        };

        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();
            connection.Insert(customer);
        }

        ReadDatabase();
        PersonListView.ItemsSource = _customer;

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

        UpdateUpdateButtonState();


        SelectedImage.Source = ByteArrayToImage(Selecteditem?.Picture);

    }


    private void PictureButton_Click(object sender, RoutedEventArgs e) {
        var dialog = new Microsoft.Win32.OpenFileDialog {
            Filter = "画像ファイル (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg"
        };

        if (dialog.ShowDialog() ?? false) {
            _selectedImageBytes = File.ReadAllBytes(dialog.FileName);
            SelectedImage.Source = ByteArrayToImage(_selectedImageBytes);
            UpdateSaveButtonState();
            UpdateUpdateButtonState();

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

}