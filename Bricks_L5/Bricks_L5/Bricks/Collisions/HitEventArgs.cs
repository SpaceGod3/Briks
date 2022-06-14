using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bricks.Collisions {
    class HitEventArgs : EventArgs {
        public readonly Brick Brick;

        public HitEventArgs(Brick brick) {
            this.Brick = brick;
        }
    }
}
