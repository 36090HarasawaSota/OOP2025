namespace UnitConverter {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            label1 = new Label();
            tbBeforeConvertion = new TextBox();
            tbAfterConversion = new TextBox();
            tb = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.Location = new Point(111, 9);
            label1.Name = "label1";
            label1.Size = new Size(218, 45);
            label1.TabIndex = 0;
            label1.Text = "距離換算アプリ";
            label1.Click += label1_Click;
            // 
            // tbBeforeConvertion
            // 
            tbBeforeConvertion.Font = new Font("Yu Gothic UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbBeforeConvertion.Location = new Point(148, 84);
            tbBeforeConvertion.Name = "tbBeforeConvertion";
            tbBeforeConvertion.Size = new Size(135, 50);
            tbBeforeConvertion.TabIndex = 1;
            tbBeforeConvertion.TextChanged += tbBeforeConvertion_TextChanged;
            // 
            // tbAfterConversion
            // 
            tbAfterConversion.Font = new Font("Yu Gothic UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbAfterConversion.Location = new Point(148, 161);
            tbAfterConversion.Name = "tbAfterConversion";
            tbAfterConversion.Size = new Size(135, 50);
            tbAfterConversion.TabIndex = 1;
            tbAfterConversion.Text = "   変換";
            // 
            // tb
            // 
            tb.Font = new Font("Yu Gothic UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tb.Location = new Point(148, 255);
            tb.Name = "tb";
            tb.Size = new Size(135, 50);
            tb.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(428, 376);
            Controls.Add(tb);
            Controls.Add(tbAfterConversion);
            Controls.Add(tbBeforeConvertion);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbBeforeConvertion;
        private TextBox tbAfterConversion;
        private TextBox tb;
    }
}
