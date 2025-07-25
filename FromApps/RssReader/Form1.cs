using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemData> items;

        Dictionary<string, string> rssurldict = new Dictionary<string, string>() {
            {"��v","https://news.yahoo.co.jp/rss/topics/top-picks.xml"},
            {"����","https://news.yahoo.co.jp/rss/topics/domestic.xml" },
            {"����","https://news.yahoo.co.jp/rss/topics/world.xml" },
            {"�o��","https://news.yahoo.co.jp/rss/topics/business.xml"},
            { "�G���^��","https://news.yahoo.co.jp/rss/topics/entertainment.xml"},
            { "�X�|�[�c","https://news.yahoo.co.jp/rss/topics/sports.xml"},
            {"IT","https://news.yahoo.co.jp/rss/topics/it.xml" },
            { "�Ȋw","https://news.yahoo.co.jp/rss/topics/science.xml"},
            { "�n��","https://news.yahoo.co.jp/rss/topics/local.xml"}
        };

        public Form1() {
            InitializeComponent();
        }

        private async void btRssGet_Click(object sender, EventArgs e) {

            using (var hc = new HttpClient()) {

                if (rssurldict.ContainsKey(cburl.Text)) {
                    string xml2 = await hc.GetStringAsync(rssurldict[cburl.Text]);
                    XDocument xdoc2 = XDocument.Parse(xml2);

                    //RSS����͂��ĕK�v�ȗv�f���擾
                    items = xdoc2.Root.Descendants("item")
                        .Select(x =>
                            new ItemData {
                                Title = (string?)x.Element("title"),
                                Link = (string?)x.Element("link"),
                            }).ToList();


                    //���X�g�{�b�N�X�փ^�C�g����\��
                    lbTitles.Items.Clear();
                    items.ForEach(item => lbTitles.Items.Add(item.Title));


                    btGoFard.Enabled = false;
                    btGoBack.Enabled = false;

                } else {

                    string xml = await hc.GetStringAsync(cburl.Text);
                    XDocument xdoc = XDocument.Parse(xml);

                    //RSS����͂��ĕK�v�ȗv�f���擾
                    items = xdoc.Root.Descendants("item")
                        .Select(x =>
                            new ItemData {
                                Title = (string?)x.Element("title"),
                                Link = (string?)x.Element("link"),
                            }).ToList();
                }

                //���X�g�{�b�N�X�փ^�C�g����\��
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
            cburl.Items.Add(tburl.Text);
            rssurldict.Add(tburl.Text, cburl.Text);

            MessageBox.Show("���C�ɓ���o�^����");

        }

        private void Form1_Load(object sender, EventArgs e) {

            GoForWardBtEnablset();

            cburl.Items.Add("��v");
            cburl.Items.Add("����");
            cburl.Items.Add("����");
            cburl.Items.Add("�o��");
            cburl.Items.Add("�G���^��");
            cburl.Items.Add("�X�|�[�c");
            cburl.Items.Add("IT");
            cburl.Items.Add("�Ȋw");
            cburl.Items.Add("�n��");

            //cburl.DataSource = rssurldict.Select(k => k.Key).ToList();
        }

        private void btremove_Click(object senSder, EventArgs e) {


            rssurldict.Remove(cburl.Text);     
            cburl.Items.Remove(cburl.Text);
            cburl.Text = string.Empty;
            tburl.Text = string.Empty;
            lbTitles.Items.Clear();
            wbRssLink.Source = new Uri("about: blank");
            MessageBox.Show($"�폜���܂����B");

        }
    }
}
