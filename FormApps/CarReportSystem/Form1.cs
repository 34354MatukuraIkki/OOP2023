using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace CarReportSystem {
    public partial class Form1 : Form {
        //管理用データ
        BindingList<CarReport> CarReports = new BindingList<CarReport>();

        //設定情報保存用オブジェクト
        Settings settings = new Settings();

        public Form1() {
            InitializeComponent();
            dgvCarReports.DataSource = CarReports;
        }

        private void Form1_Load(object sender, EventArgs e) {
            //tsTimer.Text = DateTime.Now.ToString("HH時mm分    ");
            timer.Start();
            dgvCarReports.Columns[5].Visible = false;   //画像項目非表示
            btModifiReport.Enabled = btDeleteReport.Enabled =
                btImageDelete.Enabled = btScaleChange.Enabled = false; //マスクする
            tsInfoText.Text = "ここにメッセージを表示できます。";

            //設定ファイルを逆シリアル化して背景を設定
            try {
                using (var reader = XmlReader.Create("settings.xml")) {
                    var serializer = new XmlSerializer(typeof(Settings));
                    settings = serializer.Deserialize(reader) as Settings;
                    BackColor = Color.FromArgb(settings.MainFormColor);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
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
                btModifiReport.Enabled = btDeleteReport.Enabled = false;
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
            clearItem();
            if (dgvCarReports.CurrentCell != null) {
                CarReports.RemoveAt(dgvCarReports.CurrentCell.RowIndex);
                if (dgvCarReports.CurrentCell == null) {
                    btModifiReport.Enabled = btDeleteReport.Enabled = false;
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
            if (ofdImageFileOpen.ShowDialog() == DialogResult.OK) {
                pbCarImage.Image = Image.FromFile(ofdImageFileOpen.FileName);
                btImageDelete.Enabled = btScaleChange.Enabled = true;
            }
        }

        //イメージ画像削除
        private void btImageDelete_Click(object sender, EventArgs e) {
            pbCarImage.Image = null;
            btImageDelete.Enabled = btScaleChange.Enabled = false;
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
            btModifiReport.Enabled = btDeleteReport.Enabled = true;
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
            if (cdColor.ShowDialog() == DialogResult.OK) {
                BackColor = cdColor.Color;
                settings.MainFormColor = cdColor.Color.ToArgb();
            }
        }

        private void timer_Tick(object sender, EventArgs e) {
            tsTimer.Text = DateTime.Now.ToString("HH時mm分    ");
        }

        //画像のサイズ変更
        private void btScaleChange_Click(object sender, EventArgs e) {
            //mode = mode < 4 ? ((mode == 1) ? 3 : ++mode) : 0; //AutoSize(2)を除外 
            int mode = (int)pbCarImage.SizeMode;
            if (++mode > 4) mode = 0;
            if (mode == 2) ++mode;  //AutoSize(2)を除外
            pbCarImage.SizeMode = (PictureBoxSizeMode)mode;
        }

        //終了メニュー選択時のイベントハンドラ
        private void 終了XToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            //設定ファイルのシリアル化
            using(var writer = XmlWriter.Create("settings.xml")) {
                var serializer = new XmlSerializer(settings.GetType());
                serializer.Serialize(writer, settings);
            }
        }

        private void 保存SToolStripMenuItem_Click(object sender, EventArgs e) {
            if (sfdCarRepoSave.ShowDialog() == DialogResult.OK) {
                try {

                    //バイナリ形式でシリアル化
                    var bf = new BinaryFormatter();
                    using (FileStream fs = File.Open(sfdCarRepoSave.FileName, FileMode.Create)) {
                        bf.Serialize(fs, CarReports);
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void 開くOToolStripMenuItem_Click(object sender, EventArgs e) {
            if(ofdCarRepoOpen.ShowDialog() == DialogResult.OK) {
                try {
                    //逆シリアル化でバイナリ形式を取り込む
                    var bf = new BinaryFormatter();
                    using (FileStream fs = File.Open(ofdCarRepoOpen.FileName, FileMode.Open, FileAccess.Read)) {
                        CarReports = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvCarReports.DataSource = null;
                        dgvCarReports.DataSource = CarReports;
                        dgvCarReports.CurrentCell.Selected = false;
                        dgvCarReports.Columns[5].Visible = false;
                        cbAuthor.Items.Clear();
                        cbCarName.Items.Clear();
                        clearItem();
                        foreach (var item in CarReports) {
                            addCbAuthor(item.Author);
                            addCbCarName(item.CarName);
                        }
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
