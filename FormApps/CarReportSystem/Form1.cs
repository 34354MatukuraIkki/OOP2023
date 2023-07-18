using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarReportSystem {
    public partial class Form1 : Form {
        //管理用データ
        BindingList<CarReport> CarReports = new BindingList<CarReport>();

        public Form1() {
            InitializeComponent();
            dgvCarReports.DataSource = CarReports;
        }
        
        private void Form1_Load(object sender, EventArgs e) {
            tsTimer.Text = DateTime.Now.ToString("HH時mm分：");
            timer.Start();
            dgvCarReports.Columns[5].Visible = false;   //画像項目非表示
            btModifiReport.Enabled = false; //マスクする
            btDeleteReport.Enabled = false;
            tsInfoText.Text = "ここにメッセージを表示できます。";
        }

        //追加ボタンがクリックされた時のイベントハンドラー
        private void btAddReport_Click(object sender, EventArgs e) {
            statusLabelDisp();  //ステータスラベルのテキスト非表示
            if (cbAuthor.Text.Equals("")) {
                statusLabelDisp("記録者を入力してください");
                return;
            }
            else if (cbCarName.Text.Equals("")) {
                statusLabelDisp("車名を入力してください");
                return;
            }

            var carReport = new CarReport
            {
                Date = dtpDate.Value,
                Author = cbAuthor.Text,
                Maker = getSelectedMaker(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                CarImage = pbCarImage.Image,
            };
            CarReports.Add(carReport);
            addCbAuthor(cbAuthor.Text);
            addCbCarName(cbCarName.Text);
            clearItem();
            dgvCarReports.CurrentCell.Selected = false;
        }

        //コンボボックスに記録者を登録
        private void addCbAuthor(string author) {
            if (!cbAuthor.Items.Contains(author))
                cbAuthor.Items.Add(author);
        }

        //コンボボックスに車名を登録
        private void addCbCarName(string carname) {
            if (!cbCarName.Items.Contains(carname))
                cbCarName.Items.Add(carname);
        }

        //日付以外の項目を非表示
        private void clearItem() {
            cbAuthor.Text = null;
            foreach (var item in gbMaker.Controls) {
                ((RadioButton)item).Checked = false;
            }
            cbCarName.Text = null;
            tbReport.Text = null;
            pbCarImage.Image = null;
        }

        //修正ボタンイベントハンドラ
        private void btModifiReport_Click(object sender, EventArgs e) {
            if (dgvCarReports.CurrentCell != null) {
                var modifiTarget = dgvCarReports.CurrentCell.RowIndex;
                var carReport = new CarReport
                {
                    Date = dtpDate.Value,
                    Author = cbAuthor.Text,
                    Maker = getSelectedMaker(),
                    CarName = cbCarName.Text,
                    Report = tbReport.Text,
                    CarImage = pbCarImage.Image,
                };
                CarReports.RemoveAt(modifiTarget);
                CarReports.Insert(modifiTarget, carReport);
                btModifiReport.Enabled = false;
                btDeleteReport.Enabled = false;
                dgvCarReports.CurrentCell.Selected = false;
                clearItem();
                //CarReports[dgvCarReports.CurrentRow.Index].Date = dtpDate.Value;
                //CarReports[dgvCarReports.CurrentRow.Index].Author = cbAuthor.Text;
                //CarReports[dgvCarReports.CurrentRow.Index].Maker = getSelectedMaker();
                //CarReports[dgvCarReports.CurrentRow.Index].CarName = cbCarName.Text;
                //CarReports[dgvCarReports.CurrentRow.Index].Report = tbReport.Text;
                //CarReports[dgvCarReports.CurrentRow.Index].CarImage = pbCarImage.Image;
                //dgvCarReports.Refresh();    //一覧更新
            }
        }

        //削除ボタンイベントハンドラ
        private void btDeleteReport_Click(object sender, EventArgs e) {
            if (dgvCarReports.CurrentCell != null) {
                CarReports.RemoveAt(dgvCarReports.CurrentCell.RowIndex);
                if (dgvCarReports.CurrentCell == null) {
                    btModifiReport.Enabled = false;
                    btDeleteReport.Enabled = false;
                }
            }
        }

        //ラジオボタンで選択されているメーカーを返却
        private CarReport.MakerGroup getSelectedMaker() {
            foreach (var item in gbMaker.Controls) {
                if (((RadioButton)item).Checked) {
                    return (CarReport.MakerGroup)int.Parse(((RadioButton)item).Tag.ToString());
                }
            }
            return CarReport.MakerGroup.その他;
        }

        //指定したメーカーのラジオボタンをセット
        private void setSelectedMaker(CarReport.MakerGroup makerGroup) {
            switch (makerGroup) {
                case CarReport.MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakerGroup.輸入車:
                    rbImported.Checked = true;
                    break;
                case CarReport.MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakerGroup.スズキ:
                    rbSuzuki.Checked = true;
                    break;
                case CarReport.MakerGroup.ダイハツ:
                    rbDaihatsu.Checked = true;
                    break;
                case CarReport.MakerGroup.その他:
                    rbOther.Checked = true;
                    break;
            }
        }

        //イメージ画像をファイルから追加
        private void btImageOpen_Click(object sender, EventArgs e) {
            ofdImageFileOpen.ShowDialog();
            pbCarImage.Image = Image.FromFile(ofdImageFileOpen.FileName);
        }

        //イメージ画像削除
        private void btImageDelete_Click(object sender, EventArgs e) {
            pbCarImage.Image = null;
        }

        //レコードの選択時
        private void dgvCarReports_Click(object sender, EventArgs e) {
            if (dgvCarReports.CurrentCell != null) {
                dtpDate.Value = (DateTime)dgvCarReports.CurrentRow.Cells[0].Value;
                cbAuthor.Text = dgvCarReports.CurrentRow.Cells[1].Value.ToString();
                setSelectedMaker((CarReport.MakerGroup)dgvCarReports.CurrentRow.Cells[2].Value);
                cbCarName.Text = dgvCarReports.CurrentRow.Cells[3].Value.ToString();
                tbReport.Text = dgvCarReports.CurrentRow.Cells[4].Value.ToString();
                pbCarImage.Image = (Image)dgvCarReports.CurrentRow.Cells[5].Value;
            }
            btModifiReport.Enabled = true;
            btDeleteReport.Enabled = true;
        }

        //ステータスラベルのテキスト表示・引数なしは非表示
        private void statusLabelDisp(string msg = "") {
            tsInfoText.Text = msg;
        }

        private void バージョン情報ToolStripMenuItem_Click(object sender, EventArgs e) {
            var vf = new VersionForm();
            vf.ShowDialog();    //モーダルダイヤログとして表示
        }
        
        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            cdColor.ShowDialog();
            this.BackColor = cdColor.Color;
        }

        //終了メニュー選択時のイベントハンドラ
        private void 終了XToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void timer_Tick(object sender, EventArgs e) {
            tsTimer.Text = DateTime.Now.ToString("HH時mm分：");
        }
    }
}
