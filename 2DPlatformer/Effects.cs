using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace _2DPlatformer
{
    public static class Effects
    {
        public static void Transition<T>(Canvas canvas, Page page)
        {
            int counter = 0;
            var dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 10);
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
        public static void EndTransiton(Canvas canvas, Page page)
        {
            canvas.Opacity = 0;
            int counter = 0;
            var dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 20);
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
    }
}
