using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bricks {
    class Ball : IDrawable, IMovable {
        public int X;
        public int Y;
        public int Dx;
        public int Dy;
        public ConsoleColor Color = ConsoleColor.Red;
        public Area Area;

        public void Draw() {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(X, Y);
            Console.Write('●'); // '\u25CF'
        }

        public void Erase() {
            Console.SetCursorPosition(X, Y);
            Console.Write(' '); 
        }



        public void Move() {
            Erase();
            X += Dx;
            Y += Dy;
            if (X < 0 || X >= Area.Width) {
                Dx = -Dx;
                X += Dx;
            }
            if (Y < 0) {
                Dy = -Dy;
                Y += Dy;
            }
            if (Y >= Area.Height) {
                Y = Area.Height - 1;
                Dy = 0;
                Dx = 0;
                OnLoss(EventArgs.Empty);
            }
            Draw();
        }

        public event EventHandler<EventArgs> Loss;

        protected void OnLoss(EventArgs args) {
            if (Loss != null) {
                Loss(this, args);
            }
        }


        public bool CheckAndHandleCollision(Block block) {
            if (this.Y == block.Top && X >= block.Left && X <= block.Right) {
                Dy = -Dy;
                return true;
            }
            return false;
        }



    }
}
