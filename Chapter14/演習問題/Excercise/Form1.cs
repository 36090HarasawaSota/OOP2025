using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excercise {
    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "テキストファイル (*.txt)|*.txt|すべてのファイル (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                string filePath = openFileDialog.FileName;

                // ファイルの読み込み（1行ずつ非同期）
                StringBuilder sb = new StringBuilder();
                using (StreamReader reader = new StreamReader(filePath)) {
                    string? line;
                    while ((line = await reader.ReadLineAsync()) != null) {
                        sb.AppendLine(line);
                    }
                }

                // 読み込んだ内容をUIに反映（メインスレッド）
                textBoxDisplay.Text = sb.ToString();
            }
        }


    }
}
