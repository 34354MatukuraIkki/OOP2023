﻿using System;
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

        //追加ボタンがクリックされた時のイベントハンドラー
        private void btAddReport_Click(object sender, EventArgs e) {
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
            btModifiReport.Enabled = true;
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
        private CarReport.MakerGroup setSelectedMaker(CarReport.MakerGroup makerGroup) {
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
            return CarReport.MakerGroup.その他;
        }

        private void btImageOpen_Click(object sender, EventArgs e) {
            ofdImageFileOpen.ShowDialog();
            pbCarImage.Image = Image.FromFile(ofdImageFileOpen.FileName);
        }

        //削除ボタンイベントハンドラ
        private void btDeleteReport_Click(object sender, EventArgs e) {
            CarReports.RemoveAt(dgvCarReports.CurrentCell.RowIndex);
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
                
                //CarReports[dgvCarReports.CurrentRow.Index].Date = dtpDate.Value;
                //CarReports[dgvCarReports.CurrentRow.Index].Author = cbAuthor.Text;
                //CarReports[dgvCarReports.CurrentRow.Index].Maker = getSelectedMaker();
                //CarReports[dgvCarReports.CurrentRow.Index].CarName = cbCarName.Text;
                //CarReports[dgvCarReports.CurrentRow.Index].Report = tbReport.Text;
                //CarReports[dgvCarReports.CurrentRow.Index].CarImage = pbCarImage.Image;
                //dgvCarReports.Refresh();    //一覧更新
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            dgvCarReports.Columns[5].Visible = false;   //画像項目非表示
            btModifiReport.Enabled = false; //マスクする
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
        }
    }
}
