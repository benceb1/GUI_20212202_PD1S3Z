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
        public static bool CollisionDetectTop(Canvas canvas, Player player, bool coindetect,bool enemydetect)
        {
            int i;
            bool top;
            LinkedList<Shape> removelist = new LinkedList<Shape>();
            i = 0;
            foreach (Shape xy in canvas.Children)
            {
                if (player.IsAttacking==true&&player.Left >= Canvas.GetLeft(xy) - player.Width-40 && player.Left-40 <= Canvas.GetLeft(xy) + xy.Width && player.Top > Canvas.GetTop(xy) - player.Height && player.Top < Canvas.GetTop(xy) - player.Height + 5)
                {
                    if (enemydetect == true && xy.Name == "Slime")
                    {
                        i++;
                        removelist.AddLast(xy);
                        player.SlimeKilled++;
                        player.Experience = player.Experience + 5;
                    }
                }
                if (player.Left >= Canvas.GetLeft(xy) - player.Width && player.Left <= Canvas.GetLeft(xy) + xy.Width && player.Top > Canvas.GetTop(xy) - player.Height && player.Top < Canvas.GetTop(xy) - player.Height + 10)
                {
                    if (coindetect == true && xy.Name=="Coin")
                    {
                        i++;
                        removelist.AddLast(xy);
                        player.CoinCounter++;
                        player.Experience = player.Experience + 2;
                    }
                    if(enemydetect==true&&xy.Name=="Slime" &&player.IsDamaged==false)
                    {
                        i++;
                        player.playerDamaged();
                    }
                }
                else
                {
                    i++;
                }
            }
            if (coindetect == true)
            {
                foreach (Shape xy in removelist)
                {
                    canvas.Children.Remove(xy);
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
        public static bool CollisionDetectBottom(Canvas canvas, Player player, bool coindetect, bool enemydetect)
        {
            int i;
            bool bottom;
            LinkedList<Shape> removelist = new LinkedList<Shape>();


            i = 0;

            foreach (Shape xy in canvas.Children)
            {
                if (player.IsAttacking == true && player.Left >= Canvas.GetLeft(xy) - player.Width - 40 && player.Left - 40 <= Canvas.GetLeft(xy) + xy.Width && player.Top > Canvas.GetTop(xy) - player.Height && player.Top < Canvas.GetTop(xy) - player.Height + 5)
                {
                    if (enemydetect == true && xy.Name == "Slime")
                    {
                        i++;
                        removelist.AddLast(xy);
                        player.SlimeKilled++;
                        player.Experience = player.Experience + 5;
                    }
                }
                if (player.Left >= Canvas.GetLeft(xy) - player.Width && player.Left <= Canvas.GetLeft(xy) + xy.Width && player.Top > Canvas.GetTop(xy) + xy.Height && player.Top < Canvas.GetTop(xy) + xy.Height + 10)
                {
                    if (coindetect == true && xy.Name == "Coin")
                    {
                        i++;
                        removelist.AddLast(xy);
                        player.CoinCounter++;
                        player.Experience = player.Experience + 2;
                    }
                    if (enemydetect == true && xy.Name == "Slime" &&player.IsDamaged == false)
                    {
                        i++;
                        player.playerDamaged();
                    }
                }
                else
                {
                    i++;
                }
            }
            if (coindetect == true)
            {
                foreach (Shape xy in removelist)
                {
                    canvas.Children.Remove(xy);
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
        public static bool CollisionDetectRight(Canvas canvas, Player player, bool coindetect, bool enemydetect)
        {
            int i;
            bool right;
            LinkedList<Shape> removelist = new LinkedList<Shape>();

            i = 0;
            foreach (Shape xy in canvas.Children)
            {
                if (player.IsAttacking == true && player.Left >= Canvas.GetLeft(xy) - player.Width - 40 && player.Left - 40 <= Canvas.GetLeft(xy) + xy.Width && player.Top > Canvas.GetTop(xy) - player.Height && player.Top < Canvas.GetTop(xy) - player.Height + 5)
                {
                    if (enemydetect == true && xy.Name == "Slime")
                    {
                        i++;
                        removelist.AddLast(xy);
                        player.SlimeKilled++;
                        player.Experience = player.Experience + 5;
                    }
                }

                if (player.Top >= Canvas.GetTop(xy) - player.Height && player.Top <= Canvas.GetTop(xy) + xy.Height && player.Left > Canvas.GetLeft(xy) + xy.Width && player.Left < Canvas.GetLeft(xy) + xy.Width + 10)
                {
                    if (coindetect == true && xy.Name == "Coin")
                    {
                        i++;
                        removelist.AddLast(xy);
                        player.CoinCounter++;
                        player.Experience = player.Experience + 2;
                    }
                    if (enemydetect == true && xy.Name == "Slime" && player.IsDamaged == false)
                    {
                        i++;
                        player.playerDamaged();
                    }
                }
                else
                {
                    i++;
                }
            }
            if (coindetect == true)
            {
                foreach (Shape xy in removelist)
                {
                    canvas.Children.Remove(xy);
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
        public static bool CollisionDetectLeft(Canvas canvas, Player player, bool coindetect, bool enemydetect)
        {
            int i;
            bool left;
            LinkedList<Shape> removelist = new LinkedList<Shape>();


            i = 0;
            foreach (Shape xy in canvas.Children)
            {
                if (player.IsAttacking == true && player.Left >= Canvas.GetLeft(xy) - player.Width - 40 && player.Left - 40 <= Canvas.GetLeft(xy) + xy.Width && player.Top > Canvas.GetTop(xy) - player.Height && player.Top < Canvas.GetTop(xy) - player.Height + 5)
                {
                    if (enemydetect == true && xy.Name == "Slime")
                    {
                        i++;
                        removelist.AddLast(xy);
                        player.SlimeKilled++;
                        player.Experience = player.Experience + 5;
                    }
                }

                if (player.Top >= Canvas.GetTop(xy) - player.Height && player.Top <= Canvas.GetTop(xy) + xy.Height && player.Left > Canvas.GetLeft(xy) - player.Width && player.Left < Canvas.GetLeft(xy) - player.Width + 10)
                {
                    if (coindetect == true && xy.Name == "Coin")
                    {
                        i++;
                        removelist.AddLast(xy);
                        player.CoinCounter++;
                        player.Experience = player.Experience + 2;
                    }
                    if (enemydetect == true && xy.Name == "Slime" && player.IsDamaged == false)
                    {
                        i++;
                        player.playerDamaged();
                        
                    }
                }
                else
                {
                    i++;
                }
            }
            if (coindetect == true)
            {
                foreach (Shape xy in removelist)
                {
                    canvas.Children.Remove(xy);
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
        public static void CollisonDetectAll(Canvas shapecanvas, Player player, bool coindetect, bool enemydetect)
        {
            CollisionDetectTop(shapecanvas, player, coindetect, enemydetect);
            CollisionDetectBottom(shapecanvas, player, coindetect, enemydetect);
            CollisionDetectLeft(shapecanvas, player, coindetect, enemydetect);
            CollisionDetectRight(shapecanvas, player, coindetect, enemydetect);
        }
    }
}
