using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using static CarReportSystem.CarReport;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarReportSystem {
    public partial class Form1 : Form {

        //カーレポートのデータ管理用リスト
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        //設定クラスのインスタンスを生成
        Settings settings = Settings.getInstance();

        public Form1() {
            InitializeComponent();
            dgvRecord.DataSource = listCarReports;
        }

        private void btPicOpen_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
            }
        }

        private void btPicDelete_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        //記録者の履歴をコンボボックスへ登録
        private void setCbAuthor(string author) {
            if (cbAuthor.Items.Contains(author)) {
            } else {
                cbAuthor.Items.Add(author);
            }
        }
        //車名の履歴をコンボボックスへ登録
        private void setCbCarName(string carName) {
            if (cbCarName.Items.Contains(carName)) {
            } else {
                cbCarName.Items.Add(carName);
            }
        }

        //追加　標準
        private void btRecordAdd_Click(object sender, EventArgs e) {
            if (cbAuthor.Text == string.Empty || cbCarName.Text == string.Empty) {
                tsslbMessage.Text = "記録者、または社名が未入力です";
            }
            var carReport = new CarReport {
                Author = cbAuthor.Text,
                CarName = cbCarName.Text,
                Date = dateTimePicker1.Value,
                Report = tbReport.Text,
                Picture = pbPicture.Image,
                Maker = Makerselect()
            };

            listCarReports.Add(carReport);
            InputItemsAllClear();
            setCbAuthor(carReport.Author);
            setCbCarName(carReport.CarName);
        }

        //入力項目をすべてクリア
        private void InputItemsAllClear() {
            cbAuthor.Text = string.Empty;
            cbCarName.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Today;
            tbReport.Text = string.Empty;
            pbPicture.Image = null;
            RdOther.Checked = true;
        }
        private MakerGroup Makerselect() {

            if (Dh.Checked == true) {
                return MakerGroup.ダイハツ;
            } else if (Sr.Checked == true) {
                return MakerGroup.スバル;
            } else if (Mh.Checked == true) {
                return MakerGroup.日産;
            } else if (Hd.Checked == true) {
                return MakerGroup.ホンダ;
            } else if (Rblmport.Checked == true) {
                return MakerGroup.輸入車;
            } else {
                return MakerGroup.その他;
            }
        }

        //
        private void dgvRecord_Click(object sender, EventArgs e) {

            if (dgvRecord.CurrentRow is null) return;
            dateTimePicker1.Value = (DateTime)dgvRecord.CurrentRow.Cells["Date"].Value;
            cbAuthor.Text = (string)dgvRecord.CurrentRow.Cells["Author"].Value;
            setRedioButtonMaker((MakerGroup)dgvRecord.CurrentRow.Cells["Maker"].Value);
            cbCarName.Text = (string)dgvRecord.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (string)dgvRecord.CurrentRow.Cells["Report"].Value;
            pbPicture.Image = (Image)dgvRecord.CurrentRow.Cells["Picture"].Value;
        }

        private void tbReport_TextChanged(object sender, EventArgs e) {

        }


        //指定したメーカーのラジオボタンにセット
        private void setRedioButtonMaker(MakerGroup targetMaker) {
            switch (targetMaker) {
                case MakerGroup.ダイハツ:
                    Dh.Checked = true;
                    break;
                case MakerGroup.スバル:
                    Sr.Checked = true;
                    break;
                case MakerGroup.日産:
                    Mh.Checked = true;
                    break;
                case MakerGroup.ホンダ:
                    Hd.Checked = true;
                    break;
                case MakerGroup.輸入車:
                    Rblmport.Checked = true;
                    break;
                case MakerGroup.その他:
                    RdOther.Checked = true;
                    break;

            }
        }

        //新規入力
        private void btNewRecord_Click(object sender, EventArgs e) {
            InputItemsAllClear();
        }

        //削除
        private void btRecordDelete_Click(object sender, EventArgs e) {
            if ((dgvRecord.CurrentRow is null)
                || (dgvRecord.CurrentRow.Selected)) return;

            //選択されているインデックスを取得
            int index = dgvRecord.CurrentRow.Index;
            //削除したいインデックスを指定してリストから削除
            listCarReports.RemoveAt(index);
            listCarReports.Clear();


        }

        //修正
        private void btRecordModify_Click(object sender, EventArgs e) {

            if (dgvRecord.Rows.Count == 0) return;

            listCarReports[dgvRecord.CurrentRow.Index].Author = cbAuthor.Text;
            listCarReports[dgvRecord.CurrentRow.Index].CarName = cbCarName.Text;
            listCarReports[dgvRecord.CurrentRow.Index].Picture = pbPicture.Image;
            listCarReports[dgvRecord.CurrentRow.Index].Date = dateTimePicker1.Value;
            listCarReports[dgvRecord.CurrentRow.Index].Report = tbReport.Text;
            listCarReports[dgvRecord.CurrentRow.Index].Maker = Makerselect();
            dgvRecord.Refresh();　　//データグリッドビューの取得
        }


        private void Form1_Load(object sender, EventArgs e) {
            InputItemsAllClear();

            //交互に色を設定
            dgvRecord.RowsDefaultCellStyle.BackColor = Color.White;
            dgvRecord.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            //設定ファイルを読み込み背景色を設定する
            //逆シリアル化

            if (File.Exists("setting.xml")) {
                try {
                    using (var reader = XmlReader.Create("setting.xml")) {
                        var serializer = new XmlSerializer(typeof(Settings));
                        settings = serializer.Deserialize(reader) as Settings;
                        BackColor = Color.FromArgb(settings.MainFormBackColor);

                        //設定クラスのインスタンスにも現在の色を設定
                        //settings.MainFormBackColor = BackColor.ToArgb();
                    }
                }
                catch (Exception ex) {
                    tsslbMessage.Text = "ファイル読み込みエラー";
                    MessageBox.Show(ex.Message);
                }
            } else {
                tsslbMessage.Text = "設定ファイルがありません";
            }
        }
  


        private void tsmiExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        //このアプリについてを選択したときのイベントハンドラ
        private void tsmiAbout_Click(object sender, EventArgs e) {
            var FmVersion = new FmVersion();

            FmVersion.ShowDialog();
        }

        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (cdColor.ShowDialog() == DialogResult.OK) {
                this.BackColor = cdColor.Color;

                //設定ファイルへ保存
                settings.MainFormBackColor = cdColor.Color.ToArgb(); //背景色を設定
            }

        }

        //ファイルオープン処理
        private void reportOpenFile() {
            if (ofdReportFileOpen.ShowDialog() == DialogResult.OK) {
                try {
                    //逆シリアル化でバイナリ形式を取り込む
#pragma warning disable SYSLIB0011 // 型またはメンバーが旧型式です
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // 型またはメンバーが旧型式です
                    using (FileStream fs = File.Open(
                        ofdReportFileOpen.FileName, FileMode.Open, FileAccess.Read)) {

                        listCarReports = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvRecord.DataSource = listCarReports;


                        //コンボボックスに登録
                        foreach (var report in listCarReports) {
                            setCbAuthor(report.Author);
                            setCbCarName(report.CarName);
                        }
                    }
                }
                catch (Exception) {
                    tsslbMessage.Text = "ファイル形式が違います";
                }
            }
        }

        //ファイルセーブ処理
        private void reportSaveFile() {
            if (sfdReportFileSave.ShowDialog() == DialogResult.OK) {
                try {
                    //バイナリ形式でシリアル化
#pragma warning disable SYSLIB0011
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011

                    using (FileStream fs = File.Open(
                                    sfdReportFileSave.FileName, FileMode.Create)) {

                        bf.Serialize(fs, listCarReports);
                    }
                }
                catch (Exception ex) {
                    tsslbMessage.Text = "ファイル書き出しエラー";
                    MessageBox.Show(ex.Message);
                }
            }
        }



        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e) {
            reportSaveFile();
        }

        private void 開くToolStripMenuItem_Click(object sender, EventArgs e) {
            reportOpenFile();
        }

        //フォームが閉じたら呼ばれる
        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            //設定ファイルへ色情報を保持する処理
            using (var writer = XmlWriter.Create("setting.xml")) {
                var serializer = new XmlSerializer(settings.GetType());
                serializer.Serialize(writer,settings);
            }
        }
       
    }

}
