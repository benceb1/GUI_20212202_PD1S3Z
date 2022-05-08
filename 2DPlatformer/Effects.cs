using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace _2DPlatformer
{
    public static class Effects
    {

        // Fading between pages

        public static void Transition<T>(Canvas canvas, Page page)
        {
            int counter = 0;
            var dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            dispatcherTimer.Start();

            void dispatcherTimer_Tick(object sender, EventArgs e)
            {

                if (counter != 100)
                {
                    canvas.Opacity = canvas.Opacity -= 0.05;
                }
                else if (counter == 100)
                {
                    canvas.Opacity = 100;
                    page.NavigationService.Navigate((T)Activator.CreateInstance(typeof(T)));
                }
                counter += 1;
            }


        }

        // Fading out 
        public static void EndTransiton(Canvas canvas, Page page)
        {
            canvas.Opacity = 0;
            int counter = 0;
            var dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            dispatcherTimer.Start();

            void dispatcherTimer_Tick(object sender, EventArgs e)
            {

                if (counter != 100)
                {
                    canvas.Opacity = canvas.Opacity += 0.05;
                }
                else if (counter == 100)
                {
                    canvas.Opacity = 100;
                }
                counter += 1;
            }
        }


        public static void IngameParallexBackgroundSet(Image a, Image b,double velocity, double x,double windowWidth, bool leftCollision, bool rightCollision)
        {
            if (rightCollision == false && leftCollision == false)
            {
                Canvas.SetLeft(a, Canvas.GetLeft(a) - velocity * x);
                Canvas.SetLeft(b, Canvas.GetLeft(b) - velocity * x);
            }


            if (x > 0)
            {
                if (Canvas.GetLeft(a) < -a.ActualWidth)
                {
                    Canvas.SetLeft(a, Canvas.GetLeft(b) + b.ActualWidth - 2);
                }
                if (Canvas.GetLeft(b) < -b.ActualWidth)
                {
                    Canvas.SetLeft(b, Canvas.GetLeft(a) + a.ActualWidth - 2);
                }
            }
            if (x < 0)
            {
                if (Canvas.GetLeft(a) > a.ActualWidth)
                {
                    Canvas.SetLeft(a, Canvas.GetLeft(b) - b.ActualWidth + 2);
                }
                if (Canvas.GetLeft(b) > b.ActualWidth)
                {
                    Canvas.SetLeft(b, Canvas.GetLeft(a) - a.ActualWidth + 2);
                }
            }

        }


        public static void IngameParallexBackground4(Image a, Image b, Image c, Image d,Image a1, Image b1, Image c1, Image d1, double velocity, double x,double windowWidth, bool leftCollision, bool rightCollision)
        {
            IngameParallexBackgroundSet(a, a1, velocity/  16, x,windowWidth, leftCollision, rightCollision);
            IngameParallexBackgroundSet(b, b1, velocity / 8, x, windowWidth, leftCollision, rightCollision);
            IngameParallexBackgroundSet(c, c1, velocity / 4, x, windowWidth, leftCollision, rightCollision);
            IngameParallexBackgroundSet(d, d1, velocity / 2, x, windowWidth, leftCollision, rightCollision);
        }
    }
}
