using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _2DPlatformer
{
    static class CameraFollow
    {
        public static void CameraFollowPlayer(Player playerobj, ScrollViewer scroller, double offset)
        {
            scroller.ScrollToHorizontalOffset(playerobj.Left - offset);
            scroller.ScrollToVerticalOffset(playerobj.Top - offset);
        }
    }
}
