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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // функция первой кнопки чтобы нарисовать сетку
        {
            Graphics myGraphics;
            Pen myPen; // ввели переменные
            int i, nW, nH;
            myGraphics = pictureBox1.CreateGraphics(); 
            nW = pictureBox1.Width; // высота и ширина picturebox
            nH = pictureBox1.Height;
            myGraphics.Clear(Color.White); // чистим картинкку перед тем как рисовать сетку
            myPen = new Pen(Color.LightGray, 1); // цвет сетки

            for (i = 0; i <= nH; i += 20)
            {
                myGraphics.DrawLine(myPen, 0, i, nW, i); // рисуем линии в длину
                Thread.Sleep(50); // задержка в рисовке
            }
            for (i = 0; i <= nW; i += 20)
            {
                myGraphics.DrawLine(myPen, i, 0, i, nH); // рисуем линии в ширину
                Thread.Sleep(50);
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics(); // обьект который позволяет нам рисовать

            Pen redPen = new Pen(Color.Red, 3); // переменные для ручек
            Pen bluePen = new Pen(Color.Blue, 3);
            Pen greenPen = new Pen(Color.Green, 3);
            Pen blackPen = new Pen(Color.Black, 3);

            int size = 60;          // Размер квадрата (3 клетки)
            int gap = 20;           // Зазор между квадратами (1 клетка)
            int step = size + gap;  // Шаг между началами квадратов (80 пикселей)

            int startX = 20; // отступ чтобы не прилипали к краям
            int topY = 20;   // Красный ряд начальная координата Y
            int midY = 100;  // Зеленый ряд (topY + 80)
            int botY = 180;  // Синий ряд (midY + 80)

            g.DrawRectangle(redPen, startX, topY, size, size);
            g.DrawRectangle(redPen, startX + step, topY, size, size); // сдвиг на шаг затем на два вправо
            g.DrawRectangle(redPen, startX + step * 2, topY, size, size);
            g.DrawRectangle(redPen, startX + step * 3, topY, size, size);

            // 2. Рисуем ЗЕЛЕНЫЕ квадраты (4 штуки)
            g.DrawRectangle(greenPen, startX, midY, size, size);
            g.DrawRectangle(greenPen, startX + step, midY, size, size);
            g.DrawRectangle(greenPen, startX + step * 2, midY, size, size);
            g.DrawRectangle(greenPen, startX + step * 3, midY, size, size);

            // 3. Рисуем СИНИЕ квадраты (4 штуки)
            g.DrawRectangle(bluePen, startX, botY, size, size);
            g.DrawRectangle(bluePen, startX + step, botY, size, size);
            g.DrawRectangle(bluePen, startX + step * 2, botY, size, size);
            g.DrawRectangle(bluePen, startX + step * 3, botY, size, size);

            // 4. Черные квадраты (смещены на 1 клетку вниз и 1 клетку вправо)
            int blackX = startX + gap*2; // Смещение на 40 пикселей вправо
            int blackYOffset = gap*2;    // Смещение на 40 пикселей вниз по Y

            // Черные в красном ряду
            g.DrawRectangle(blackPen, blackX, topY + blackYOffset, size, size);
            g.DrawRectangle(blackPen, blackX + step, topY + blackYOffset, size, size);
            g.DrawRectangle(blackPen, blackX + step * 2, topY + blackYOffset, size, size);

            // Черные в зеленом ряду
            g.DrawRectangle(blackPen, blackX, midY + blackYOffset, size, size);
            g.DrawRectangle(blackPen, blackX + step, midY + blackYOffset, size, size);
            g.DrawRectangle(blackPen, blackX + step * 2, midY + blackYOffset, size, size);


        }
    }
}
