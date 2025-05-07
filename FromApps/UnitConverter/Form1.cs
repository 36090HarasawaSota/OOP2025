using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnitConverter
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) {

        }

        private void btChange_Click(object sender, EventArgs e) {
            int num1 = int.Parse(tbNum1.Text);
            double num2 = num1 * 0.3408; //整数×実数は実数として計算してくれる
            tbNum2.Text = num2.ToString();
        }

        private void tbNum1_Click(object sender, EventArgs e) {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            nudAmari.Value = nudNum1.Value % nudNum2.Value;
            nudAnswer.Value = nudNum1.Value / nudNum2.Value;
           
        }
    }
}
