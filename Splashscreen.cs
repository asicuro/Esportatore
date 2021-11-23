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
        Graphics doubleBuffer;
        float x = -50;
        public Splashscreen()
        {
            barchino = new Bitmap(Esportatore.Properties.Resources.barchino);
            sfondo = new Bitmap(Esportatore.Properties.Resources.sea);
            InitializeComponent();
            timer1.Start();
            timer1.Interval = 150;
        }

        private void Splashscreen_Paint(object sender, PaintEventArgs e)
        {
            doubleBuffer = e.Graphics;
            //System.Drawing.Imaging.ImageAttributes attr = new System.Drawing.Imaging.ImageAttributes();
            doubleBuffer = this.CreateGraphics();
            doubleBuffer.DrawImage(barchino, new Point((int)x,190));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            x += 90;
            doubleBuffer = this.CreateGraphics();
            doubleBuffer.DrawImage(barchino, new Point((int)x, 190));
        }
    }
}
