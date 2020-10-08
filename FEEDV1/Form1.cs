using AForge.Video;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FEEDV1
{
    public partial class Form1 : Form
    {
        MJPEGStream stream;        
        public static PictureBox camera;

        public Form1()
        {
            InitializeComponent();
            stream = new MJPEGStream("http://192.168.0.101:4747/video");
            stream.NewFrame += Stream_NewFrame;            
        }

        private void Stream_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = bmp;
            camera = pictureBox1;          
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            stream.Start();
            MyTimer.SetTimer();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            MyTimer.Stop();
            stream.Stop();            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
