
namespace RssReader {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.btGet = new System.Windows.Forms.Button();
            this.lbRssTitle = new System.Windows.Forms.ListBox();
            this.wbBrowser = new System.Windows.Forms.WebBrowser();
            this.rbMain = new System.Windows.Forms.RadioButton();
            this.gbTopics = new System.Windows.Forms.GroupBox();
            this.rbEconomy = new System.Windows.Forms.RadioButton();
            this.rbSport = new System.Windows.Forms.RadioButton();
            this.rbEntertainment = new System.Windows.Forms.RadioButton();
            this.gbTopics.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbUrl
            // 
            this.tbUrl.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbUrl.Location = new System.Drawing.Point(34, 26);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(655, 31);
            this.tbUrl.TabIndex = 0;
            // 
            // btGet
            // 
            this.btGet.Location = new System.Drawing.Point(695, 26);
            this.btGet.Name = "btGet";
            this.btGet.Size = new System.Drawing.Size(90, 31);
            this.btGet.TabIndex = 1;
            this.btGet.Text = "取得";
            this.btGet.UseVisualStyleBackColor = true;
            this.btGet.Click += new System.EventHandler(this.btGet_Click);
            // 
            // lbRssTitle
            // 
            this.lbRssTitle.FormattingEnabled = true;
            this.lbRssTitle.ItemHeight = 12;
            this.lbRssTitle.Location = new System.Drawing.Point(34, 72);
            this.lbRssTitle.Name = "lbRssTitle";
            this.lbRssTitle.Size = new System.Drawing.Size(382, 100);
            this.lbRssTitle.TabIndex = 2;
            this.lbRssTitle.Click += new System.EventHandler(this.lbRssTitle_Click);
            // 
            // wbBrowser
            // 
            this.wbBrowser.Location = new System.Drawing.Point(34, 178);
            this.wbBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbBrowser.Name = "wbBrowser";
            this.wbBrowser.ScriptErrorsSuppressed = true;
            this.wbBrowser.Size = new System.Drawing.Size(751, 492);
            this.wbBrowser.TabIndex = 3;
            // 
            // rbMain
            // 
            this.rbMain.AutoSize = true;
            this.rbMain.Location = new System.Drawing.Point(6, 18);
            this.rbMain.Name = "rbMain";
            this.rbMain.Size = new System.Drawing.Size(47, 16);
            this.rbMain.TabIndex = 4;
            this.rbMain.TabStop = true;
            this.rbMain.Text = "主要";
            this.rbMain.UseVisualStyleBackColor = true;
            // 
            // gbTopics
            // 
            this.gbTopics.Controls.Add(this.rbEconomy);
            this.gbTopics.Controls.Add(this.rbSport);
            this.gbTopics.Controls.Add(this.rbEntertainment);
            this.gbTopics.Controls.Add(this.rbMain);
            this.gbTopics.Location = new System.Drawing.Point(439, 72);
            this.gbTopics.Name = "gbTopics";
            this.gbTopics.Size = new System.Drawing.Size(189, 100);
            this.gbTopics.TabIndex = 5;
            this.gbTopics.TabStop = false;
            this.gbTopics.Text = "groupBox1";
            // 
            // rbEconomy
            // 
            this.rbEconomy.AutoSize = true;
            this.rbEconomy.Location = new System.Drawing.Point(6, 40);
            this.rbEconomy.Name = "rbEconomy";
            this.rbEconomy.Size = new System.Drawing.Size(47, 16);
            this.rbEconomy.TabIndex = 7;
            this.rbEconomy.TabStop = true;
            this.rbEconomy.Text = "経済";
            this.rbEconomy.UseVisualStyleBackColor = true;
            // 
            // rbSport
            // 
            this.rbSport.AutoSize = true;
            this.rbSport.Location = new System.Drawing.Point(101, 41);
            this.rbSport.Name = "rbSport";
            this.rbSport.Size = new System.Drawing.Size(61, 16);
            this.rbSport.TabIndex = 6;
            this.rbSport.TabStop = true;
            this.rbSport.Text = "スポーツ";
            this.rbSport.UseVisualStyleBackColor = true;
            // 
            // rbEntertainment
            // 
            this.rbEntertainment.AutoSize = true;
            this.rbEntertainment.Location = new System.Drawing.Point(101, 19);
            this.rbEntertainment.Name = "rbEntertainment";
            this.rbEntertainment.Size = new System.Drawing.Size(57, 16);
            this.rbEntertainment.TabIndex = 5;
            this.rbEntertainment.TabStop = true;
            this.rbEntertainment.Text = "エンタメ";
            this.rbEntertainment.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 682);
            this.Controls.Add(this.gbTopics);
            this.Controls.Add(this.wbBrowser);
            this.Controls.Add(this.lbRssTitle);
            this.Controls.Add(this.btGet);
            this.Controls.Add(this.tbUrl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gbTopics.ResumeLayout(false);
            this.gbTopics.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.Button btGet;
        private System.Windows.Forms.ListBox lbRssTitle;
        private System.Windows.Forms.WebBrowser wbBrowser;
        private System.Windows.Forms.RadioButton rbMain;
        private System.Windows.Forms.GroupBox gbTopics;
        private System.Windows.Forms.RadioButton rbEconomy;
        private System.Windows.Forms.RadioButton rbSport;
        private System.Windows.Forms.RadioButton rbEntertainment;
    }
}

