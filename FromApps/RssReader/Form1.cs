using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemData> items;

        public Form1() {
            InitializeComponent();
        }

        private async void btRssGet_Click(object sender, EventArgs e) {

            using (var hc = new HttpClient()) {

                string xml = await hc.GetStringAsync(tbUrl.Text);
                XDocument xdoc = XDocument.Parse(xml);

                //RSSを解析して必要な要素を取得
                items = xdoc.Root.Descendants("item")
                    .Select(x =>
                        new ItemData {
                            Title = (string?)x.Element("title"),
                            Link = (string?)x.Element("link"),
                        }).ToList();


                //リストボックスへタイトルを表示
                lbTitles.Items.Clear();
                items.ForEach(item => lbTitles.Items.Add(item.Title));

            }


        }



        private void lbTitles_SelectedIndexChanged(object sender, EventArgs e) {
                webView21.Source = new Uri(items[lbTitles.SelectedIndex].Link ?? "https://www.yahoo.co.jp") ;
        }

        private void nextbt_Click(object sender, EventArgs e) {
                webView21.Source = new Uri(items[lbTitles.SelectedIndex++].Link ?? "https://www.yahoo.co.jp");
                lbTitles.SelectedIndex++;
        }
        private void backbt_Click(object sender, EventArgs e) {
                webView21.Source = new Uri(items[lbTitles.SelectedIndex--].Link ?? "https://www.yahoo.co.jp");
                lbTitles.SelectedIndex--;
        }
    }
}
