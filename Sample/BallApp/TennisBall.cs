using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallApp {
    class TennisBall : Obj {
        private static int count;
        Random random = new Random();   //乱数インスタンス

        public static int Count { get => count; set => count = value; }

        public TennisBall(double mousePosX,double mousePosY)
            : base(mousePosX, mousePosY, @"pic\tennis_ball.png") {
            int speedX = random.Next(-20, 20);
            int speedY = random.Next(-20, 20);
            if (speedX == 0)
                speedX = random.Next(1, 20);
            if (speedY == 0)
                speedY = random.Next(1, 20);

            MoveX = speedX;
            MoveY = speedY;

            Count++;
        }

        public override void Move() {
            if (PosX > 730 || PosX < 0)     //X座標の壁判定
                MoveX *= -1;
            if (PosY > 500 || PosY < 0)     //Y座標の壁判定
                MoveY *= -1;

            PosX += MoveX;
            PosY += MoveY;
        }
    }
}
