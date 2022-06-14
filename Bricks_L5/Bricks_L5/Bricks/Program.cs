using Bricks.Collisions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bricks {
    class Program {

        static Game game;
        static CollisionHandler collisionHandler; 

        static void Main(string[] args) {
            Console.OutputEncoding = Encoding.Unicode;
            //new Game().Run();
            collisionHandler = new CollisionHandler();
            game = new Game(collisionHandler);
            game.Run();
        }

    }
}
