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
        Settings settings = Settings.getinstance();

        public Form1() {
            InitializeComponent();
            //dgvCarReports.DataSource = CarReports;
        }

        private void Form1_Load(object sender, EventArgs e) {

            //tsTimer.Text = DateTime.Now.ToString("HH時mm分    ");
            timer.Start();
            dgvCarReports.Columns[6].Visible = false;   //画像項目非表示
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

            DataRow newRow = infosys202334DataSet.CarReportTable.NewRow();
            newRow[1] = dtpDate.Value;
            newRow[2] = cbAuthor.Text;
            newRow[3] = getSelectedMaker();
            newRow[4] = cbCarName.Text;
            newRow[5] = tbReport.Text;
            newRow[6] = ImageToByteArray(pbCarImage.Image);

            infosys202334DataSet.CarReportTable.Rows.Add(newRow);
            this.carReportTableTableAdapter.Update(infosys202334DataSet.CarReportTable);

            addCbAuthor(cbAuthor.Text);
            addCbCarName(cbCarName.Text);
            clearItem();
            dgvCarReports.CurrentCell.Selected = false;
            btImageDelete.Enabled = btScaleChange.Enabled = false;
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
            dgvCarReports.CurrentRow.Cells[1].Value = dtpDate.Value;
            dgvCarReports.CurrentRow.Cells[2].Value = cbAuthor.Text;
            dgvCarReports.CurrentRow.Cells[3].Value = getSelectedMaker();
            dgvCarReports.CurrentRow.Cells[4].Value = cbCarName.Text;
            dgvCarReports.CurrentRow.Cells[5].Value = tbReport.Text;
            dgvCarReports.CurrentRow.Cells[6].Value = pbCarImage.Image;

            this.Validate();
            this.carReportTableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.infosys202334DataSet);
        }

        //削除ボタンイベントハンドラ
        private void btDeleteReport_Click(object sender, EventArgs e) {
            dgvCarReports.Rows.RemoveAt(dgvCarReports.CurrentCell.RowIndex);
            this.carReportTableTableAdapter.Update(infosys202334DataSet.CarReportTable);
            clearItem();
            btImageDelete.Enabled = btScaleChange.Enabled = false;
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
        private void setSelectedMaker(string makerGroup) {
            switch (makerGroup) {
                case "トヨタ":
                    rbToyota.Checked = true;
                    break;
                case "日産":
                    rbNissan.Checked = true;
                    break;
                case "ホンダ":
                    rbHonda.Checked = true;
                    break;
                case "輸入車":
                    rbImported.Checked = true;
                    break;
                case "スバル":
                    rbSubaru.Checked = true;
                    break;
                case "スズキ":
                    rbSuzuki.Checked = true;
                    break;
                case "ダイハツ":
                    rbDaihatsu.Checked = true;
                    break;
                case "その他":
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
                dtpDate.Value = (DateTime)dgvCarReports.CurrentRow.Cells[1].Value;
                cbAuthor.Text = dgvCarReports.CurrentRow.Cells[2].Value.ToString();
                setSelectedMaker(dgvCarReports.CurrentRow.Cells[3].Value.ToString());
                cbCarName.Text = dgvCarReports.CurrentRow.Cells[4].Value.ToString();
                tbReport.Text = dgvCarReports.CurrentRow.Cells[5].Value.ToString();

                pbCarImage.Image = !dgvCarReports.CurrentRow.Cells[6].Value.Equals(DBNull.Value)
                    && ((Byte[])dgvCarReports.CurrentRow.Cells[6].Value).Length != 0 ?
                    ByteArrayToImage((Byte[])dgvCarReports.CurrentRow.Cells[6].Value) : null;
                btImageDelete.Enabled = btScaleChange.Enabled = true;
                //if (!dgvCarReports.CurrentRow.Cells[6].Value.Equals(DBNull.Value)) {
                //    pbCarImage.Image = ByteArrayToImage((Byte[])dgvCarReports.CurrentRow.Cells[6].Value);
                //    btImageDelete.Enabled = btScaleChange.Enabled = true;
                //}
                //else {
                //    pbCarImage.Image = null;
                //    btImageDelete.Enabled = btScaleChange.Enabled = false;
                //}
            }
            btModifiReport.Enabled = btDeleteReport.Enabled = true;
        }

        // バイト配列をImageオブジェクトに変換
        public static Image ByteArrayToImage(byte[] b) {
            ImageConverter imgconv = new ImageConverter();
            Image img = (Image)imgconv.ConvertFrom(b);
            return img;
        }

        // Imageオブジェクトをバイト配列に変換
        public static byte[] ImageToByteArray(Image img) {
            ImageConverter imgconv = new ImageConverter();
            byte[] b = (byte[])imgconv.ConvertTo(img, typeof(byte[]));
            return b;
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
            using (var writer = XmlWriter.Create("settings.xml")) {
                var serializer = new XmlSerializer(settings.GetType());
                serializer.Serialize(writer, settings);
            }
        }

        private void carReportTableBindingNavigatorSaveItem_Click(object sender, EventArgs e) {
            this.Validate();
            this.carReportTableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.infosys202334DataSet);
        }

        private void 接続NToolStripMenuItem_Click(object sender, EventArgs e) {
            dbConeection();
        }

        private void dbConeection() {
            // TODO: このコード行はデータを 'infosys202334DataSet.CarReportTable' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            this.carReportTableTableAdapter.Fill(this.infosys202334DataSet.CarReportTable);
            dgvCarReports.ClearSelection();     //選択解除
            foreach (var CarReport in infosys202334DataSet.CarReportTable) {
                addCbAuthor(CarReport.Author);
                addCbCarName(CarReport.CarName);
            }
        }

        private void btAuthorSearch_Click(object sender, EventArgs e) {
            if (tbAuthorSearch.Text.Equals("")) {
                statusLabelDisp("記録者を入力してください");
                return;
            } else {
            carReportTableTableAdapter.FillByAuthor(this.infosys202334DataSet.CarReportTable, tbAuthorSearch.Text);
            }
        }

        private void btCarNameSearch_Click(object sender, EventArgs e) {
            if (tbCarNameSearch.Text.Equals("")) {
                statusLabelDisp("車名を入力してください");
                return;
            } else {
            carReportTableTableAdapter.FillByCarName(this.infosys202334DataSet.CarReportTable, tbCarNameSearch.Text);
            }
        }

        private void btDateSearch_Click(object sender, EventArgs e) {
            carReportTableTableAdapter.FillByBetweenDate(this.infosys202334DataSet.CarReportTable, dtpBeforeDateSearch.Text,dtpAfterDateSearch.Text);
        }

        private void btReset_Click(object sender, EventArgs e) {            
            this.carReportTableTableAdapter.Fill(this.infosys202334DataSet.CarReportTable);
            dgvCarReports.ClearSelection();     //選択解除
        }
    }
}
