using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bricks {
    partial class Game {

        static int[, ,] maps =
        {
            {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 2, 0, 0, 0 },
            },
            {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 2, 0, 2, 0, 0, 0, 0, 2, 0, 2 },
                { 0, 2, 0, 0, 0, 0, 0, 0, 2, 0 },
                { 0, 0, 0, 0, 2, 2, 0, 0, 0, 0 },
                { 0, 0, 0, 2, 0, 0, 2, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 1, 1, 0, 1, 1, 0, 1, 1, 0 },
            },
            {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
                { 0, 2, 0, 0, 0, 0, 0, 0, 2, 0 },
                { 0, 0, 0, 0, 2, 2, 0, 0, 0, 0 },
                { 0, 0, 0, 2, 0, 0, 2, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
            },
            {
                { 2, 0, 2, 0, 0, 0, 0, 2, 0, 2 },
                { 0, 2, 0, 0, 0, 0, 0, 0, 2, 0 },
                { 2, 0, 2, 0, 0, 0, 0, 2, 0, 2 },
                { 0, 2, 0, 0, 0, 0, 0, 0, 2, 0 },
                { 0, 0, 0, 0, 2, 2, 0, 0, 0, 0 },
                { 0, 0, 0, 2, 0, 0, 2, 0, 0, 0 },
                { 0, 0, 0, 0, 2, 2, 0, 0, 0, 0 },
                { 0, 1, 0, 0, 1, 1, 0, 0, 1, 0 },
            },
        };

        static ConsoleColor[] targetColors = {
            ConsoleColor.Green,
            ConsoleColor.Magenta,
            ConsoleColor.Cyan,
        };

        static int levelCount;
        static int rowCount;
        static int columnCount;

        static Game() {
            levelCount = maps.GetLength(0);
            rowCount = maps.GetLength(1);
            columnCount = maps.GetLength(2);
        }

        Brick[] bricks;
        List<Brick> targets = new List<Brick>();

        int level = 1;

        void CreateBricks() {
            List<Brick> list = new List<Brick>();
            Block.DefaultWidth = area.Width / columnCount;
            int k = level - 1;
            for (int i = 0; i < rowCount; i++) {
                for (int j = 0; j < columnCount; j++) {
                    if (maps[k, i, j] == 0)
                        continue;
                    int left = j * Block.DefaultWidth;
                    int top = i;
                    Brick brick = new Brick(left, top);
                    if (maps[k, i, j] == 2) {
                        brick.IsTarget = true;
                        int colorIndex = (i + j) % targetColors.Length;
                        brick.Color = targetColors[colorIndex];
                        targets.Add(brick);
                    }
                    list.Add(brick);
                }
            }
            bricks = list.ToArray();
        }

    }
}
