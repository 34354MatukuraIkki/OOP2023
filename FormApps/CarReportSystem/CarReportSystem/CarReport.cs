﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReportSystem {
    public class CarReport {
        [System.ComponentModel.DisplayName("日付")]
        public DateTime Date { get; set; }  //日付

        public string Author { get; set; }  //記録者
        public MakerGroup Maker { get; set; }   //メーカー
        public string CarName { get; set; } //車名
        public string Report { get; set; }  //レポート
        public Image CarImage { get; set; } //画像

        //メーカー一覧【列挙型】
        public enum MakerGroup {
            トヨタ,
            日産,
            ホンダ,
            スバル,
            スズキ,
            ダイハツ,
            輸入車,
            その他,
        }
    }
}
