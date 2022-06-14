using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bricks.Collisions {
    class CollisionHandler : ICollisionHandler {
        public bool CheckAndHandleCollision(Ball ball, Block block) {
            if (ball.Y == block.Top && ball.X >= block.Left && ball.X <= block.Right) {
                ball.Dy = -ball.Dy;
                return true;
            }
            return false;
        }


        public void CheckAndHandleCollisions(Ball ball, Brick[] bricks) {
            //throw new NotImplementedException();
            foreach (Brick brick in bricks) {
                if (brick.IsHitted)
                    continue;
                if (ball.CheckAndHandleCollision(brick)) {
                    if (brick.IsTarget) {
                        brick.IsHitted = true;
                        brick.Erase();
                        //targets.Remove(brick);
                        //if (targets.Count == 0) {
                        //    CompleteLevel();
                        //}
                    }
                    //else {
                    //    //hittedBricks.Add(brick);
                    //}
                    OnHit(new HitEventArgs(brick));
                }
            }
        }


        public event EventHandler<HitEventArgs> Hit;

        protected void OnHit(HitEventArgs eventArgs) {
            if (Hit != null) {
                Hit(this, eventArgs);
            }
        }
    }
}
