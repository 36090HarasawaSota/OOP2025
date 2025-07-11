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

        //�J�[���|�[�g�̃f�[�^�Ǘ��p���X�g
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        //�ݒ�N���X�̃C���X�^���X�𐶐�
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

        //�ǉ��@�W��
        private void btRecordAdd_Click(object sender, EventArgs e) {
            if (cbAuthor.Text == string.Empty || cbCarName.Text == string.Empty) {
                tsslbMessage.Text = "�L�^�ҁA�܂��͎Ж��������͂ł�";
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

        //�V�K����
        private void btNewRecord_Click(object sender, EventArgs e) {
            InputItemsAllClear();
        }

        //�폜
        private void btRecordDelete_Click(object sender, EventArgs e) {
            if ((dgvRecord.CurrentRow is null)
                || (dgvRecord.CurrentRow.Selected)) return;

            //�I������Ă���C���f�b�N�X���擾
            int index = dgvRecord.CurrentRow.Index;
            //�폜�������C���f�b�N�X���w�肵�ă��X�g����폜
            listCarReports.RemoveAt(index);
            listCarReports.Clear();


        }

        //�C��
        private void btRecordModify_Click(object sender, EventArgs e) {

            if (dgvRecord.Rows.Count == 0) return;

            listCarReports[dgvRecord.CurrentRow.Index].Author = cbAuthor.Text;
            listCarReports[dgvRecord.CurrentRow.Index].CarName = cbCarName.Text;
            listCarReports[dgvRecord.CurrentRow.Index].Picture = pbPicture.Image;
            listCarReports[dgvRecord.CurrentRow.Index].Date = dateTimePicker1.Value;
            listCarReports[dgvRecord.CurrentRow.Index].Report = tbReport.Text;
            listCarReports[dgvRecord.CurrentRow.Index].Maker = Makerselect();
            dgvRecord.Refresh();�@�@//�f�[�^�O���b�h�r���[�̎擾
        }


        private void Form1_Load(object sender, EventArgs e) {
            InputItemsAllClear();

            //���݂ɐF��ݒ�
            dgvRecord.RowsDefaultCellStyle.BackColor = Color.White;
            dgvRecord.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            //�ݒ�t�@�C����ǂݍ��ݔw�i�F��ݒ肷��
            //�t�V���A����

            if (File.Exists("setting.xml")) {
                try {
                    using (var reader = XmlReader.Create("setting.xml")) {
                        var serializer = new XmlSerializer(typeof(Settings));
                        settings = serializer.Deserialize(reader) as Settings;
                        BackColor = Color.FromArgb(settings.MainFormBackColor);

                        //�ݒ�N���X�̃C���X�^���X�ɂ����݂̐F��ݒ�
                        //settings.MainFormBackColor = BackColor.ToArgb();
                    }
                }
                catch (Exception ex) {
                    tsslbMessage.Text = "�t�@�C���ǂݍ��݃G���[";
                    MessageBox.Show(ex.Message);
                }
            } else {
                tsslbMessage.Text = "�ݒ�t�@�C��������܂���";
            }
        }
  


        private void tsmiExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        //���̃A�v���ɂ��Ă�I�������Ƃ��̃C�x���g�n���h��
        private void tsmiAbout_Click(object sender, EventArgs e) {
            var FmVersion = new FmVersion();

            FmVersion.ShowDialog();
        }

        private void �F�ݒ�ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (cdColor.ShowDialog() == DialogResult.OK) {
                this.BackColor = cdColor.Color;

                //�ݒ�t�@�C���֕ۑ�
                settings.MainFormBackColor = cdColor.Color.ToArgb(); //�w�i�F��ݒ�
            }

        }

        //�t�@�C���I�[�v������
        private void reportOpenFile() {
            if (ofdReportFileOpen.ShowDialog() == DialogResult.OK) {
                try {
                    //�t�V���A�����Ńo�C�i���`������荞��
#pragma warning disable SYSLIB0011 // �^�܂��̓����o�[�����^���ł�
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // �^�܂��̓����o�[�����^���ł�
                    using (FileStream fs = File.Open(
                        ofdReportFileOpen.FileName, FileMode.Open, FileAccess.Read)) {

                        listCarReports = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvRecord.DataSource = listCarReports;


                        //�R���{�{�b�N�X�ɓo�^
                        foreach (var report in listCarReports) {
                            setCbAuthor(report.Author);
                            setCbCarName(report.CarName);
                        }
                    }
                }
                catch (Exception) {
                    tsslbMessage.Text = "�t�@�C���`�����Ⴂ�܂�";
                }
            }
        }

        //�t�@�C���Z�[�u����
        private void reportSaveFile() {
            if (sfdReportFileSave.ShowDialog() == DialogResult.OK) {
                try {
                    //�o�C�i���`���ŃV���A����
#pragma warning disable SYSLIB0011
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011

                    using (FileStream fs = File.Open(
                                    sfdReportFileSave.FileName, FileMode.Create)) {

                        bf.Serialize(fs, listCarReports);
                    }
                }
                catch (Exception ex) {
                    tsslbMessage.Text = "�t�@�C�������o���G���[";
                    MessageBox.Show(ex.Message);
                }
            }
        }



        private void �ۑ�ToolStripMenuItem_Click(object sender, EventArgs e) {
            reportSaveFile();
        }

        private void �J��ToolStripMenuItem_Click(object sender, EventArgs e) {
            reportOpenFile();
        }

        //�t�H�[����������Ă΂��
        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            //�ݒ�t�@�C���֐F����ێ����鏈��
            using (var writer = XmlWriter.Create("setting.xml")) {
                var serializer = new XmlSerializer(settings.GetType());
                serializer.Serialize(writer,settings);
            }
        }
       
    }

}
