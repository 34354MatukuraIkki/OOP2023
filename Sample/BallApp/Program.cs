using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallApp {
    class Program :Form{
        Bar bar;                                //バーインスタンス格納
        PictureBox barPb;                       //バー画像を表示するコントロール
        private Timer   moveTimer;              //タイマー用

        //リストコレクション
        private List<Obj>           balls   = new List<Obj>();              //ボールインスタンス格納用 
        private List<PictureBox>    pbs     = new List<PictureBox>();       //表示用

        static void Main(string[] args) {
            Application.Run(new Program());
        }

        public Program() {
            this.Size           = new Size(800, 600);
            this.BackColor      = Color.Blue;
            this.Text           = "BallGame";
            this.MouseClick     += Program_MouseClick;
            this.KeyDown        += Program_KeyDown;

            //バーインスタンス生成
            bar                 = new Bar(340,500);
            barPb               = new PictureBox();
            barPb.Size          = new Size(150, 10);
            barPb.Image         = bar.Image;
            barPb.Location      = new Point((int)bar.PosX, (int)bar.PosY);    //画像の位置
            barPb.SizeMode      = PictureBoxSizeMode.StretchImage;            //画像の表示モード
            barPb.Parent        = this;

            //タイマーの生成
            moveTimer           = new Timer();
            moveTimer.Interval  = 20;               //タイマーのインターバル（ｍｓ）   
            moveTimer.Tick      += MoveTimer_Tick;  //デリゲート登録
        }

        //キーが押された時のイベントハンドラ
        private void Program_KeyDown(object sender, KeyEventArgs e) {
            bar.Move(e.KeyData);
            barPb.Location = new Point((int)bar.PosX, (int)bar.PosY);
        }

        //マウスクリック時のイベントハンドラ
        private void Program_MouseClick(object sender, MouseEventArgs e) {
            Obj ballObj = null;
            PictureBox pb = new PictureBox();
            //ボールインスタンス生成
            if (e.Button == MouseButtons.Left)
            {
                pb.Size = new Size(50, 50);                                             //画像の表示サイズ
                ballObj = new SoccerBall(e.X - 25, e.Y - 25);}
            else if (e.Button == MouseButtons.Right)
            {
                pb.Size = new Size(30, 30);                                             //画像の表示サイズ
                ballObj = new TennisBall(e.X - 15, e.Y - 15);
            }

            pb.Image        = ballObj.Image;
            pb.Location     = new Point((int)ballObj.PosX, (int)ballObj.PosY);          //画像の位置
            pb.SizeMode     = PictureBoxSizeMode.StretchImage;                          //画像の表示モード
            pb.Parent       = this;
            balls.Add(ballObj);                                                         //ボールをリストに追加
            pbs.Add(pb);                                                                //画像をリストに追加

            this.Text = "BallGame"          + balls.Count                               //ボールの個数表示
                      + "　サッカーボール"  + SoccerBall.Count
                      + "　テニスボール"    + TennisBall.Count;
           
            moveTimer.Start();                                                          //タイマースタート
        }

        //タイマータイムアウト時のイベントハンドラ
        private void MoveTimer_Tick(object sender, EventArgs e) {
            for (int i = 0; i < balls.Count; i++)
            {
                balls[i].Move(barPb, pbs[i]);                                           //移動
                pbs[i].Location = new Point((int)balls[i].PosX, (int)balls[i].PosY);    //画像の位置
            }
        }
    }
}
