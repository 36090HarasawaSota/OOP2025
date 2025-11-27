using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using tenkiApp;

namespace TenkiApp {
    public partial class MainWindow : Window {

        private readonly string[] locationNames = {
            "東京", "大阪", "名古屋", "札幌", "福岡",
            "京都", "横浜", "神戸", "広島", "仙台",
            "川崎", "さいたま", "千葉", "静岡", "金沢",
            "長野", "那覇"
        };

        private readonly (double lat, double lon)[] coords = {
            (35.6895, 139.6917), // 東京
            (34.6937, 135.5023), // 大阪
            (35.1815, 136.9066), // 名古屋
            (43.0618, 141.3545), // 札幌
            (33.5902, 130.4017), // 福岡
            (35.0116, 135.7681), // 京都
            (35.4437, 139.6380), // 横浜
            (34.6901, 135.1955), // 神戸
            (34.3853, 132.4553), // 広島
            (38.2688, 140.8719), // 仙台
            (35.5300, 139.7000), // 川崎
            (35.8617, 139.6455), // さいたま
            (35.6074, 140.1065), // 千葉
            (34.9756, 138.3828), // 静岡
            (36.5613, 136.6562), // 金沢
            (36.6513, 138.1810), // 長野
            (26.2124, 127.6809)  // 那覇
        };

        private readonly Dictionary<string, string> cityMap = new Dictionary<string, string> {
            { "東京", "Tokyo" }, { "大阪", "Osaka" }, { "名古屋", "Nagoya" },
            { "札幌", "Sapporo" }, { "福岡", "Fukuoka" }, { "横浜", "Yokohama" },
            { "京都", "Kyoto" }, { "神戸", "Kobe" }, { "仙台", "Sendai" },
            { "広島", "Hiroshima" }, { "川崎", "Kawasaki" }, { "さいたま", "Saitama" },
            { "千葉", "Chiba" }, { "静岡", "Shizuoka" }, { "金沢", "Kanazawa" },
            { "長野", "Nagano" }, { "前橋市", "Maebashi" }, { "太田市", "Ota" },
            { "群馬県前橋市", "Maebashi" }, { "群馬県太田市", "Ota" }
        };

        private DateTime currentMonth = DateTime.Now;
        private List<WeatherItem> weatherItems = new List<WeatherItem>();

        public MainWindow() {
            InitializeComponent();
            LocationCombo.ItemsSource = locationNames;

            LocationCombo.Text = "太田市";
            GenerateCalendar();

            // 起動時に今日の天気を表示
            _ = ShowWeather(DateTime.Now.Day);

        }

        private void UpdateBackground(string weather) {
            Brush brush;
            switch (weather) {
                case "快晴":
                case "晴れ":
                    brush = new LinearGradientBrush(
                        Color.FromArgb(200, 180, 220, 255),
                        Color.FromArgb(200, 255, 255, 255),
                        new Point(0, 0), new Point(0, 1));
                    break;
                case "曇り":
                    brush = new LinearGradientBrush(
                        Color.FromArgb(180, 200, 200, 200),
                        Color.FromArgb(200, 240, 240, 240),
                        new Point(0, 0), new Point(0, 1));
                    break;
                case "雨":
                    brush = new LinearGradientBrush(
                        Color.FromArgb(180, 150, 180, 220),
                        Color.FromArgb(200, 230, 240, 255),
                        new Point(0, 0), new Point(0, 1));
                    break;
                case "雪":
                    brush = new LinearGradientBrush(
                        Color.FromArgb(180, 220, 230, 240),
                        Color.FromArgb(200, 255, 255, 255),
                        new Point(0, 0), new Point(0, 1));
                    break;
                default:
                    brush = new LinearGradientBrush(
                        Color.FromArgb(180, 180, 180, 180),
                        Color.FromArgb(200, 240, 240, 240),
                        new Point(0, 0), new Point(0, 1));
                    break;
            }
            MainWin.Background = brush;
            MainBorder.Background = brush;
        }

        private void LocationCombo_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            GenerateCalendar();
        }

        private void RefreshCalendar(object sender, RoutedEventArgs e) {
            GenerateCalendar();
        }

        private void PrevMonth(object sender, RoutedEventArgs e) {
            currentMonth = currentMonth.AddMonths(-1);
            GenerateCalendar();
        }

        private void NextMonth(object sender, RoutedEventArgs e) {
            currentMonth = currentMonth.AddMonths(1);
            GenerateCalendar();
        }

        // ★ 範囲外の日付を無効化
        private void GenerateCalendar() {
            CalendarGrid.Children.Clear();
            DateTime first = new DateTime(currentMonth.Year, currentMonth.Month, 1);
            int skip = (int)first.DayOfWeek;
            int days = DateTime.DaysInMonth(currentMonth.Year, currentMonth.Month);

            DateTime minDate = DateTime.Today;
            DateTime maxDate = DateTime.Today.AddMonths(1);

            for (int i = 0; i < skip; i++)
                CalendarGrid.Children.Add(new TextBlock());

            for (int d = 1; d <= days; d++) {
                DateTime currentDate = new DateTime(currentMonth.Year, currentMonth.Month, d);

                Button btn = new Button {
                    Content = d.ToString(),
                    Margin = new Thickness(2),
                    Background = Brushes.Black,
                    Foreground = Brushes.White
                };

                if (currentDate < minDate || currentDate > maxDate) {
                    btn.IsEnabled = false;
                    btn.Background = Brushes.Gray;
                } else {
                    int dayCopy = d;
                    btn.Click += async (_, __) => await ShowWeather(dayCopy);
                }

                CalendarGrid.Children.Add(btn);
            }

            MonthText.Text = $"{currentMonth:yyyy年MM月} - {LocationCombo.Text.Trim()}";
        }

        // 天気表示メソッド
        private async System.Threading.Tasks.Task ShowWeather(int day) {
            string place = LocationCombo.Text.Trim();

            if (cityMap.ContainsKey(place)) {
                place = cityMap[place];
            }

            double lat, lon;
            int index = Array.IndexOf(locationNames, place);
            if (index >= 0) {
                (lat, lon) = coords[index];
            } else {
                string geoUrl = $"https://geocoding-api.open-meteo.com/v1/search?name={Uri.EscapeDataString(place)}&count=1&country=JP";
                try {
                    using var http = new HttpClient();
                    var geo = await http.GetFromJsonAsync<GeocodeResponse>(geoUrl);
                    if (geo?.results == null || geo.results.Length == 0) {
                        weatherItems.Clear();
                        WeatherDataGrid.ItemsSource = null;
                        WeatherDataGrid.ItemsSource = weatherItems;
                        MessageBox.Show($"都市が見つかりません: {place}");
                        return;
                    }
                    lat = geo.results[0].latitude;
                    lon = geo.results[0].longitude;
                }
                catch {
                    weatherItems.Clear();
                    WeatherDataGrid.ItemsSource = null;
                    WeatherDataGrid.ItemsSource = weatherItems;
                    MessageBox.Show($"都市の座標取得に失敗: {place}");
                    return;
                }


            }

            DateTime selectedDate = new DateTime(currentMonth.Year, currentMonth.Month, day);
            MonthText.Text = $"{selectedDate:yyyy年MM月dd日} - {LocationCombo.Text.Trim()}";

            string url =
                $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&hourly=" +
                $"temperature_2m,wind_speed_10m,weathercode,precipitation_probability,precipitation&timezone=Asia/Tokyo";

            try {
                using var http = new HttpClient();
                var weather = await http.GetFromJsonAsync<WeatherResponse>(url);

                weatherItems.Clear();

                if (weather?.hourly != null) {
                    for (int i = 0; i < weather.hourly.time.Length; i++) {
                        DateTime t = DateTime.Parse(weather.hourly.time[i]);

                        if (t.Date == selectedDate.Date) {
                            string wText = WeatherCodeToText(weather.hourly.weathercode[i]);
                            double temp = weather.hourly.temperature_2m[i];
                            double wind = weather.hourly.wind_speed_10m[i];
                            int pop = weather.hourly.precipitation_probability[i];
                            double rain = weather.hourly.precipitation[i];

                            weatherItems.Add(new WeatherItem {
                                Time = t.ToString("HH:00"),
                                Weather = wText,
                                Temp = $"{temp}℃",
                                Wind = $"{wind} m/s",
                                Pop = $"{pop}%",
                                Rain = $"{rain} mm",
                            });
                        }
                    }
                }

                WeatherDataGrid.ItemsSource = null;
                WeatherDataGrid.ItemsSource = weatherItems;

                if (weatherItems.Count > 0) {
                    // 最初の時間帯の天気を背景に反映
                    UpdateBackground(weatherItems[0].Weather);
                }
                // 最初の時間帯の天気を背景に反映
                UpdateBackground(weatherItems[0].Weather);
            }
            catch (Exception ex) {
                weatherItems.Clear();
                WeatherDataGrid.ItemsSource = null;
                WeatherDataGrid.ItemsSource = weatherItems;
                MessageBox.Show($"天気データ取得失敗\n{ex.Message}");
            }

            WeatherDataGrid.ItemsSource = weatherItems;

            if (weatherItems.Count > 0) {
                UpdateBackground(weatherItems[0].Weather);
            }
        }

        // API レスポンス用クラス
        public class GeocodeResponse {
            public GeoResult[] results { get; set; }
        }

        public class GeoResult {
            public double latitude { get; set; }
            public double longitude { get; set; }
        }

        public class WeatherResponse {
            public Hourly hourly { get; set; }
        }

        public class Hourly {
            public string[] time { get; set; }
            public double[] temperature_2m { get; set; }
            public double[] wind_speed_10m { get; set; }
            public int[] weathercode { get; set; }
            public int[] precipitation_probability { get; set; }
            public double[] precipitation { get; set; }
        }

        // 天気コードを日本語に変換するメソッド
        private string WeatherCodeToText(int code) {
            return code switch {
                0 => "快晴",
                1 => "晴れ",
                2 => "薄曇り",
                3 => "曇り",
                45 or 48 => "霧",
                51 or 53 or 55 => "霧雨",
                61 or 63 or 65 => "雨",
                71 or 73 or 75 => "雪",
                80 or 81 or 82 => "にわか雨",
                85 or 86 => "にわか雪",
                _ => "不明"
            };
        }
    }
}





