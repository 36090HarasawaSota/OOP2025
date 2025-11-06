using Microsoft.Web.WebView2.Core;
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

namespace WebBrowser;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow() {
        InitializeComponent();
        InitializeAsync();


    }

    private async void InitializeAsync() {
        try {
            await WebView.EnsureCoreWebView2Async(null);
            WebView.Source = new Uri("https://www.yahoo.co.jp/");
        }
        catch (Exception ex) {
            MessageBox.Show("初期化エラー: " + ex.Message);
        }
    }




    private void BackButton_Click(object sender, RoutedEventArgs e) {

    }

    private void FowardButton_Click(object sender, RoutedEventArgs e) {

    }

    private void GoButton_Click(object sender, RoutedEventArgs e) {
        WebView.Source = new Uri(AddressBar.Text);
    }


}