using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalendarApp {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btDayCalc_Click(object sender, EventArgs e) {
            var dtp = dtpDate.Value;
            TimeSpan time = DateTime.Now - dtp;

            tbMessage.Text = "入力した日にちから今日まで" + time.Days.ToString() +"日";
        }

        private void btbackYear_Click(object sender, EventArgs e) {
            dtpDate.Value = dtpDate.Value.AddYears(-1);
        }
        private void btBackMonth_Click(object sender, EventArgs e) {
            dtpDate.Value = dtpDate.Value.AddMonths(-1);
        }
        private void btBackDay_Click(object sender, EventArgs e) {
            dtpDate.Value = dtpDate.Value.AddDays(-1);
        }
        private void btNextYear_Click(object sender, EventArgs e) {
            dtpDate.Value = dtpDate.Value.AddYears(1);
        }
        private void btNextMonth_Click(object sender, EventArgs e) {
            dtpDate.Value = dtpDate.Value.AddMonths(1);
        }
        private void btNextDay_Click(object sender, EventArgs e) {
            dtpDate.Value = dtpDate.Value.AddDays(1);
        }

        private void btAge_Click(object sender, EventArgs e) {
            var age = GetAge(dtpDate.Value, DateTime.Today);
            tbMessage.Text = "あなたの年齢は" + age + "歳です";
        }

        public static int GetAge(DateTime birthday,DateTime targetDay) {
            var age = targetDay.Year - birthday.Year;
            if (targetDay < birthday.AddYears(age))
                age--;
            return age;
        }

        private void Form1_Load(object sender, EventArgs e) {
            tbTime.Text = DateTime.Now.ToString("HH時mm分ss秒");
            tmTimeDisp.Start();
        }

        //タイマーイベントハンドラー
        private void tmTimeDisp_Tick(object sender, EventArgs e) {
            tbTime.Text = DateTime.Now.ToString("HH時mm分ss秒");
        }
    }
}
