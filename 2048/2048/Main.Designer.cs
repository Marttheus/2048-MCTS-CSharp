using System;

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
            this.Text = "2048";
            this.Name = "2048";

            this._timer = new System.Windows.Forms.Timer(this.components);
            this._timer.Enabled = true;
            this._timer.Interval = 60;
            this._timer.Tick += new System.EventHandler(this.timer_Tick);
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
