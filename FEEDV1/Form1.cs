using AForge.Video;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FEEDV1
{
    public partial class Form1 : Form
    {
        MJPEGStream stream;
        int ctr;
        public Form1()
        {
            InitializeComponent();
            //ctr = 0;
            //stream = new MJPEGStream("http://192.168.10.86:4747/video");
            //stream.NewFrame += Stream_NewFrame;
        }

        private void Stream_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = bmp;

        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            //stream.Start();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            //stream.Stop();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            //pictureBox2.Image = (Bitmap)pictureBox1.Image.Clone();
        }
    }
}
