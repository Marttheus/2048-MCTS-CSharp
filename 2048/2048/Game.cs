using System;
using System.Collections.Generic;
using System.Drawing;

namespace _2048
{
    internal class Game
    {
        private int _score = 0, _best = 0;
        private int _addNum = 2;
        public bool Render = true;

        private bool _gameOver;
        private int[][] _board;
        private int _newX, _newY;
        private Rectangle _rect;

        private Random _random = new Random();
        private List<Button> _buttons = new List<Button>();
        public List<Bitmap> _bitmaps = new List<Bitmap>();
        private SizeF _sizeF = new SizeF();

        private Font _font10 = new Font("Clear Sans", 10, FontStyle.Bold);
        private Font _font12 = new Font("Clear Sans", 12, FontStyle.Bold);
        private Font _font22 = new Font("Clear Sans", 22, FontStyle.Bold);

        public Game()
        {
            this._board = new int[4][];

            for (int i = 0; i < 4; i++)
            {
                _board[i] = new int[4];
            }

            _bitmaps.Add(new Bitmap(@"images/1.png"));
            _bitmaps.Add(new Bitmap(@"images/2.png"));
            _bitmaps.Add(new Bitmap(@"images/3.png"));
            _bitmaps.Add(new Bitmap(@"images/4.png"));
            _bitmaps.Add(new Bitmap(@"images/5.png"));
            _bitmaps.Add(new Bitmap(@"images/6.png"));
            _bitmaps.Add(new Bitmap(@"images/7.png"));
            _bitmaps.Add(new Bitmap(@"images/8.png"));
            _bitmaps.Add(new Bitmap(@"images/9.png"));
            _bitmaps.Add(new Bitmap(@"images/k0.png"));
            _bitmaps.Add(new Bitmap(@"images/10.png"));
            _bitmaps.Add(new Bitmap(@"images/11.png"));
            _bitmaps.Add(new Bitmap(@"images/12.png"));
            _bitmaps.Add(new Bitmap(@"images/13.png"));
            _bitmaps.Add(new Bitmap(@"images/14.png"));
            _bitmaps.Add(new Bitmap(@"images/15.png"));
            _bitmaps.Add(new Bitmap(@"images/16.png"));
            _bitmaps.Add(new Bitmap(@"images/17.png"));
            _bitmaps.Add(new Bitmap(@"images/18.png"));

            _buttons.Add(new Button(18, 18, 100, 66, 1, false)); // score
            _buttons.Add(new Button(136, 18, 100, 66, 1, false)); // best
            _buttons.Add(new Button(18, 96, 100, 38, 2, true));  // new game

            _rect = new Rectangle(0, 0, 416, 640);
        }

        public void Update()
        {
            while (!_gameOver && _addNum > 0)
            {
                int positionX = _random.Next(0, 4), positionY = _random.Next(0, 4);

                if (_board[positionX][positionY] == 0)
                {
                    _board[positionX][positionY] = _random.Next(0, 20) == 0 ? _random.Next(0, 15) == 0 ? 8 : 4 : 2;
                    _newX = positionX;
                    _newY = positionY;
                    _addNum--;
                }
            }
        }

        public void Draw(Graphics graphics)
        {
            DrawGame(graphics);

            if (_gameOver)
            {
                GameOverDraw(graphics);
            }

            Render = false;
        }

        private void DrawGame(Graphics graphics)
        {
            for (int i = 0; i < _buttons.Count; i++)
            {
                _buttons[i].Draw(graphics, _bitmaps[_buttons[i].GetImgID()]);
            }

            DrawTextCenterXWS(graphics, "SCORE", _font10, new SolidBrush(Color.FromArgb(64, 10, 10, 10)), new SolidBrush(Color.FromArgb(235, 221, 208)), 68, 32);
            DrawTextCenterXWS(graphics, _score.ToString(), _font12, new SolidBrush(Color.FromArgb(64, 10, 10, 10)), new SolidBrush(Color.White), 68, 54);

            DrawTextCenterXWS(graphics, "BEST", _font10, new SolidBrush(Color.FromArgb(64, 10, 10, 10)), new SolidBrush(Color.FromArgb(235, 221, 208)), 186, 32);
            DrawTextCenterXWS(graphics, _best.ToString(), _font12, new SolidBrush(Color.FromArgb(64, 10, 10, 10)), new SolidBrush(Color.White), 186, 54);

            DrawTextCenterWS(graphics, "NEW GAME", _font10, new SolidBrush(Color.FromArgb(64, 10, 10, 10)), new SolidBrush(Color.FromArgb(255, 241, 224)), 68, 115);

            graphics.DrawImage(_bitmaps[3], new Point(18, 166));

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    graphics.DrawImage(_bitmaps[i == _newX && j == _newY ? 18 : GetBitmapID(_board[i][j])], new Point(30 + 87 * i, 178 + 87 * j));

                    if (_board[i][j] > 0)
                    {
                        DrawTextCenterWS(graphics, _board[i][j].ToString(), _font22, new SolidBrush(Color.FromArgb(64, 10, 10, 10)), (i == _newX && j == _newY ? new SolidBrush(Color.FromArgb(255, 255, 255)) : _board[i][j] < 8 ? new SolidBrush(Color.FromArgb(120, 110, 101)) : new SolidBrush(Color.FromArgb(249, 245, 235))), 68 + 87 * i, 217 + 87 * j);
                    }
                }
            }
        }

        private void GameOverDraw(Graphics graphics)
        {
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(150, 251, 248, 239)), _rect);

            DrawTextCenterXWS(graphics, "GAME OVER", _font12, new SolidBrush(Color.FromArgb(64, 10, 10, 10)), new SolidBrush(Color.FromArgb(120, 110, 101)), 198, 250);
            DrawTextCenterXWS(graphics, "SCORE: " + _score.ToString(), _font12, new SolidBrush(Color.FromArgb(64, 10, 10, 10)), new SolidBrush(Color.FromArgb(120, 110, 101)), 198, 282);
        }

        public void DrawTextCenterXWS(Graphics graphics, string text, Font font, SolidBrush solidBrush1, SolidBrush solidBrush2, int x, int y)
        {
            _sizeF = graphics.MeasureString(text, font);
            graphics.DrawString(text, font, solidBrush1, new PointF(x - _sizeF.Width / 2 + 1, y + 1));
            graphics.DrawString(text, font, solidBrush2, new PointF(x - _sizeF.Width / 2, y));
        }

        public void DrawTextCenterWS(Graphics graphics, string text, Font font, SolidBrush solidBrush1, SolidBrush solidBrush2, int x, int y)
        {
            _sizeF = graphics.MeasureString(text, font);
            graphics.DrawString(text, font, solidBrush1, new PointF(x - _sizeF.Width / 2 + 1, y - _sizeF.Height / 2 + 1));
            graphics.DrawString(text, font, solidBrush2, new PointF(x - _sizeF.Width / 2, y - _sizeF.Height / 2));
        }

        public void DrawTextCenterX(Graphics graphics, string text, Font font, SolidBrush solidBrush, int x, int y)
        {
            _sizeF = graphics.MeasureString(text, font); ;
            graphics.DrawString(text, font, solidBrush, new PointF(x - _sizeF.Width / 2, y));
        }

        public int GetBitmapID(int num)
        {
            switch (num)
            {
                case 0:
                    return 4;
                case 2:
                    return 5;
                case 4:
                    return 6;
                case 8:
                    return 7;
                case 16:
                    return 8;
                case 32:
                    return 10;
                case 64:
                    return 11;
                case 128:
                    return 12;
                case 256:
                    return 13;
                case 512:
                    return 14;
                case 1024:
                    return 15;
                case 2048:
                    return 16;
                case 4096:
                case 8192:
                case 16384:
                    return 17;
            }

            return 4;
        }
    }
}
