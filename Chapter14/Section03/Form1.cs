namespace Section03 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e) {
            ToolStripStatusLabel1.Text = "";
            await Task.Run(()=>DoLongTimeWork());
            ToolStripStatusLabel1.Text = "�I��";
        }

        private void DoLongTimeWork() {
            System.Threading.Thread.Sleep(5000);
        }


    }
}
