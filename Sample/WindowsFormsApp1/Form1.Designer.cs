﻿
namespace WindowsFormsApp1 {
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
            if (disposing && (components != null))
            {
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
            this.btButton = new System.Windows.Forms.Button();
            this.tbNum1 = new System.Windows.Forms.TextBox();
            this.tbNum2 = new System.Windows.Forms.TextBox();
            this.tbAns = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudX = new System.Windows.Forms.NumericUpDown();
            this.nudY = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.btPow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).BeginInit();
            this.SuspendLayout();
            // 
            // btButton
            // 
            this.btButton.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btButton.Location = new System.Drawing.Point(662, 116);
            this.btButton.Name = "btButton";
            this.btButton.Size = new System.Drawing.Size(126, 74);
            this.btButton.TabIndex = 0;
            this.btButton.Text = "計算";
            this.btButton.UseVisualStyleBackColor = true;
            this.btButton.Click += new System.EventHandler(this.btButton_Click);
            // 
            // tbNum1
            // 
            this.tbNum1.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbNum1.Location = new System.Drawing.Point(141, 46);
            this.tbNum1.Name = "tbNum1";
            this.tbNum1.Size = new System.Drawing.Size(126, 34);
            this.tbNum1.TabIndex = 1;
            // 
            // tbNum2
            // 
            this.tbNum2.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbNum2.Location = new System.Drawing.Point(346, 46);
            this.tbNum2.Name = "tbNum2";
            this.tbNum2.Size = new System.Drawing.Size(126, 34);
            this.tbNum2.TabIndex = 1;
            // 
            // tbAns
            // 
            this.tbAns.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbAns.Location = new System.Drawing.Point(535, 46);
            this.tbAns.Name = "tbAns";
            this.tbAns.Size = new System.Drawing.Size(126, 34);
            this.tbAns.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(292, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "+";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(494, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "=";
            // 
            // nudX
            // 
            this.nudX.Font = new System.Drawing.Font("MS UI Gothic", 20F);
            this.nudX.Location = new System.Drawing.Point(57, 250);
            this.nudX.Name = "nudX";
            this.nudX.Size = new System.Drawing.Size(120, 34);
            this.nudX.TabIndex = 3;
            
            // 
            // nudY
            // 
            this.nudY.Font = new System.Drawing.Font("MS UI Gothic", 20F);
            this.nudY.Location = new System.Drawing.Point(260, 252);
            this.nudY.Name = "nudY";
            this.nudY.Size = new System.Drawing.Size(120, 34);
            this.nudY.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 20F);
            this.label3.Location = new System.Drawing.Point(206, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 27);
            this.label3.TabIndex = 4;
            this.label3.Text = "の";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 20F);
            this.label4.Location = new System.Drawing.Point(410, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 27);
            this.label4.TabIndex = 4;
            this.label4.Text = "乗は";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 20F);
            this.label5.Location = new System.Drawing.Point(622, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 27);
            this.label5.TabIndex = 4;
            this.label5.Text = "です。";
            // 
            // tbResult
            // 
            this.tbResult.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbResult.Location = new System.Drawing.Point(478, 249);
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(126, 34);
            this.tbResult.TabIndex = 1;
            // 
            // btPow
            // 
            this.btPow.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btPow.Location = new System.Drawing.Point(662, 282);
            this.btPow.Name = "btPow";
            this.btPow.Size = new System.Drawing.Size(126, 74);
            this.btPow.TabIndex = 0;
            this.btPow.Text = "計算";
            this.btPow.UseVisualStyleBackColor = true;
            this.btPow.Click += new System.EventHandler(this.btPow_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(800, 366);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudY);
            this.Controls.Add(this.nudX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.tbAns);
            this.Controls.Add(this.tbNum2);
            this.Controls.Add(this.tbNum1);
            this.Controls.Add(this.btPow);
            this.Controls.Add(this.btButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btButton;
        private System.Windows.Forms.TextBox tbNum1;
        private System.Windows.Forms.TextBox tbNum2;
        private System.Windows.Forms.TextBox tbAns;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudX;
        private System.Windows.Forms.NumericUpDown nudY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Button btPow;
    }
}

