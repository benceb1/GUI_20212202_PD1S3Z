using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace _2DPlatformer
{
     static class Collision
    {
        public static bool CollisionDetectTop(Canvas canvas, Player player, bool coindetect)
        {
            int i;
            bool top;
            LinkedList<Shape> removelist = new LinkedList<Shape>();
            i = 0;
            foreach (Shape xy in canvas.Children)
            {
                if (player.Left >= Canvas.GetLeft(xy) - player.Width && player.Left <= Canvas.GetLeft(xy) + xy.Width && player.Top > Canvas.GetTop(xy) - player.Height && player.Top < Canvas.GetTop(xy) - player.Height + 10)
                {
                    if (coindetect == true && Equals(xy.GetType(), typeof(Ellipse)))
                    {
                        i++;
                        removelist.AddLast(xy);
                        player.CoinCounter++;
                    }
                }
                else
                {
                    i++;
                }
            }
            if (coindetect == true)
            {
                foreach (Shape element in removelist)
                {
                    canvas.Children.Remove(element);
                }
            }
            if (i == canvas.Children.Count)
            {
                top = false;
                return top;
            }
            else
            {
                top = true;
                return top;
            }

        }
        public static bool CollisionDetectBottom(Canvas canvas, Player player, bool coindetect)
        {
            int i;
            bool bottom;
            LinkedList<Shape> removelist = new LinkedList<Shape>();


            i = 0;

            foreach (Shape element in canvas.Children)
            {
                if (player.Left >= Canvas.GetLeft(element) - player.Width && player.Left <= Canvas.GetLeft(element) + element.Width && player.Top > Canvas.GetTop(element) + element.Height && player.Top < Canvas.GetTop(element) + element.Height + 10)
                {
                    if (coindetect == true && Equals(element.GetType(), typeof(Ellipse)))
                    {
                        i++;
                        removelist.AddLast(element);
                        player.CoinCounter++;
                    }
                }
                else
                {
                    i++;
                }
            }
            if (coindetect == true)
            {
                foreach (Shape element in removelist)
                {
                    canvas.Children.Remove(element);
                }
            }
            if (i == canvas.Children.Count)
            {
                bottom = false;
                return bottom;
            }
            else
            {
                bottom = true;
                return bottom;
            }
        }
        public static bool CollisionDetectRight(Canvas canvas, Player player, bool coindetect)
        {
            int i;
            bool right;
            LinkedList<Shape> removelist = new LinkedList<Shape>();

            i = 0;
            foreach (Shape xy in canvas.Children)
            {

                if (player.Top >= Canvas.GetTop(xy) - player.Height && player.Top <= Canvas.GetTop(xy) + xy.Height && player.Left > Canvas.GetLeft(xy) + xy.Width && player.Left < Canvas.GetLeft(xy) + xy.Width + 10)
                {
                    if (coindetect == true && Equals(xy.GetType(), typeof(Ellipse)))
                    {
                        i++;
                        removelist.AddLast(xy);
                        player.CoinCounter++;
                    }
                }
                else
                {
                    i++;
                }
            }
            if (coindetect == true)
            {
                foreach (Shape element in removelist)
                {
                    canvas.Children.Remove(element);
                }
            }


            if (i == canvas.Children.Count)
            {
                right = false;
                return right;
            }
            else
            {
                right = true;
                return right;
            }
        }
        public static bool CollisionDetectLeft(Canvas canvas, Player player, bool coindetect)
        {
            int i;
            bool left;
            LinkedList<Shape> removelist = new LinkedList<Shape>();


            i = 0;
            foreach (Shape xy in canvas.Children)
            {

                if (player.Top >= Canvas.GetTop(xy) - player.Height && player.Top <= Canvas.GetTop(xy) + xy.Height && player.Left > Canvas.GetLeft(xy) - player.Width && player.Left < Canvas.GetLeft(xy) - player.Width + 10)
                {
                    if (coindetect == true && Equals(xy.GetType(), typeof(Ellipse)))
                    {
                        i++;
                        removelist.AddLast(xy);
                        player.CoinCounter++;
                    }
                }
                else
                {
                    i++;
                }
            }
            if (coindetect == true)
            {
                foreach (Shape element in removelist)
                {
                    canvas.Children.Remove(element);
                }
            }


            if (i == canvas.Children.Count)
            {
                left = false;
                return left;
            }
            else
            {
                left = true;
                return left;
            }
        }
        public static void CollisonDetectAll(Canvas ShapeCanvas, Player playerobj, bool coindetect)
        {
            CollisionDetectTop(ShapeCanvas, playerobj, coindetect);
            CollisionDetectBottom(ShapeCanvas, playerobj, coindetect);
            CollisionDetectLeft(ShapeCanvas, playerobj, coindetect);
            CollisionDetectRight(ShapeCanvas, playerobj, coindetect);
        }
    }
}
