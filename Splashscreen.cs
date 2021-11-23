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
        public Splashscreen()
        {
            InitializeComponent();
            timer1.Start();
            timer2.Start();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            object[] objArgs = new object[] { ControlStyles.AllPaintingInWmPaint |
                                      ControlStyles.UserPaint |
                                      ControlStyles.OptimizedDoubleBuffer, true };
            MethodInfo SetStyleMethod = typeof(Control).GetMethod("SetStyle", BindingFlags.NonPublic | BindingFlags.Instance);

            SetStyleMethod.Invoke(this.panelSlide, objArgs);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panelSlide.Left += 15;

            if (panelSlide.Left > 1080)
                panelSlide.Left = -200;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
    }
}
