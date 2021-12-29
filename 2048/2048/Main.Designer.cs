using System;
using System.Windows.Forms;

namespace _2048
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Timer _timer;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 540);
            this.Text = "2048 - MCTS";
            this.Name = "2048";

            this._timer = new System.Windows.Forms.Timer(this.components);
            this._timer.Enabled = true;
            this._timer.Interval = 60;
            this._timer.Tick += new System.EventHandler(this.timer_Tick);

            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Main_MouseClick);

            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Main_KeyUp);
        }

        private void Main_KeyUp(object sender, KeyEventArgs e)
        {
            if (_game.keyTop && (e.KeyCode == Keys.W || e.KeyCode == Keys.Up))
            {
                _game.keyTop = false;
            }

            if (_game.keyLeft && (e.KeyCode == Keys.A || e.KeyCode == Keys.Left))
            {
                _game.keyLeft = false;
            }

            if (_game.keyBottom && (e.KeyCode == Keys.S || e.KeyCode == Keys.Down))
            {
                _game.keyBottom = false;
            }

            if (_game.keyRight && (e.KeyCode == Keys.D || e.KeyCode == Keys.Right))
            {
                _game.keyRight = false;
            }
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_game.keyLeft && !_game.keyRight && !_game.keyBottom && (e.KeyCode == Keys.W || e.KeyCode == Keys.Up))
            {
                _game.keyTop = true;
                _game.MoveBoard(Game.Direction.Top);
            }

            if (!_game.keyTop && !_game.keyRight && !_game.keyBottom && (e.KeyCode == Keys.A || e.KeyCode == Keys.Left))
            {
                _game.keyLeft = true;
                _game.MoveBoard(Game.Direction.Left);
            }

            if (!_game.keyTop && !_game.keyRight && !_game.keyLeft && (e.KeyCode == Keys.S || e.KeyCode == Keys.Down))
            {
                _game.keyBottom = true;
                _game.MoveBoard(Game.Direction.Bottom);
            }

            if (!_game.keyTop && !_game.keyLeft && !_game.keyBottom && (e.KeyCode == Keys.D || e.KeyCode == Keys.Right))
            {
                _game.keyRight = true;
                _game.MoveBoard(Game.Direction.Right);
            }
        }

        private void Main_MouseClick(object sender, MouseEventArgs e)
        {
            _game.CheckButton(e.X, e.Y);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            _game.Update();
            if (_game.Render)
            {
                Draw(_graphicsGame);

                _graphics.DrawImage(_background, new System.Drawing.Point(0, 0));
            }
        }

        #endregion
    }
}
