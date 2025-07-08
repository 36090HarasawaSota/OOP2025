﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarReportSystem
{
    public partial class FmVersion : Form {
        public FmVersion() {
            InitializeComponent();
        }


        private void btOK_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void FmVersion_Load(object sender, EventArgs e) {
            var asm = Assembly.GetExecutingAssembly();
            var version = asm.GetName().Version;
            lbVersion.Text = string.Format($"{version.Major}.{version.Minor}{version.Build}.{version.Revision}");
        }
    }
}
