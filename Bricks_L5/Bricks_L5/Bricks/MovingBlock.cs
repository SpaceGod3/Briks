using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bricks {
    class MovingBlock : Block, IMovable {
        public int Dx;
        public int Dy;
        public Area Area;

        public MovingBlock(int left, int top, int width,
            ConsoleColor color, int dx, int dy)
            : base(left, top, width, color) {
                Dx = dx;
                Dy = dy;
        }

        public void Move() {
            Erase();
            Left += Dx;
            //Top += Dy;
            if (Left < 0) {
                //Dx = -Dx;
                Dx = 0;
                Left = 0;
            }
            if (Right >= Area.Width) {
                //Dx = -Dx;
                Dx = 0;
                Left = Area.Width - Width;
            }
            Draw();
        }
    }
}
