using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bricks {
    class Block : IDrawable {
        public static int DefaultWidth = 5;

        public int Left;
        public int Top;
        public int Width;
        public ConsoleColor Color = ConsoleColor.DarkGray;

        public int Right {
            get { return Left + Width - 1; }
        }

        public Block(int left, int top, int width,
            ConsoleColor color) {
                Left = left;
                Top = top;
                Width = width;
                Color = color;
        }

        public Block(int left, int top, int width)
            : this(left, top, width, ConsoleColor.DarkGray) { }

        public Block(int left, int top)
            : this(left, top, DefaultWidth) { }

        public Block(int left, int top, ConsoleColor color)
            : this(left, top, DefaultWidth, color) { }

        public void Draw() {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(Left, Top);
            for (int i = 1; i <= Width; i++) {
                Console.Write('█');
            }
        }

        public void Erase() {
            Console.SetCursorPosition(Left, Top);
            for (int i = 1; i <= Width; i++) {
                Console.Write(' ');
            }
        }

    }
}
