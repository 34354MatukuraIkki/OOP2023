﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallApp {
    class Program :Form{
        private Timer moveTimer;                        //タイマー用
        SoccerBall soccerBall   = new SoccerBall();
        PictureBox pb           = new PictureBox();     //画像を表示するコントロール

        static void Main(string[] args) {
            Application.Run(new Program());
        }

        public Program() {
            //this.Width = 1200;  //幅プロパティ
            //this.Height = 800;  //高さプロパティ
            this.Size       = new Size(800, 600);
            this.BackColor  = Color.Blue;
            this.Text       = "BallGame";
            
            //ボールインスタンス生成
            pb.Image = soccerBall.Image;
            pb.Location = new Point((int)soccerBall.PosX, (int)soccerBall.PosY);    //画像の位置
            pb.Size     = new Size(50, 50);                                         //画像の表示サイズ
            pb.SizeMode = PictureBoxSizeMode.StretchImage;                          //画像の表示モード
            
            pb.Parent = this;
            
            moveTimer           = new Timer();
            moveTimer.Interval  = 20;               //タイマーのインターバル（ｍｓ）   
            moveTimer.Start();                      //タイマースタート
            moveTimer.Tick      += MoveTimer_Tick;
        }

        private void MoveTimer_Tick(object sender, EventArgs e) {
            soccerBall.Move();      //移動
            pb.Location = new Point((int)soccerBall.PosX, (int)soccerBall.PosY);    //画像の位置
        }
    }
}
