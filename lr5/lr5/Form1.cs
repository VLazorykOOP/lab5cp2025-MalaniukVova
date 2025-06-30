using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab5_Graphics
{
    public partial class Form1 : Form
    {
        private Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void drawHermiteCurve(Graphics g, PointF p1, PointF p2, PointF v1, PointF v2)
        {
            Pen pen = new Pen(Color.Red, 2);
            PointF prev = p1;
            for (float t = 0; t <= 1.0; t += 0.01f)
            {
                float h1 = 2 * t * t * t - 3 * t * t + 1;
                float h2 = -2 * t * t * t + 3 * t * t;
                float h3 = t * t * t - 2 * t * t + t;
                float h4 = t * t * t - t * t;

                float x = h1 * p1.X + h2 * p2.X + h3 * v1.X + h4 * v2.X;
                float y = h1 * p1.Y + h2 * p2.Y + h3 * v1.Y + h4 * v2.Y;

                PointF current = new PointF(x, y);
                g.DrawLine(pen, prev, current);
                prev = current;
            }
        }

        private void drawHarterHeighway(Graphics g, PointF p1, PointF p2, int depth)
        {
            if (depth == 0)
            {
                Pen pen = new Pen(Color.FromArgb(rand.Next(150, 255), 0, 0, rand.Next(100, 255)), 1);
                g.DrawLine(pen, p1, p2);
                return;
            }

            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;

            float mx = (p1.X + p2.X) / 2;
            float my = (p1.Y + p2.Y) / 2;

            PointF mid = new PointF(
                mx - dy / 2,
                my + dx / 2
            );

            drawHarterHeighway(g, p1, mid, depth - 1);
            drawHarterHeighway(g, p2, mid, depth - 1);
        }

        private void generateCloudSky(Graphics g, int segments, int depth)
        {
            for (int i = 0; i < segments; i++)
            {
                PointF p1 = new PointF(rand.Next(Width), rand.Next(Height / 2));
                PointF p2 = new PointF(p1.X + rand.Next(-100, 100), p1.Y + rand.Next(-100, 100));
                drawHarterHeighway(g, p1, p2, depth);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (comboBox1.SelectedIndex == 0)
            {
                PointF p1 = new PointF(100, 300);
                PointF p2 = new PointF(400, 300);
                PointF v1 = new PointF(300, -150);
                PointF v2 = new PointF(300, 150);
                drawHermiteCurve(g, p1, p2, v1, v2);
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                generateCloudSky(g, 30, 5);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Invalidate(); // Перемальовка форми
        }
    }
}
