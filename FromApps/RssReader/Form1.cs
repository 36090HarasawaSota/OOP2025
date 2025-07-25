using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemData> items;

        Dictionary<string, string> rssurldict = new Dictionary<string, string>() {
            {"主要","https://news.yahoo.co.jp/rss/topics/top-picks.xml"},
            {"国内","https://news.yahoo.co.jp/rss/topics/domestic.xml" },
            {"国際","https://news.yahoo.co.jp/rss/topics/world.xml" },
            {"経済","https://news.yahoo.co.jp/rss/topics/business.xml"},
            { "エンタメ","https://news.yahoo.co.jp/rss/topics/entertainment.xml"},
            { "スポーツ","https://news.yahoo.co.jp/rss/topics/sports.xml"},
            {"IT","https://news.yahoo.co.jp/rss/topics/it.xml" },
            { "科学","https://news.yahoo.co.jp/rss/topics/science.xml"},
            { "地域","https://news.yahoo.co.jp/rss/topics/local.xml"}
        };

        public Form1() {
            InitializeComponent();
        }

        private async void btRssGet_Click(object sender, EventArgs e) {

            using (var hc = new HttpClient()) {

                if (rssurldict.ContainsKey(cburl.Text)) {
                    string xml2 = await hc.GetStringAsync(rssurldict[cburl.Text]);
                    XDocument xdoc2 = XDocument.Parse(xml2);

                    //RSSを解析して必要な要素を取得
                    items = xdoc2.Root.Descendants("item")
                        .Select(x =>
                            new ItemData {
                                Title = (string?)x.Element("title"),
                                Link = (string?)x.Element("link"),
                            }).ToList();


                    //リストボックスへタイトルを表示
                    lbTitles.Items.Clear();
                    items.ForEach(item => lbTitles.Items.Add(item.Title));


                    btGoFard.Enabled = false;
                    btGoBack.Enabled = false;

                } else {

                    string xml = await hc.GetStringAsync(cburl.Text);
                    XDocument xdoc = XDocument.Parse(xml);

                    //RSSを解析して必要な要素を取得
                    items = xdoc.Root.Descendants("item")
                        .Select(x =>
                            new ItemData {
                                Title = (string?)x.Element("title"),
                                Link = (string?)x.Element("link"),
                            }).ToList();
                }

                //リストボックスへタイトルを表示
                lbTitles.Items.Clear();
                items.ForEach(item => lbTitles.Items.Add(item.Title));

            }
            btGoFard.Enabled = false;
            btGoBack.Enabled = false;


        }


        private void lbTitles_SelectedIndexChanged(object sender, EventArgs e) {
            if (0 <= lbTitles.SelectedIndex) {
                wbRssLink.Source = new Uri(items[lbTitles.SelectedIndex].Link ?? "https://www.yahoo.co.jp");
            }
        }

        private void btGoBack_Click(object sender, EventArgs e) {
            wbRssLink.GoBack();
            GoForWardBtEnablset();
        }
        private void btGoFard_Click(object sender, EventArgs e) {
            wbRssLink.GoForward();
            GoForWardBtEnablset();
        }

        private void wvRssLink_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e) {
            GoForWardBtEnablset();

        }

        private void GoForWardBtEnablset() {
            btGoFard.Enabled = wbRssLink.CanGoForward;
            btGoBack.Enabled = wbRssLink.CanGoBack;
        }


        private void Registrgt_Click(object sender, EventArgs e) {
            if (!Uri.IsWellFormedUriString(cburl.Text,UriKind.Absolute)) {
                MessageBox.Show("有効なURLではありません");
                return;
            }

            cburl.Items.Add(tburl.Text);
            rssurldict.Add(tburl.Text, cburl.Text);
            MessageBox.Show("お気に入り登録完了");
            tburl.Text = string.Empty;
        }

        private void Form1_Load(object sender, EventArgs e) {

            GoForWardBtEnablset();

            cburl.Items.Add("主要");
            cburl.Items.Add("国内");
            cburl.Items.Add("国際");
            cburl.Items.Add("経済");
            cburl.Items.Add("エンタメ");
            cburl.Items.Add("スポーツ");
            cburl.Items.Add("IT");
            cburl.Items.Add("科学");
            cburl.Items.Add("地域");

            //cburl.DataSource = rssurldict.Select(k => k.Key).ToList();
        }

        private void btremove_Click(object senSder, EventArgs e) {


            rssurldict.Remove(cburl.Text);
            cburl.Items.Remove(cburl.Text);
            cburl.Text = string.Empty;
            tburl.Text = string.Empty;
            lbTitles.Items.Clear();
            wbRssLink.Source = new Uri("about: blank");
            MessageBox.Show($"削除しました。");

        }

        //手順
        //�@交互に色を変更したいリストボックスのDrawModeプロパティを、OwnerDrawFixedに変更
        //�Aイベントから「DrawItem」をダブルクリック
        //�B以下のイベントハンドラが自動生成されたら中の処理をコピペ

        private void lbTitles_DrawItem(object sender, DrawItemEventArgs e) {
            var idx = e.Index;                                                      //描画対象の行
            if (idx == -1) return;                                                  //範囲外なら何もしない
            var sts = e.State;                                                      //セルの状態
            var fnt = e.Font;                                                       //フォント
            var _bnd = e.Bounds;                                                    //描画範囲(オリジナル)
            var bnd = new RectangleF(_bnd.X, _bnd.Y, _bnd.Width, _bnd.Height);     //描画範囲(描画用)
            var txt = (string)lbTitles.Items[idx];                                  //リストボックス内の文字
            var bsh = new SolidBrush(lbTitles.ForeColor);                           //文字色
            var sel = (DrawItemState.Selected == (sts & DrawItemState.Selected));   //選択行か
            var odd = (idx % 2 == 1);                                               //奇数行か
            var fore = Brushes.WhiteSmoke;                                         //偶数行の背景色
            var bak = Brushes.AliceBlue;                                           //奇数行の背景色

            e.DrawBackground();                                                     //背景描画

            //奇数項目の背景色を変える（選択行は除く）
            if (odd && !sel) {
                e.Graphics.FillRectangle(bak, bnd);
            } else if (!odd && !sel) {
                e.Graphics.FillRectangle(fore, bnd);
            }

            //文字を描画
            e.Graphics.DrawString(txt, fnt, bsh, bnd);
        }
    }
}
