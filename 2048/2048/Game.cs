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
        public bool keyTop, keyBottom, keyLeft, keyRight;

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

        public enum Direction
        {
            Top,
            Left,
            Bottom,
            Right
        }

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

            _buttons.Add(new Button(88, 18, 100, 66, 1, false)); // score
            _buttons.Add(new Button(206, 18, 100, 66, 1, false)); // best
            _buttons.Add(new Button(88, 96, 150, 38, 2, true));  // new game
            _buttons.Add(new Button(206, 96, 150, 38, 2, true));  // enable ia

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

        public void MoveBoard(Direction direction)
        {
            bool add = false;

            switch (direction)
            {
                case Direction.Top:
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            for (int k = j + 1; k < 4; k++)
                            {
                                if (_board[i][k] == 0)
                                {
                                    continue;
                                }
                                else if (_board[i][k] == _board[i][j])
                                {
                                    _board[i][j] *= 2;
                                    _score += _board[i][j];
                                    _board[i][k] = 0;
                                    add = true;
                                    break;
                                }
                                else
                                {
                                    if (_board[i][j] == 0 && _board[i][k] != 0)
                                    {
                                        _board[i][j] = _board[i][k];
                                        _board[i][k] = 0;
                                        j--;
                                        add = true;
                                        break;
                                    }
                                    else if (_board[i][j] != 0)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    break;
                case Direction.Right:
                    for (int j = 0; j < 4; j++)
                    {
                        for (int i = 3; i >= 0; i--)
                        {
                            for (int k = i - 1; k >= 0; k--)
                            {
                                if (_board[k][j] == 0)
                                {
                                    continue;
                                }
                                else if (_board[k][j] == _board[i][j])
                                {
                                    _board[i][j] *= 2;
                                    _score += _board[i][j];
                                    _board[k][j] = 0;
                                    add = true;
                                    break;
                                }
                                else
                                {
                                    if (_board[i][j] == 0 && _board[k][j] != 0)
                                    {
                                        _board[i][j] = _board[k][j];
                                        _board[k][j] = 0;
                                        i++;
                                        add = true;
                                        break;
                                    }
                                    else if (_board[i][j] != 0)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    break;
                case Direction.Bottom:
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 3; j >= 0; j--)
                        {
                            for (int k = j - 1; k >= 0; k--)
                            {
                                if (_board[i][k] == 0)
                                {
                                    continue;
                                }
                                else if (_board[i][k] == _board[i][j])
                                {
                                    _board[i][j] *= 2;
                                    _score += _board[i][j];
                                    _board[i][k] = 0;
                                    add = true;
                                    break;
                                }
                                else
                                {
                                    if (_board[i][j] == 0 && _board[i][k] != 0)
                                    {
                                        _board[i][j] = _board[i][k];
                                        _board[i][k] = 0;
                                        j++;
                                        add = true;
                                        break;
                                    }
                                    else if (_board[i][j] != 0)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    break;
                case Direction.Left:
                    for (int j = 0; j < 4; j++)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            for (int k = i + 1; k < 4; k++)
                            {
                                if (_board[k][j] == 0)
                                {
                                    continue;
                                }
                                else if (_board[k][j] == _board[i][j])
                                {
                                    _board[i][j] *= 2;
                                    _score += _board[i][j];
                                    _board[k][j] = 0;
                                    add = true;
                                    break;
                                }
                                else
                                {
                                    if (_board[i][j] == 0 && _board[k][j] != 0)
                                    {
                                        _board[i][j] = _board[k][j];
                                        _board[k][j] = 0;
                                        i--;
                                        add = true;
                                        break;
                                    }
                                    else if (_board[i][j] != 0)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    break;
                default:
                    break;
            }

            if(_score > _best)
                _best = _score;

            if (add)
                _addNum++;

            CheckGameOver();

            Render = true;
        }

        private void CheckGameOver()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i - 1 >= 0)
                    {
                        if (_board[i - 1][j] == _board[i][j])
                        {
                            return;
                        }
                    }

                    if (i + 1 < 4)
                    {
                        if (_board[i + 1][j] == _board[i][j])
                        {
                            return;
                        }
                    }

                    if (j - 1 >= 0)
                    {
                        if (_board[i][j - 1] == _board[i][j])
                        {
                            return;
                        }
                    }

                    if (j + 1 < 4)
                    {
                        if (_board[i][j + 1] == _board[i][j])
                        {
                            return;
                        }
                    }

                    if (_board[i][j] == 0)
                    {
                        return;
                    }
                }
            }

            _gameOver = true;
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

            DrawTextCenterXWS(graphics, "SCORE", _font10, new SolidBrush(Color.FromArgb(64, 10, 10, 10)), new SolidBrush(Color.FromArgb(235, 221, 208)), 138, 32);
            DrawTextCenterXWS(graphics, _score.ToString(), _font12, new SolidBrush(Color.FromArgb(64, 10, 10, 10)), new SolidBrush(Color.White), 138, 54);

            DrawTextCenterXWS(graphics, "BEST", _font10, new SolidBrush(Color.FromArgb(64, 10, 10, 10)), new SolidBrush(Color.FromArgb(235, 221, 208)), 256, 32);
            DrawTextCenterXWS(graphics, _best.ToString(), _font12, new SolidBrush(Color.FromArgb(64, 10, 10, 10)), new SolidBrush(Color.White), 256, 54);

            DrawTextCenterWS(graphics, "NEW GAME", _font10, new SolidBrush(Color.FromArgb(64, 10, 10, 10)), new SolidBrush(Color.FromArgb(255, 241, 224)), 138, 115);
            DrawTextCenterWS(graphics, "ENABLE IA", _font10, new SolidBrush(Color.FromArgb(64, 10, 10, 10)), new SolidBrush(Color.FromArgb(255, 241, 224)), 256, 115);

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

        public void CheckButton(int x, int y)
        {
            for (int i = 0; i < _buttons.Count; i++)
            {
                var button = _buttons[i];

                if (button.GetClickable())
                {
                    if(x >= button.GetPositionX() && x <= button.GetPositionX() + button.GetWidth() && y >= button.GetPositionY() && y <= button.GetPositionY() + button.GetHeight())
                    {
                        ActionButton(i);
                    }
                }
            }
        }

        private void ActionButton(int buttonID)
        {
            switch (buttonID)
            {
                case 2: // new game
                    NewGame();
                    break;
                case 3: // enable ia
                    EnableIA();
                    break;
                default:
                    throw new ArgumentException();
                    break;
            }
        }

        private void NewGame()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    this._board[i][j] = 0;
                }
            }

            this._addNum = 2;
            this._score = 0;
            this._gameOver = false;
            this.Render = true;
        }

        private void EnableIA()
        {
            throw new NotImplementedException();
        }
    }
}
