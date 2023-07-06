
namespace CalendarApp {
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btDayCalc = new System.Windows.Forms.Button();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.btbackYear = new System.Windows.Forms.Button();
            this.btBackMonth = new System.Windows.Forms.Button();
            this.btBackDay = new System.Windows.Forms.Button();
            this.btNextYear = new System.Windows.Forms.Button();
            this.btNextMonth = new System.Windows.Forms.Button();
            this.btNextDay = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btAge = new System.Windows.Forms.Button();
            this.tbTime = new System.Windows.Forms.TextBox();
            this.tmTimeDisp = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "日付：";
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpDate.Location = new System.Drawing.Point(88, 9);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 31);
            this.dtpDate.TabIndex = 1;
            // 
            // btDayCalc
            // 
            this.btDayCalc.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btDayCalc.Location = new System.Drawing.Point(17, 46);
            this.btDayCalc.Name = "btDayCalc";
            this.btDayCalc.Size = new System.Drawing.Size(123, 47);
            this.btDayCalc.TabIndex = 2;
            this.btDayCalc.Text = "日数計算";
            this.btDayCalc.UseVisualStyleBackColor = true;
            this.btDayCalc.Click += new System.EventHandler(this.btDayCalc_Click);
            // 
            // tbMessage
            // 
            this.tbMessage.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbMessage.Location = new System.Drawing.Point(294, 9);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(271, 302);
            this.tbMessage.TabIndex = 3;
            // 
            // btbackYear
            // 
            this.btbackYear.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btbackYear.Location = new System.Drawing.Point(17, 153);
            this.btbackYear.Name = "btbackYear";
            this.btbackYear.Size = new System.Drawing.Size(112, 45);
            this.btbackYear.TabIndex = 4;
            this.btbackYear.Text = "ー年";
            this.btbackYear.UseVisualStyleBackColor = true;
            this.btbackYear.Click += new System.EventHandler(this.btbackYear_Click);
            // 
            // btBackMonth
            // 
            this.btBackMonth.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btBackMonth.Location = new System.Drawing.Point(17, 210);
            this.btBackMonth.Name = "btBackMonth";
            this.btBackMonth.Size = new System.Drawing.Size(112, 45);
            this.btBackMonth.TabIndex = 5;
            this.btBackMonth.Text = "ー月";
            this.btBackMonth.UseVisualStyleBackColor = true;
            this.btBackMonth.Click += new System.EventHandler(this.btBackMonth_Click);
            // 
            // btBackDay
            // 
            this.btBackDay.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btBackDay.Location = new System.Drawing.Point(17, 266);
            this.btBackDay.Name = "btBackDay";
            this.btBackDay.Size = new System.Drawing.Size(112, 45);
            this.btBackDay.TabIndex = 6;
            this.btBackDay.Text = "ー日";
            this.btBackDay.UseVisualStyleBackColor = true;
            this.btBackDay.Click += new System.EventHandler(this.btBackDay_Click);
            // 
            // btNextYear
            // 
            this.btNextYear.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btNextYear.Location = new System.Drawing.Point(143, 153);
            this.btNextYear.Name = "btNextYear";
            this.btNextYear.Size = new System.Drawing.Size(112, 45);
            this.btNextYear.TabIndex = 7;
            this.btNextYear.Text = "＋年";
            this.btNextYear.UseVisualStyleBackColor = true;
            this.btNextYear.Click += new System.EventHandler(this.btNextYear_Click);
            // 
            // btNextMonth
            // 
            this.btNextMonth.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btNextMonth.Location = new System.Drawing.Point(143, 210);
            this.btNextMonth.Name = "btNextMonth";
            this.btNextMonth.Size = new System.Drawing.Size(112, 45);
            this.btNextMonth.TabIndex = 8;
            this.btNextMonth.Text = "＋月";
            this.btNextMonth.UseVisualStyleBackColor = true;
            this.btNextMonth.Click += new System.EventHandler(this.btNextMonth_Click);
            // 
            // btNextDay
            // 
            this.btNextDay.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btNextDay.Location = new System.Drawing.Point(143, 266);
            this.btNextDay.Name = "btNextDay";
            this.btNextDay.Size = new System.Drawing.Size(112, 45);
            this.btNextDay.TabIndex = 9;
            this.btNextDay.Text = "＋日";
            this.btNextDay.UseVisualStyleBackColor = true;
            this.btNextDay.Click += new System.EventHandler(this.btNextDay_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(12, 340);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 27);
            this.label2.TabIndex = 10;
            this.label2.Text = "現在時刻：";
            // 
            // btAge
            // 
            this.btAge.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btAge.Location = new System.Drawing.Point(17, 99);
            this.btAge.Name = "btAge";
            this.btAge.Size = new System.Drawing.Size(123, 47);
            this.btAge.TabIndex = 11;
            this.btAge.Text = "年齢";
            this.btAge.UseVisualStyleBackColor = true;
            this.btAge.Click += new System.EventHandler(this.btAge_Click);
            // 
            // tbTime
            // 
            this.tbTime.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbTime.Location = new System.Drawing.Point(143, 340);
            this.tbTime.Multiline = true;
            this.tbTime.Name = "tbTime";
            this.tbTime.Size = new System.Drawing.Size(202, 27);
            this.tbTime.TabIndex = 12;
            // 
            // tmTimeDisp
            // 
            this.tmTimeDisp.Interval = 500;
            this.tmTimeDisp.Tick += new System.EventHandler(this.tmTimeDisp_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 387);
            this.Controls.Add(this.tbTime);
            this.Controls.Add(this.btAge);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btNextDay);
            this.Controls.Add(this.btNextMonth);
            this.Controls.Add(this.btNextYear);
            this.Controls.Add(this.btBackDay);
            this.Controls.Add(this.btBackMonth);
            this.Controls.Add(this.btbackYear);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.btDayCalc);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "カレンダーアプリ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btDayCalc;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Button btbackYear;
        private System.Windows.Forms.Button btBackMonth;
        private System.Windows.Forms.Button btBackDay;
        private System.Windows.Forms.Button btNextYear;
        private System.Windows.Forms.Button btNextMonth;
        private System.Windows.Forms.Button btNextDay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btAge;
        private System.Windows.Forms.TextBox tbTime;
        private System.Windows.Forms.Timer tmTimeDisp;
    }
}

