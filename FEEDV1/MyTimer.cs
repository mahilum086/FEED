using AForge.Video;
using AForge.Vision.Motion;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Timers;

namespace FEEDV1
{
    class MyTimer
    {
        private static Timer aTimer;
        static int frame;
        static MotionDetector detector;
        public static void SetTimer()
        {
            frame = 0;
            detector = new MotionDetector(new SimpleBackgroundModelingDetector(), new MotionAreaHighlighting());
            // Create a timer with a two second interval.
            aTimer = new Timer(1000);
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
                    if (detector.ProcessFrame(bmp) > 0.02)
                    {
                        //Ma'am Jen: save image to db
                        bmp.Save("C:/Users/mmb/Downloads/DIT/Project Management/FEED Files/images/img_" + frame++ + ".jpg", ImageFormat.Bmp);
                        Console.WriteLine("Motion Detected.\nThe Elapsed event was raised at {0:HH:mm:ss.fff}", e.SignalTime);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }

        }

        public static void Stop()
        {
            aTimer.Stop();
        }
    }
}
