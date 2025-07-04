namespace CarReportSystem {
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            dateTimePicker1 = new DateTimePicker();
            cbAuthor = new ComboBox();
            groupBox1 = new GroupBox();
            RdOther = new RadioButton();
            Rblmport = new RadioButton();
            Hd = new RadioButton();
            Sr = new RadioButton();
            Mh = new RadioButton();
            Dh = new RadioButton();
            cbCarName = new ComboBox();
            dgvRecord = new DataGridView();
            label8 = new Label();
            tbReport = new TextBox();
            pbPicture = new PictureBox();
            btPicOpen = new Button();
            btPicDelete = new Button();
            btRecordAdd = new Button();
            btRecordModify = new Button();
            btRecordDelete = new Button();
            ofdPicFileOpen = new OpenFileDialog();
            btNewRecord = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecord).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPicture).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.Location = new Point(67, 35);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(55, 30);
            label1.TabIndex = 0;
            label1.Text = "日付";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label2.Location = new Point(67, 98);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(76, 30);
            label2.TabIndex = 0;
            label2.Text = "記録者";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label3.Location = new Point(67, 210);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(55, 30);
            label3.TabIndex = 0;
            label3.Text = "車名";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label4.Location = new Point(67, 157);
            label4.Name = "label4";
            label4.RightToLeft = RightToLeft.Yes;
            label4.Size = new Size(71, 30);
            label4.TabIndex = 0;
            label4.Text = "メーカー";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label5.Location = new Point(67, 273);
            label5.Name = "label5";
            label5.RightToLeft = RightToLeft.Yes;
            label5.Size = new Size(74, 30);
            label5.TabIndex = 0;
            label5.Text = "レポート";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label6.Location = new Point(67, 416);
            label6.Name = "label6";
            label6.RightToLeft = RightToLeft.Yes;
            label6.Size = new Size(55, 30);
            label6.TabIndex = 0;
            label6.Text = "一覧";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label7.Location = new Point(629, 23);
            label7.Name = "label7";
            label7.RightToLeft = RightToLeft.Yes;
            label7.Size = new Size(62, 32);
            label7.TabIndex = 0;
            label7.Text = "画像";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dateTimePicker1.Location = new Point(152, 35);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(181, 33);
            dateTimePicker1.TabIndex = 1;
            // 
            // cbAuthor
            // 
            cbAuthor.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            cbAuthor.FormattingEnabled = true;
            cbAuthor.Location = new Point(152, 93);
            cbAuthor.Name = "cbAuthor";
            cbAuthor.Size = new Size(181, 33);
            cbAuthor.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(RdOther);
            groupBox1.Controls.Add(Rblmport);
            groupBox1.Controls.Add(Hd);
            groupBox1.Controls.Add(Sr);
            groupBox1.Controls.Add(Mh);
            groupBox1.Controls.Add(Dh);
            groupBox1.Location = new Point(152, 151);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(433, 47);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            // 
            // RdOther
            // 
            RdOther.AutoSize = true;
            RdOther.Location = new Point(348, 23);
            RdOther.Name = "RdOther";
            RdOther.Size = new Size(56, 19);
            RdOther.TabIndex = 3;
            RdOther.TabStop = true;
            RdOther.Text = "その他";
            RdOther.UseVisualStyleBackColor = true;
            // 
            // Rblmport
            // 
            Rblmport.AutoSize = true;
            Rblmport.Location = new Point(281, 22);
            Rblmport.Name = "Rblmport";
            Rblmport.Size = new Size(61, 19);
            Rblmport.TabIndex = 3;
            Rblmport.TabStop = true;
            Rblmport.Text = "輸入車";
            Rblmport.UseVisualStyleBackColor = true;
            // 
            // Hd
            // 
            Hd.AutoSize = true;
            Hd.Location = new Point(210, 23);
            Hd.Name = "Hd";
            Hd.Size = new Size(53, 19);
            Hd.TabIndex = 3;
            Hd.TabStop = true;
            Hd.Text = "ホンダ";
            Hd.UseVisualStyleBackColor = true;
            // 
            // Sr
            // 
            Sr.AutoSize = true;
            Sr.Location = new Point(72, 22);
            Sr.Name = "Sr";
            Sr.Size = new Size(54, 19);
            Sr.TabIndex = 2;
            Sr.TabStop = true;
            Sr.Text = "スバル";
            Sr.UseVisualStyleBackColor = true;
            // 
            // Mh
            // 
            Mh.AutoSize = true;
            Mh.Location = new Point(146, 23);
            Mh.Name = "Mh";
            Mh.Size = new Size(49, 19);
            Mh.TabIndex = 1;
            Mh.TabStop = true;
            Mh.Text = "日産";
            Mh.UseVisualStyleBackColor = true;
            // 
            // Dh
            // 
            Dh.AutoSize = true;
            Dh.Location = new Point(6, 22);
            Dh.Name = "Dh";
            Dh.Size = new Size(60, 19);
            Dh.TabIndex = 0;
            Dh.TabStop = true;
            Dh.Text = "ダイハツ";
            Dh.UseVisualStyleBackColor = true;
            // 
            // cbCarName
            // 
            cbCarName.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            cbCarName.FormattingEnabled = true;
            cbCarName.Location = new Point(152, 211);
            cbCarName.Name = "cbCarName";
            cbCarName.Size = new Size(181, 33);
            cbCarName.TabIndex = 2;
            // 
            // dgvRecord
            // 
            dgvRecord.AllowUserToAddRows = false;
            dgvRecord.AllowUserToDeleteRows = false;
            dgvRecord.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecord.Location = new Point(158, 416);
            dgvRecord.MultiSelect = false;
            dgvRecord.Name = "dgvRecord";
            dgvRecord.ReadOnly = true;
            dgvRecord.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecord.Size = new Size(798, 150);
            dgvRecord.TabIndex = 4;
            dgvRecord.Click += dgvRecord_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(477, 253);
            label8.Name = "label8";
            label8.Size = new Size(0, 15);
            label8.TabIndex = 5;
            // 
            // tbReport
            // 
            tbReport.Location = new Point(152, 284);
            tbReport.Multiline = true;
            tbReport.Name = "tbReport";
            tbReport.Size = new Size(433, 111);
            tbReport.TabIndex = 6;
            tbReport.TextChanged += tbReport_TextChanged;
            // 
            // pbPicture
            // 
            pbPicture.BorderStyle = BorderStyle.FixedSingle;
            pbPicture.Location = new Point(629, 84);
            pbPicture.Name = "pbPicture";
            pbPicture.Size = new Size(299, 239);
            pbPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPicture.TabIndex = 7;
            pbPicture.TabStop = false;
            // 
            // btPicOpen
            // 
            btPicOpen.FlatStyle = FlatStyle.Flat;
            btPicOpen.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btPicOpen.Location = new Point(727, 15);
            btPicOpen.Name = "btPicOpen";
            btPicOpen.Size = new Size(91, 53);
            btPicOpen.TabIndex = 8;
            btPicOpen.Text = "開く...";
            btPicOpen.UseVisualStyleBackColor = true;
            btPicOpen.Click += btPicOpen_Click;
            // 
            // btPicDelete
            // 
            btPicDelete.FlatStyle = FlatStyle.Flat;
            btPicDelete.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btPicDelete.Location = new Point(840, 15);
            btPicDelete.Name = "btPicDelete";
            btPicDelete.Size = new Size(88, 53);
            btPicDelete.TabIndex = 8;
            btPicDelete.Text = "削除";
            btPicDelete.UseVisualStyleBackColor = true;
            btPicDelete.Click += btPicDelete_Click;
            // 
            // btRecordAdd
            // 
            btRecordAdd.FlatStyle = FlatStyle.Flat;
            btRecordAdd.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btRecordAdd.Location = new Point(629, 329);
            btRecordAdd.Name = "btRecordAdd";
            btRecordAdd.Size = new Size(85, 66);
            btRecordAdd.TabIndex = 8;
            btRecordAdd.Text = "追加";
            btRecordAdd.UseVisualStyleBackColor = true;
            btRecordAdd.Click += btRecordAdd_Click;
            // 
            // btRecordModify
            // 
            btRecordModify.FlatStyle = FlatStyle.Flat;
            btRecordModify.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btRecordModify.Location = new Point(735, 329);
            btRecordModify.Name = "btRecordModify";
            btRecordModify.Size = new Size(83, 66);
            btRecordModify.TabIndex = 8;
            btRecordModify.Text = "修正";
            btRecordModify.UseVisualStyleBackColor = true;
            btRecordModify.Click += btRecordModify_Click;
            // 
            // btRecordDelete
            // 
            btRecordDelete.FlatStyle = FlatStyle.Flat;
            btRecordDelete.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btRecordDelete.Location = new Point(840, 329);
            btRecordDelete.Name = "btRecordDelete";
            btRecordDelete.Size = new Size(88, 66);
            btRecordDelete.TabIndex = 8;
            btRecordDelete.Text = "削除";
            btRecordDelete.UseVisualStyleBackColor = true;
            btRecordDelete.Click += btRecordDelete_Click;
            // 
            // ofdPicFileOpen
            // 
            ofdPicFileOpen.FileName = "openFileDialog1";
            // 
            // btNewRecord
            // 
            btNewRecord.Location = new Point(433, 35);
            btNewRecord.Name = "btNewRecord";
            btNewRecord.Size = new Size(123, 103);
            btNewRecord.TabIndex = 9;
            btNewRecord.Text = "新規入力";
            btNewRecord.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(978, 578);
            Controls.Add(btNewRecord);
            Controls.Add(btPicDelete);
            Controls.Add(btRecordDelete);
            Controls.Add(btRecordModify);
            Controls.Add(btRecordAdd);
            Controls.Add(btPicOpen);
            Controls.Add(pbPicture);
            Controls.Add(tbReport);
            Controls.Add(label8);
            Controls.Add(dgvRecord);
            Controls.Add(groupBox1);
            Controls.Add(cbCarName);
            Controls.Add(cbAuthor);
            Controls.Add(dateTimePicker1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label7);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "試乗レポート管理システム";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecord).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private DateTimePicker dateTimePicker1;
        private ComboBox cbAuthor;
        private GroupBox groupBox1;
        private RadioButton Dh;
        private RadioButton Hd;
        private RadioButton Sr;
        private RadioButton Mh;
        private RadioButton RdOther;
        private RadioButton Rblmport;
        private ComboBox cbCarName;
        private DataGridView dgvRecord;
        private Label label8;
        private TextBox tbReport;
        private PictureBox pbPicture;
        private Button btPicOpen;
        private Button btPicDelete;
        private Button btRecordAdd;
        private Button btRecordModify;
        private Button btRecordDelete;
        private OpenFileDialog ofdPicFileOpen;
        private Button btNewRecord;
    }
}
