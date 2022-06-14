using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bricks.Collisions {
    interface ICollisionHandler {
        bool CheckAndHandleCollision(Ball ball, Block block);

        void CheckAndHandleCollisions(Ball ball, Brick[] bricks);

        event EventHandler<HitEventArgs> Hit;
    }
}
