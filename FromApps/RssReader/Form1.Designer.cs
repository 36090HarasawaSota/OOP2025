namespace RssReader {
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
            tbUrl = new TextBox();
            btRssGet = new Button();
            lbTitles = new ListBox();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            nextbt = new Button();
            backbt = new Button();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            SuspendLayout();
            // 
            // tbUrl
            // 
            tbUrl.Font = new Font("Yu Gothic UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbUrl.Location = new Point(337, 14);
            tbUrl.Name = "tbUrl";
            tbUrl.Size = new Size(578, 43);
            tbUrl.TabIndex = 0;
            // 
            // btRssGet
            // 
            btRssGet.Location = new Point(938, 10);
            btRssGet.Name = "btRssGet";
            btRssGet.Size = new Size(145, 50);
            btRssGet.TabIndex = 1;
            btRssGet.Text = "取得";
            btRssGet.UseVisualStyleBackColor = true;
            btRssGet.Click += btRssGet_Click;
            // 
            // lbTitles
            // 
            lbTitles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbTitles.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lbTitles.FormattingEnabled = true;
            lbTitles.ItemHeight = 25;
            lbTitles.Location = new Point(21, 76);
            lbTitles.Name = "lbTitles";
            lbTitles.Size = new Size(504, 529);
            lbTitles.TabIndex = 2;
            lbTitles.Click += lbTitles_SelectedIndexChanged;
            lbTitles.SelectedIndexChanged += lbTitles_SelectedIndexChanged;
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Location = new Point(568, 66);
            webView21.Name = "webView21";
            webView21.Size = new Size(525, 539);
            webView21.TabIndex = 3;
            webView21.ZoomFactor = 1D;
            // 
            // nextbt
            // 
            nextbt.Location = new Point(171, 13);
            nextbt.Name = "nextbt";
            nextbt.Size = new Size(132, 48);
            nextbt.TabIndex = 4;
            nextbt.Text = "追加";
            nextbt.UseVisualStyleBackColor = true;
            nextbt.Click += nextbt_Click;
            // 
            // backbt
            // 
            backbt.Location = new Point(30, 14);
            backbt.Name = "backbt";
            backbt.Size = new Size(122, 47);
            backbt.TabIndex = 5;
            backbt.Text = "戻る";
            backbt.UseVisualStyleBackColor = true;
            backbt.Click += backbt_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1129, 627);
            Controls.Add(backbt);
            Controls.Add(nextbt);
            Controls.Add(webView21);
            Controls.Add(lbTitles);
            Controls.Add(btRssGet);
            Controls.Add(tbUrl);
            Name = "Form1";
            Text = "RssReader";
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbUrl;
        private Button btRssGet;
        private ListBox lbTitles;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private Button nextbt;
        private Button backbt;
    }
}
