using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallApp {
    class Program :Form{
        private Timer   moveTimer;    //タイマー用
        SoccerBall      soccerBall;
        TennisBall      tennisBall;
        PictureBox      pb;           //画像を表示するコントロール
        
        private int ballCount               = 0;                            //ボールカウンター
        private List<Obj>           balls   = new List<Obj>();              //ボールインスタンス格納用 
        private List<PictureBox>    pbs     = new List<PictureBox>();       //表示用


        static void Main(string[] args) {
            Application.Run(new Program());
        }

        public Program() {
            //this.Width = 1200;  //幅プロパティ
            //this.Height = 800;  //高さプロパティ
            this.Size           = new Size(800, 600);
            this.BackColor      = Color.Blue;
            this.Text           = "BallGame";
            this.MouseClick     += Program_MouseClick;
            
            moveTimer           = new Timer();
            moveTimer.Interval  = 20;               //タイマーのインターバル（ｍｓ）   
            moveTimer.Tick      += MoveTimer_Tick;  //デリゲート登録
        }

        //マウスクリック時のイベントハンドラ
        private void Program_MouseClick(object sender, MouseEventArgs e) {
            //ボールインスタンス生成
            pb              = new PictureBox();
            pb.SizeMode     = PictureBoxSizeMode.StretchImage;                          //画像の表示モード
            pb.Parent       = this;

            if (e.Button == MouseButtons.Left)
            {
                pb.Size = new Size(50, 50);                                             //画像の表示サイズ
                soccerBall = new SoccerBall(e.X - 25, e.Y - 25);
                pb.Image = soccerBall.Image;
                pb.Location = new Point((int)soccerBall.PosX, (int)soccerBall.PosY);    //画像の位置
                balls.Add(soccerBall);                                                  //サッカーボールをリストに追加
            }
            else if (e.Button == MouseButtons.Right)
            {
                pb.Size = new Size(30, 30);                                             //画像の表示サイズ
                tennisBall = new TennisBall(e.X - 15, e.Y - 15);
                pb.Image = tennisBall.Image;
                pb.Location = new Point((int)tennisBall.PosX, (int)tennisBall.PosY);    //画像の位置
                balls.Add(tennisBall);                                                  //テニスボールをリストに追加
            }

            pbs.Add(pb);                                                                //画像をリストに追加

            this.Text       = "BallGame" + (++ballCount);                               //ボールの個数表示
            //this.Text = "BallGame" + balls.Count;                                     //ボールの個数表示

            moveTimer.Start();                                                          //タイマースタート
        }

        //タイマータイムアウト時のイベントハンドラ
        private void MoveTimer_Tick(object sender, EventArgs e) {
            for (int i = 0; i < balls.Count; i++)
            {
                balls[i].Move();                                                        //移動
                pbs[i].Location = new Point((int)balls[i].PosX, (int)balls[i].PosY);    //画像の位置
            }
        }
    }
}
