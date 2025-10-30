using System.Diagnostics;

namespace Section03 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e) {
            ToolStripStatusLabel1.Text = "";
            await DoLongTimeWork();
            ToolStripStatusLabel1.Text = $"�I��";
        }

        //�߂�l�̂��铯�����\�b�h
        private async Task DoLongTimeWork() {
            await Task.Run(()=> {
                System.Threading.Thread.Sleep(5000);
            });
        }


    }
}
