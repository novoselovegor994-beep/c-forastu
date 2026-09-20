using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labawinforms2
{
    public partial class Form1 : Form
    {
        private List<Point> points = new List<Point>();
        
        private List<Star> stars = new List<Star>();

        private Random random = new Random();

        private Timer animTimer = new Timer();

        private float t = 0f;

        private bool converting = true;

        public Form1()   
        {
            InitializeComponent();
            pictureBox1.Paint += pictureBox1_Paint;

            // настройка таймера
            animTimer.Interval = 16;
            animTimer.Tick += AnimTimer_Tick;

            // trackbar
            trackBar1.Minimum = 1;
            trackBar1.Maximum = 20;
            trackBar1.Value = 5;

            // кнопки
            button2.Click += button2_Click;
            button3.Click += button3_Click;
            button4.Click += button4_Click;
            button5.Click += button5_Click;




        }
        public class Star
        {
            public float StartX;
            public float StartY;
            public float X;
            public float Y;
            public float CenterX;
            public float CenterY;

            public Star(float x, float y, float cx, float cy)
            {
                StartX = x; StartY = y;
                X = x; Y = y;
                CenterX = cx; CenterY = cy;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int count) || count <= 0)
            {
                MessageBox.Show("Введите положительное целое число!");
                return;
            }
            
            points.Clear();
            stars.Clear();
            t = 0f;
            animTimer.Stop();

            int w = pictureBox1.Width; // размеры picturebox
            int h = pictureBox1.Height;
            float cx = w / 2f;
            float cy = h / 2f;

            for (int i = 0; i < count; i++)
            {
                int x = random.Next(0, w);
                int y = random.Next(0, h);
                points.Add(new Point(x, y));
                stars.Add(new Star(x, y, cx, cy));
            }
            pictureBox1.Invalidate();
           

        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Point p in points)
            {
                e.Graphics.FillEllipse(Brushes.Red, p.X - 2, p.Y - 2, 4, 4);
            }
            foreach (Star s in stars)
            {
                e.Graphics.FillEllipse(Brushes.White, s.X - 2, s.Y - 2, 4, 4);
            } 

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (stars.Count == 0) return;
            converting = true;
            if (!animTimer.Enabled) animTimer.Start();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (stars.Count == 0) return;
            if (!animTimer.Enabled) animTimer.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (stars.Count == 0) return;
            converting = false;
            if (!animTimer.Enabled) animTimer.Start();
        }
        private void AnimTimer_Tick(object sender, EventArgs e)
        {
            float speed = trackBar1.Value / 200f;
            if (converting)
            {
                t += speed;
                if (t >= 1f) { t = 1f; animTimer.Stop(); }
            }
            else
            {
                t -= speed;
                if (t <= 0f) { t = 0f; animTimer.Stop(); }
            }
            foreach ( Star s in stars)
            {
                s.X = s.StartX + (s.CenterX - s.StartX) * t;
                s.Y = s.StartY + (s.CenterY - s.StartY) * t;
            }
            pictureBox1.Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            animTimer.Stop();
        }
    }
}
