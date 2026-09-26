using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Drawing2D;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.MouseWheel += (s, e) =>
            {
                int delta = e.Delta > 0 ? 50 : -50;
                pictureBox1.Width = Math.Max(100, pictureBox1.Width + delta);
                pictureBox1.Height = Math.Max(100, pictureBox1.Height + delta);
            };

        }
        private int order = 12;
        private float startLength = 200;

        private void button1_Click(object sender, EventArgs e)
        {
            DrawLevyInPictureBox();
        }
        private void DrawLevyInPictureBox()
        {
            if (pictureBox1.Image == null)
            {
                pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            }
            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.White);
                
                PointF start = new PointF(300, pictureBox1.Height - 250);
                using (Pen pen = new Pen(Color.Blue, 1.5f))
                {
                    Levy(g, pen, order, start, 0f, startLength);
                }

            }
            pictureBox1.Refresh();
        }

        private void Levy(Graphics g, Pen pen, int order, PointF start, float angle, float len)
        {
            if (order == 0)
            {
                PointF end = new PointF(
                    start.X + len * (float)Math.Cos(angle * Math.PI / 180),
                    start.Y + len * (float)Math.Sin(angle * Math.PI / 180)
                );
                g.DrawLine(pen, start, end);
            }
            else
            {
                float newLen = len / (float)Math.Sqrt(2);
                PointF mid = new PointF(

                    start.X + newLen * (float)Math.Cos((angle + 45) * Math.PI / 180),
                    start.Y + newLen * (float)Math.Sin((angle + 45) * Math.PI / 180)

                );
                Levy(g, pen, order - 1, start, angle + 45, newLen);
                Levy(g, pen, order - 1, mid, angle - 45, newLen);
            }
        }
    }
}
