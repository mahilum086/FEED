using AForge.Video;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace FEEDV1
{
    class Timer
    {
        private static System.Timers.Timer aTimer;
        static int count;
        public static void SetTimer()
        {
            count = 0;
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(2000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += ATimer_Elapsed;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void ATimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                using (var bmp = new Bitmap((Bitmap)Form1.camera.Image))
                {
                    bmp.Save("C:/Users/mmb/Downloads/DIT/Project Management/FEED Files/images/img_" + count++ + ".jpg", ImageFormat.Bmp);
                    Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}", e.SignalTime);
                }
            }catch(Exception ex)
            {
                Console.WriteLine("Error:"+ ex.Message);
            }
                
        }

        public static void Stop()
        {
            aTimer.Stop();
        }
    }
}
