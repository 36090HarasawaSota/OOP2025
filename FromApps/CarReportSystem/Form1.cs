using System.ComponentModel;
using System.Diagnostics.Metrics;
using static CarReportSystem.CarReport;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarReportSystem {
    public partial class Form1 : Form {

        //カーレポートのデータ管理用リスト
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

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


        private void btRecordAdd_Click(object sender, EventArgs e) {
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




        private void Cb_SelectedIndexChanged(object sender, EventArgs e) {

        }

        

        private void Mh_CheckedChanged(object sender, EventArgs e) {

        }


        private void dgvRecord_Click(object sender, EventArgs e) {
            if (dgvRecord.CurrentRow.Cells is not null) {
                dateTimePicker1.Value = (DateTime)dgvRecord.CurrentRow.Cells["Date"].Value;
                cbAuthor.Text = (string)dgvRecord.CurrentRow.Cells["Author"].Value;
                setRedioButtonMaker((MakerGroup)dgvRecord.CurrentRow.Cells["Maker"].Value);
                cbCarName.Text = (string)dgvRecord.CurrentRow.Cells["CarName"].Value;
                tbReport.Text = (string)dgvRecord.CurrentRow.Cells["Report"].Value;
                pbPicture.Image = (Image)dgvRecord.CurrentRow.Cells["Report"].Value;
            }
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

        //新規追加
        private void btNewRecord_Click(object sender, EventArgs e) {

        }

        //削除
        private void btRecordDelete_Click(object sender, EventArgs e) {

        }
        //修正
        private void btRecordModify_Click(object sender, EventArgs e) {

        }
    }
}
