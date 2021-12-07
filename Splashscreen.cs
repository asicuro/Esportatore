using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esportatore
{
    public partial class Splashscreen : Form
    {
        Bitmap barchino;
        Bitmap sfondo;
        Bitmap doubleBuffer;
        Graphics backBuffer;
        float x = -50;
        float msecs = 0;
        float durataMsecs = 5000;
        public Splashscreen()
        {

            doubleBuffer = new Bitmap(this.Width, this.Height);
            backBuffer = Graphics.FromImage(doubleBuffer);
            barchino = new Bitmap(Esportatore.Properties.Resources.barchino);
            sfondo = new Bitmap(Esportatore.Properties.Resources.sea);
            InitializeComponent();
            timer1.Interval = 10;
            timer1.Start();
            
        }

        private void Splashscreen_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //System.Drawing.Imaging.ImageAttributes attr = new System.Drawing.Imaging.ImageAttributes();
            
            g.DrawImage(doubleBuffer, 0, 0, this.Width, this.Height);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            msecs += timer1.Interval;
            if (msecs > durataMsecs)
            {
                timer1.Stop();
                Form1 form = new Form1();
                form.Show();
                this.Hide();
            }
            else {
                x += 5;
                backBuffer.FillRectangle(Brushes.White, 0, 0, this.Width, this.Height);

                backBuffer.DrawImage(sfondo, new Rectangle(0, 0, this.Width, this.Height), 0, 0, this.Width, this.Height, GraphicsUnit.Pixel);
                backBuffer.DrawImage(barchino, new Rectangle((int)x, 190, barchino.Width / 3, barchino.Height / 3), 0, 0, barchino.Width, barchino.Height, GraphicsUnit.Pixel);
                if (x >= this.Width)
                    x = -50;
                this.Invalidate();
            }
        }

        private void Splashscreen_Load(object sender, EventArgs e)
        {

        }
    }
}
