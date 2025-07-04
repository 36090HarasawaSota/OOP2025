using System.ComponentModel;
using System.Diagnostics.Metrics;
using static CarReportSystem.CarReport;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarReportSystem {
    public partial class Form1 : Form {

        //�J�[���|�[�g�̃f�[�^�Ǘ��p���X�g
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

        //�L�^�҂̗������R���{�{�b�N�X�֓o�^
        private void setCbAuthor(string author) {
            if (cbAuthor.Items.Contains(author)) {
            } else {
                cbAuthor.Items.Add(author);
            }
        }
        //�Ԗ��̗������R���{�{�b�N�X�֓o�^
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

        //���͍��ڂ����ׂăN���A
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
                return MakerGroup.�_�C�n�c;
            } else if (Sr.Checked == true) {
                return MakerGroup.�X�o��;
            } else if (Mh.Checked == true) {
                return MakerGroup.���Y;
            } else if (Hd.Checked == true) {
                return MakerGroup.�z���_;
            } else if (Rblmport.Checked == true) {
                return MakerGroup.�A����;
            } else {
                return MakerGroup.���̑�;
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


        //�w�肵�����[�J�[�̃��W�I�{�^���ɃZ�b�g
        private void setRedioButtonMaker(MakerGroup targetMaker) {
            switch (targetMaker) {
                case MakerGroup.�_�C�n�c:
                    Dh.Checked = true;
                    break;
                case MakerGroup.�X�o��:
                    Sr.Checked = true;
                    break;
                case MakerGroup.���Y:
                    Mh.Checked = true;
                    break;
                case MakerGroup.�z���_:
                    Hd.Checked = true;
                    break;
                case MakerGroup.�A����:
                    Rblmport.Checked = true;
                    break;
                case MakerGroup.���̑�:
                    RdOther.Checked = true;
                    break;






            }
        }

        //�V�K�ǉ�
        private void btNewRecord_Click(object sender, EventArgs e) {

        }

        //�폜
        private void btRecordDelete_Click(object sender, EventArgs e) {

        }
        //�C��
        private void btRecordModify_Click(object sender, EventArgs e) {

        }
    }
}
