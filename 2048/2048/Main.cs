using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    public partial class Main : Form
    {
        private Game _game;
        private Graphics _graphics, _graphicsGame;
        private Bitmap _background;

        public Main()
        {
            InitializeComponent();

            _background = new Bitmap(396, 600);

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            _graphics = this.CreateGraphics();
            _graphicsGame = Graphics.FromImage(_background);

            _game = new Game();
        }

        private void Draw(Graphics graphics)
        {
            graphics.Clear(Color.FromArgb(251, 248, 239));
            _game.Draw(graphics);
        }
    }
}
