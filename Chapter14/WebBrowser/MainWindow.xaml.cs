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

    public async void InitializeAsync() {
        await WebView.EnsureCoreWebView2Async(); //非同期にして初期化

        WebView.CoreWebView2.NavigationStarting += CoreWebView2_NavigationStaring;
        WebView.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;

    }

    //読み込みを開始したらプログレスバーを表示
    private void CoreWebView2_NavigationStaring(object? sender, CoreWebView2NavigationStartingEventArgs e) {
        LoadingBar.Visibility = Visibility.Visible;
        LoadingBar.IsIndeterminate = true;
    }

    //読み込みが終了したらプログレスバーを非表示
    private void CoreWebView2_NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e) {
        LoadingBar.Visibility = Visibility.Collapsed;
        LoadingBar.IsIndeterminate = true;
    }

    private void BackButton_Click(object sender, RoutedEventArgs e) {
        if (WebView.CanGoBack) {
            WebView.GoBack();
        }
    }

    private void FowardButton_Click(object sender, RoutedEventArgs e) {
        if (WebView.CanGoForward) {
            WebView.GoForward();
        }
    }

    private void GoButton_Click(object sender, RoutedEventArgs e) {
        string url = AddressBar.Text;
        if (string.IsNullOrWhiteSpace(url)) return;
        WebView.Source = new Uri(url);
    }


}