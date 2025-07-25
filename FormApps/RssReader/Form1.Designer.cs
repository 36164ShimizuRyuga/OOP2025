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
            btRssGet = new Button();
            lbTitles = new ListBox();
            wvRssLink = new Microsoft.Web.WebView2.WinForms.WebView2();
            btNext = new Button();
            btReturn = new Button();
            cbUrl = new ComboBox();
            tbFavoritName = new TextBox();
            btRegistration = new Button();
            btDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)wvRssLink).BeginInit();
            SuspendLayout();
            // 
            // btRssGet
            // 
            btRssGet.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btRssGet.Location = new Point(829, 8);
            btRssGet.Name = "btRssGet";
            btRssGet.Size = new Size(87, 32);
            btRssGet.TabIndex = 1;
            btRssGet.Text = "取得";
            btRssGet.UseVisualStyleBackColor = true;
            btRssGet.Click += btRssGet_Click;
            // 
            // lbTitles
            // 
            lbTitles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbTitles.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lbTitles.FormattingEnabled = true;
            lbTitles.ItemHeight = 21;
            lbTitles.Location = new Point(12, 118);
            lbTitles.Name = "lbTitles";
            lbTitles.Size = new Size(962, 277);
            lbTitles.TabIndex = 2;
            lbTitles.Click += lbTitles_Click;
            // 
            // wvRssLink
            // 
            wvRssLink.AllowExternalDrop = true;
            wvRssLink.CreationProperties = null;
            wvRssLink.DefaultBackgroundColor = Color.White;
            wvRssLink.Location = new Point(12, 415);
            wvRssLink.Name = "wvRssLink";
            wvRssLink.Size = new Size(962, 383);
            wvRssLink.TabIndex = 3;
            wvRssLink.ZoomFactor = 1D;
            wvRssLink.SourceChanged += wvRssLink_SourceChanged;
            // 
            // btNext
            // 
            btNext.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btNext.Location = new Point(125, 8);
            btNext.Name = "btNext";
            btNext.Size = new Size(57, 35);
            btNext.TabIndex = 4;
            btNext.Text = "進む";
            btNext.UseVisualStyleBackColor = true;
            btNext.Click += btNext_Click_1;
            // 
            // btReturn
            // 
            btReturn.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btReturn.Location = new Point(40, 8);
            btReturn.Name = "btReturn";
            btReturn.Size = new Size(64, 35);
            btReturn.TabIndex = 5;
            btReturn.Text = "戻る";
            btReturn.UseVisualStyleBackColor = true;
            btReturn.Click += btReturn_Click;
            // 
            // cbUrl
            // 
            cbUrl.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            cbUrl.FormattingEnabled = true;
            cbUrl.Location = new Point(200, 14);
            cbUrl.Name = "cbUrl";
            cbUrl.Size = new Size(613, 29);
            cbUrl.TabIndex = 6;
            // 
            // tbFavoritName
            // 
            tbFavoritName.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbFavoritName.Location = new Point(200, 64);
            tbFavoritName.Name = "tbFavoritName";
            tbFavoritName.Size = new Size(324, 29);
            tbFavoritName.TabIndex = 7;
            // 
            // btRegistration
            // 
            btRegistration.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btRegistration.Location = new Point(557, 68);
            btRegistration.Name = "btRegistration";
            btRegistration.Size = new Size(79, 25);
            btRegistration.TabIndex = 8;
            btRegistration.Text = "登録";
            btRegistration.UseVisualStyleBackColor = true;
            btRegistration.Click += btRegistration_Click;
            // 
            // btDelete
            // 
            btDelete.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btDelete.Location = new Point(671, 71);
            btDelete.Name = "btDelete";
            btDelete.Size = new Size(75, 23);
            btDelete.TabIndex = 9;
            btDelete.Text = "登録消去";
            btDelete.UseVisualStyleBackColor = true;
            btDelete.Click += btDelete_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(986, 801);
            Controls.Add(btDelete);
            Controls.Add(btRegistration);
            Controls.Add(tbFavoritName);
            Controls.Add(cbUrl);
            Controls.Add(btReturn);
            Controls.Add(btNext);
            Controls.Add(wvRssLink);
            Controls.Add(lbTitles);
            Controls.Add(btRssGet);
            Name = "Form1";
            Text = "Rssリーダー";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)wvRssLink).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btRssGet;
        private ListBox lbTitles;
        private Microsoft.Web.WebView2.WinForms.WebView2 wvRssLink;
        private Button btNext;
        private Button btReturn;
        private ComboBox cbUrl;
        private TextBox tbFavoritName;
        private Button btRegistration;
        private Button btDelete;
    }
}
