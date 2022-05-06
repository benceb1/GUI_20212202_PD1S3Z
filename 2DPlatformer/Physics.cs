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
        public static void Gravity(Canvas playground, Player playerobj)
        {
            if (Collision.CollisionDetectTop(playground, playerobj, false) == false)
            {
                playerobj.Y += 0.15;
            }
            else
            {
                playerobj.Y = 0;
            }
        }

    }
}
