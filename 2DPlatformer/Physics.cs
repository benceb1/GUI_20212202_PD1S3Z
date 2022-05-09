using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _2DPlatformer
{
    class Physics
    {
        public static void Gravity(Canvas map, Player player)
        {
            if (Collision.CollisionDetectTop(map, player, false,false) == false)
            {
                player.Y += 0.15;
            }
            else
            {
                player.Y = 0;
            }
        }

    }
}
