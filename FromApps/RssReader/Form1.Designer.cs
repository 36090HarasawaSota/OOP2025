﻿namespace RssReader {
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
            btRssGet = new Button();
            lbTitles = new ListBox();
            wbRssLink = new Microsoft.Web.WebView2.WinForms.WebView2();
            btGoFard = new Button();
            btGoBack = new Button();
            cburl = new ComboBox();
            tburl = new TextBox();
            ourllb = new Label();
            Registrgt = new Button();
            btremove = new Button();
            ((System.ComponentModel.ISupportInitialize)wbRssLink).BeginInit();
            SuspendLayout();
            // 
            // btRssGet
            // 
            btRssGet.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btRssGet.Location = new Point(16, 22);
            btRssGet.Name = "btRssGet";
            btRssGet.Size = new Size(152, 49);
            btRssGet.TabIndex = 1;
            btRssGet.Text = "取得";
            btRssGet.UseVisualStyleBackColor = true;
            btRssGet.Click += btRssGet_Click;
            // 
            // lbTitles
            // 
            lbTitles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbTitles.DrawMode = DrawMode.OwnerDrawFixed;
            lbTitles.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lbTitles.FormattingEnabled = true;
            lbTitles.ItemHeight = 25;
            lbTitles.Location = new Point(35, 142);
            lbTitles.Name = "lbTitles";
            lbTitles.Size = new Size(352, 454);
            lbTitles.TabIndex = 2;
            lbTitles.Click += lbTitles_SelectedIndexChanged;
            lbTitles.DrawItem += lbTitles_DrawItem;
            lbTitles.SelectedIndexChanged += lbTitles_SelectedIndexChanged;
            // 
            // wbRssLink
            // 
            wbRssLink.AllowExternalDrop = true;
            wbRssLink.BackColor = SystemColors.Window;
            wbRssLink.CreationProperties = null;
            wbRssLink.DefaultBackgroundColor = Color.White;
            wbRssLink.Location = new Point(406, 142);
            wbRssLink.Name = "wbRssLink";
            wbRssLink.Size = new Size(669, 454);
            wbRssLink.TabIndex = 3;
            wbRssLink.ZoomFactor = 1D;
            wbRssLink.SourceChanged += wvRssLink_SourceChanged;
            // 
            // btGoFard
            // 
            btGoFard.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btGoFard.Location = new Point(783, 22);
            btGoFard.Name = "btGoFard";
            btGoFard.Size = new Size(132, 48);
            btGoFard.TabIndex = 4;
            btGoFard.Text = "進む";
            btGoFard.UseVisualStyleBackColor = true;
            btGoFard.Click += btGoFard_Click;
            // 
            // btGoBack
            // 
            btGoBack.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btGoBack.Location = new Point(932, 22);
            btGoBack.Name = "btGoBack";
            btGoBack.Size = new Size(143, 48);
            btGoBack.TabIndex = 5;
            btGoBack.Text = "戻る";
            btGoBack.UseVisualStyleBackColor = true;
            btGoBack.Click += btGoBack_Click;
            // 
            // cburl
            // 
            cburl.Font = new Font("Yu Gothic UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            cburl.FormattingEnabled = true;
            cburl.Location = new Point(183, 22);
            cburl.Name = "cburl";
            cburl.Size = new Size(581, 45);
            cburl.TabIndex = 6;
            // 
            // tburl
            // 
            tburl.Font = new Font("Yu Gothic UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tburl.Location = new Point(183, 87);
            tburl.Name = "tburl";
            tburl.Size = new Size(581, 43);
            tburl.TabIndex = 7;
            // 
            // ourllb
            // 
            ourllb.AutoSize = true;
            ourllb.FlatStyle = FlatStyle.Popup;
            ourllb.Font = new Font("Yu Gothic UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            ourllb.ForeColor = Color.FromArgb(64, 64, 64);
            ourllb.Location = new Point(35, 90);
            ourllb.Name = "ourllb";
            ourllb.Size = new Size(133, 37);
            ourllb.TabIndex = 8;
            ourllb.Text = "お気に入り";
            // 
            // Registrgt
            // 
            Registrgt.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            Registrgt.Location = new Point(781, 81);
            Registrgt.Name = "Registrgt";
            Registrgt.Size = new Size(134, 49);
            Registrgt.TabIndex = 9;
            Registrgt.Text = "登録";
            Registrgt.UseVisualStyleBackColor = true;
            Registrgt.Click += Registrgt_Click;
            // 
            // btremove
            // 
            btremove.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btremove.Location = new Point(932, 81);
            btremove.Name = "btremove";
            btremove.Size = new Size(143, 49);
            btremove.TabIndex = 10;
            btremove.Text = "削除";
            btremove.UseVisualStyleBackColor = true;
            btremove.Click += btremove_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(1103, 627);
            Controls.Add(btremove);
            Controls.Add(Registrgt);
            Controls.Add(ourllb);
            Controls.Add(tburl);
            Controls.Add(cburl);
            Controls.Add(btGoBack);
            Controls.Add(btGoFard);
            Controls.Add(wbRssLink);
            Controls.Add(lbTitles);
            Controls.Add(btRssGet);
            Name = "Form1";
            Text = "RssReader";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)wbRssLink).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbUrl;
        private Button btRssGet;
        private ListBox lbTitles;
        private Microsoft.Web.WebView2.WinForms.WebView2 wbRssLink;
        private Button btGoFard;
        private Button btGoBack;
        private ComboBox cburl;
        private TextBox tburl;
        private Label ourllb;
        private Button Registrgt;
        private Button btremove;
    }
}
