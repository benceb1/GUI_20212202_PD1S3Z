using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace _2DPlatformer
{
    static class Controller
    {
        public static double MoveX(object sender, KeyEventArgs e, double x, double changeX)
        {
            if (e.Key == Key.A)
            {
                x = -changeX;
            }
            if (e.Key == Key.D)
            {
                x = changeX;
            }
            return x;
        }
        public static double MoveY(object sender, KeyEventArgs e, double y, double changeY, bool top)
        {
            if (e.Key == Key.W && top)
            {
                y = -changeY;
            }
            if (e.Key == Key.S)
            {
                //y = changeY / 2;
            }
            return y;
        }
        public static double ResetX(object sender, KeyEventArgs e, double x)
        {
            if (e.Key == Key.A)
            {
                x = 0;
            }
            if (e.Key == Key.D)
            {
                x = 0;
            }
            return x;
        }
        public static double ResetY(object sender, KeyEventArgs e, double y)
        {
            if (e.Key == Key.S)
            {
                //y = 0;
            }
            return y;
        }
        
        public static void PlayerMove(Canvas playground, Player player, bool coindetect, bool enemydetect)
        {

            if (Collision.CollisionDetectTop(playground, player, coindetect, enemydetect) == false && Collision.CollisionDetectBottom(playground, player, coindetect, enemydetect) == false)
            {
                player.Top += player.Y;
            }
            else
            {
                if (player.Y < 0 && Collision.CollisionDetectTop(playground, player, coindetect, enemydetect) == true)
                {
                    player.Top += player.Y;

                }
                if (player.Y > 0 && Collision.CollisionDetectBottom(playground, player, coindetect, enemydetect) == true)
                {
                    player.Top += player.Y;
                }
            }
            if (Collision.CollisionDetectRight(playground, player, coindetect, enemydetect) == false && Collision.CollisionDetectLeft(playground, player, coindetect, enemydetect) == false)
            {
                player.Left += player.X;
            }
            else
            {
                if (player.X < 0 && Collision.CollisionDetectLeft(playground, player, coindetect, enemydetect) == true)
                {
                    player.Left += player.X;
                }
                if (player.X > 0 && Collision.CollisionDetectRight(playground, player, coindetect, enemydetect) == true)
                {
                    player.Left += player.X;
                }
            }
        }
    }
}
