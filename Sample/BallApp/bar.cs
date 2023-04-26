using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallApp {
    class Bar : Obj {

        public Bar(double PosX, double PosY)
            : base(PosX, PosY, @"pic\bar.png") {
            MoveX = 10;
            MoveY = 0;
        }
        //抽象クラスを継承しているので、不要なメソッドを空にする
        public override void Move(PictureBox pbBar, PictureBox pbBall) {
        }

        public override void Move(Keys direction) {
            if (direction == Keys.Left)
                if (PosX < 635)
                    PosX -= MoveX;
                else if (direction == Keys.Right)
                    if (PosX < 0)
                        PosX += MoveX;
        }
    }
}
