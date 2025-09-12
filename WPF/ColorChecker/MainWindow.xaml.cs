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

namespace ColorChecker{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window{

        MyColor curentColor;

        public MainWindow() {
            InitializeComponent();
            DataContext = GetColorList(); 
        }


        /// すべての色を取得するメソッド
        /// </summary>
        /// <returns></returns>
        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name }).ToArray();
        }

        //すべてのスライダーから呼ばれるイベントハンドラー
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
             curentColor = new MyColor { Color = Color.FromRgb((byte)Math.Round(rSlider.Value), (byte)Math.Round(gSlider.Value), (byte)Math.Round(bSlider.Value)),
                Name = ((MyColor[])DataContext).Where(c => 
                                                     c.Color.R == (byte)(rSlider.Value)
                                                  && c.Color.G == (byte)(gSlider.Value)
                                                  && c.Color.B == (byte)(bSlider.Value)).Select(x => x.Name).FirstOrDefault(),
            };

            colorArea.Background = new SolidColorBrush(curentColor.Color);
            colorSelectComboBox.Text = curentColor.Name;

        }

        private void stockButton_Click(object sender, RoutedEventArgs e) {

            foreach (MyColor item in stockList.Items) {

                if (item.Color.R == (byte)rSlider.Value &&
                    item.Color.G == (byte)gSlider.Value &&
                    item.Color.B == (byte)bSlider.Value &&
                    item.Name == colorSelectComboBox.Text){

                    MessageBox.Show("既に登録済みです");
                    return;
                }


            } 
                stockList.Items.Insert(0, curentColor);

        }


        private void stockList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (stockList.SelectedItem is MyColor selectedColor) {
                // 背景色を変更
                colorArea.Background = new SolidColorBrush(selectedColor.Color);
                getSliderValue(selectedColor.Color);
                colorSelectComboBox.Text = selectedColor.Name;
            } 
        }


        private void colorSelectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            
                var comboBox = (ComboBox)sender;

                if (comboBox.SelectedItem is MyColor comboSelectMyColor) {
                    getSliderValue(comboSelectMyColor.Color);
                    curentColor = comboSelectMyColor;
                }
            }


        private void getSliderValue(Color color) {
            rSlider.Value = color.R;
            gSlider.Value = color.G;
            bSlider.Value = color.B;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            colorSelectComboBox.SelectedIndex = 7;
        }
    }
}
