using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    internal class Button
    {
        private int _positionX, _positionY;
        private int _width, _height;
        private int _imgID;

        private bool _clickable;

        public Button(int positionX, int positionY, int width, int height, int imgID, bool clickable)
        {
            this._positionX = positionX;
            this._positionY = positionY;
            this._width = width;
            this._height = height;
            this._imgID = imgID;
            this._clickable = clickable;
        }

        internal void Draw(Graphics graphics, Bitmap bitmap)
        {
            graphics.DrawImage(bitmap, new Point(_positionX, _positionY));
        }

        internal int GetImgID()
        {
            return _imgID;
        }

        public int GetPositionX()
        {
            return _positionX;
        }

        public int GetPositionY()
        {
            return _positionY;
        }

        public int GetWidth()
        {
            return _width;
        }

        public int GetHeight()
        {
            return _height;
        }

        public bool GetClickable()
        {
            return _clickable;
        }
    }
}
