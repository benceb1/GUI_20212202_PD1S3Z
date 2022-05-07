using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _2DPlatformer
{
    public class SoundController
    {
        MediaPlayer musicplayer;
        public void PlaySound(Rectangle Player_Canvas, double x, double y)
        {
        }
        public void PlayMusic()
        {
            musicplayer = new MediaPlayer();
            musicplayer.Open(new Uri("pack://siteoforigin:,,,/Sounds/Music/TitleMusic.mp3"));
            musicplayer.MediaEnded += new EventHandler(Media_Ended);
            musicplayer.Play();
            void Media_Ended(object sender, EventArgs e)
            {
                musicplayer.Position = TimeSpan.Zero;
                musicplayer.Play();
            }
        }
    }
}
