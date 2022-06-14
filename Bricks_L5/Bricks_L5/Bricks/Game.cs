using Bricks.Collisions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bricks {
    partial class Game {
        Area area = new Area();
        Ball ball;
        MovingBlock paddle;

        List<IDrawable> drawableObjects = new List<IDrawable>();
        List<IMovable> movableObjects = new List<IMovable>();

        bool isOver = true;

        int maxPaddleDx = 3;
        int maxBallDx = 2;
        int minDelay = 80;

        public void Run() {
            CreateObjects();
            PrepareScreen();
            DrawObjects();
            while (true) {
                //System.Threading.Thread.Sleep(150);
                System.Threading.Thread.Sleep(minDelay);
                //Console.Clear();
                if (Console.KeyAvailable) {
                    HandleKeyPress();
                }
                if (isOver)
                    continue;
                MoveObjects();                  //Move
                DrawHittedBricks();
                //DrawObjects();
                CheckAndHandleCollisions();
            }
        }

        private void DrawHittedBricks() {
            for (int i = hittedBricks.Count - 1; i >= 0; i--) {
                hittedBricks[i].Draw();
                hittedBricks.RemoveAt(i);
            }
        }

        private readonly ICollisionHandler collisionHandler;

        public Game(ICollisionHandler collisionHandler) {
            if (collisionHandler == null) {
                throw new ArgumentNullException();
            }
            this.collisionHandler = collisionHandler;
            collisionHandler.Hit += collisionHandler_Hit;
        }

        void collisionHandler_Hit(object sender, HitEventArgs e) {
            //throw new NotImplementedException();
            Brick brick = e.Brick;
            if (brick.IsTarget) {
                //brick.IsHitted = true;
                //brick.Erase();
                targets.Remove(brick);
                if (targets.Count == 0) {
                    CompleteLevel();
                }
            }
            else {
                hittedBricks.Add(brick);
            }
        }

        private void CheckAndHandleCollisions() {
            //ball.CheckAndHandleCollision(paddle);
            //if (ball.CheckAndHandleCollision(paddle)) {
            if (collisionHandler.CheckAndHandleCollision(ball, paddle)) {
                ball.Dx = ball.Dx + paddle.Dx / 2;
                if (Math.Abs(ball.Dx) > maxBallDx) {
                    ball.Dx = Math.Sign(ball.Dx) * maxBallDx;
                }
            }

            collisionHandler.CheckAndHandleCollisions(ball, bricks);
            //foreach (Brick brick in bricks) {
            //    if (brick.IsHitted)
            //        continue;
            //    if (ball.CheckAndHandleCollision(brick)) {
            //        if (brick.IsTarget) {
            //            brick.IsHitted = true;
            //            brick.Erase();
            //            targets.Remove(brick);
            //            if (targets.Count == 0) {
            //                CompleteLevel();
            //            }
            //        }
            //        else {
            //            hittedBricks.Add(brick);
            //        }
            //    }
            //}
        }

        private void CompleteLevel() {
            if (level < levelCount) {
                ShowMessage("Level is complete!");
                level++;
                UpdateLevel();
            }
            else {
                isOver = true;
                ShowMessage("Game is complete!");
            }
        }

        private void UpdateLevel() {
            System.Threading.Thread.Sleep(1000);
            DeleteObjects();
            CreateObjects();
            DrawObjects();
            System.Threading.Thread.Sleep(1000);
        }

        private void DeleteObjects() {
            targets.Clear();
            drawableObjects.Clear();
            movableObjects.Clear();
            bricks = null;
            ball = null;
            paddle = null;
        }

        List<Brick> hittedBricks = new List<Brick>();

        private void MoveObjects() {                        //Move
            foreach (IMovable obj in movableObjects) {
                obj.Move();
            }
        }

        private void CreateObjects() {
            area.Width = Console.WindowWidth;
            area.Height = Console.WindowHeight;
            ball = new Ball() {
                X = area.Width / 2,
                Y = area.Height - 3,
                Dx = 1,
                Dy = -1,
                Area = area
            };
            ball.Loss += ball_Loss;

            drawableObjects.Add(area);
            drawableObjects.Add(ball);
            movableObjects.Add(ball);

            int paddleWidth = area.Width / 7;
            paddle = new MovingBlock(
                (area.Width - paddleWidth) / 2,
                area.Height - 2, paddleWidth,
                 ConsoleColor.Blue, 0, 0) { 
                Area = area
            };
            drawableObjects.Add(paddle);
            movableObjects.Add(paddle);                 //Move

            CreateBricks();
            drawableObjects.AddRange(bricks);
        }

        void ball_Loss(object sender, EventArgs e) {
            //throw new NotImplementedException();
            isOver = true;
            ShowMessage("Game is over!");
        }

        private void HandleKeyPress() {                 //Move
            var keyInfo = Console.ReadKey(true);
            while (Console.KeyAvailable) {
                keyInfo = Console.ReadKey(true);
            }
            switch (keyInfo.Key) {
                case ConsoleKey.Enter:
                    StartStopGame();
                    break;
                case ConsoleKey.RightArrow:
                    paddle.Dx++;
                    break;
                case ConsoleKey.LeftArrow:
                    paddle.Dx--;
                    break;
            }
        }

        private void StartStopGame() {
            isOver = !isOver;
            if (isOver) {
                ShowMessage("Game is over!");
            }
        }

        private void ShowMessage(string message) {
            int left = (area.Width - message.Length) / 2;
            int top = area.Height / 2;
            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(message);
        }

        private void DrawObjects() {
            Console.Clear();
            //area.Draw();
            //ball.Draw();
            foreach (IDrawable obj in drawableObjects) {
                obj.Draw();
            }
        }

        private void PrepareScreen() {
            Console.BufferHeight = Console.WindowHeight;
            Console.BackgroundColor = area.Color;
            Console.CursorVisible = false;
        }

    }
}
