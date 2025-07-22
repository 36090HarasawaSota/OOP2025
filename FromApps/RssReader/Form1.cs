using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace RssReader {
    public partial class Form1 : Form {
        Dictionary<string, string> urltitle = new Dictionary<string, string>();
        private List<ItemData> items;

        public Form1() {
            InitializeComponent();
        }

        private async void btRssGet_Click(object sender, EventArgs e) {

            using (var hc = new HttpClient()) {

                string xml = await hc.GetStringAsync(cburl.Text);
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
            btGoBack.Enabled = false;
            btGoFard.Enabled = false;

            cburl.Items.Add(cburl.Text);
        }



        private void lbTitles_SelectedIndexChanged(object sender, EventArgs e) {
            if (0 <= lbTitles.SelectedIndex) {
                wbRssLink.Source = new Uri(items[lbTitles.SelectedIndex].Link ?? "https://www.yahoo.co.jp");
            }
        }

        private void btGoFard_Click(object sender, EventArgs e) {
            wbRssLink.Source = new Uri(items[lbTitles.SelectedIndex + 1].Link);
            lbTitles.SelectedIndex++;
        }
        private void btGoBack_Click(object sender, EventArgs e) {
            wbRssLink.Source = new Uri(items[lbTitles.SelectedIndex - 1].Link);
            lbTitles.SelectedIndex--;
        }




        private void wbRssLink_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e) {
            btGoBack.Enabled = wbRssLink.CanGoBack;
            btGoFard.Enabled = wbRssLink.CanGoForward;
        }

        private void Registrgt_Click(object sender, EventArgs e) {
            cburl.Items.Add(tburl.Text);
           // urltitle.Add(tburl.Text,);

        }

    }
}
