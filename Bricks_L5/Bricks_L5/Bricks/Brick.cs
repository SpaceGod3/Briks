using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bricks {
    class Brick : Block {

        public bool IsTarget = false;

        public bool IsHitted = false;

        public Brick(int left, int top, ConsoleColor color)
            : base(left, top, color) { }
        public Brick(int left, int top)
            : base(left, top) { }
    }
}
