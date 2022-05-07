using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _2DPlatformer
{
    
   
    class Animation
    {       
        List<string> idlechar = new List<string>

        {
              "pack://application:,,,/2DPlatformer;component/PNG/Character/adventurer-idle-2-00.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Character/adventurer-idle-2-01.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Character/adventurer-idle-2-02.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Character/adventurer-idle-2-03.png",

        };
        List<string> runchar = new List<string>
        {
              "pack://application:,,,/2DPlatformer;component/PNG/Character/adventurer-run-00.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Character/adventurer-run-01.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Character/adventurer-run-02.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Character/adventurer-run-03.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Character/adventurer-run-04.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Character/adventurer-run-05.png",
        };
        List<string> jumpchar = new List<string>
        {
              "pack://application:,,,/2DPlatformer;component/PNG/Character/adventurer-jump-00.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Character/adventurer-jump-01.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Character/adventurer-jump-02.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Character/adventurer-jump-03.png",
        };
        List<string> attackanim1 = new List<string>
        {
              "pack://application:,,,/2DPlatformer;component/PNG/Character/adventurer-attack1-00.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Character/adventurer-attack1-01.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Character/adventurer-attack1-02.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Character/adventurer-attack1-03.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Character/adventurer-attack1-04.png"
        };
        List<string> attackanim2 = new List<string>
        {
              "pack://application:,,,/2DPlatformer;component/PNG/Character/adventurer-attack2-00.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Character/adventurer-attack2-01.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Character/adventurer-attack2-02.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Character/adventurer-attack2-03.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Character/adventurer-attack2-04.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Character/adventurer-attack2-05.png",
        };
        List<string> attackanim3 = new List<string>
        {
              "pack://application:,,,/2DPlatformer;component/PNG/Character/adventurer-attack3-00.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Character/adventurer-attack3-01.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Character/adventurer-attack3-02.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Character/adventurer-attack3-03.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Character/adventurer-attack3-04.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Character/adventurer-attack3-05.png",
        };
        List<string> coinanimation = new List<string>
        {     "pack://application:,,,/2DPlatformer;component/PNG/Coin/0.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Coin/1.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Coin/2.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Coin/3.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Coin/4.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Coin/5.png",
        };
        List<string> fallanimation = new List<string>
        {
            "pack://application:,,,/2DPlatformer;component/PNG/Character/adventurer-fall-00.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Character/adventurer-fall-01.png"
        };
        int playeranimationcounter = 0;
        int playerjumpanimationcounter = 0;
        int playerfallanimationcounter = 0;
        int coinCounter = 0;
        public void PlayerAnimation(Rectangle PlayerCanvas, Player player)
        {
            if (player.X == 0 && player.Y==0)
            {
                if (playeranimationcounter >= idlechar.Count)
                {
                    playeranimationcounter = 0;
                }
                PlayerCanvas.Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(idlechar[playeranimationcounter], UriKind.Absolute))
                };
                playeranimationcounter++;
            }
            else if(player.X!=0&&player.Y==0)
            {
                if (player.X < 0)
                {
                    PlayerCanvas.LayoutTransform = new ScaleTransform(1, 1, 0, 0);
                }
                else
                {
                    PlayerCanvas.LayoutTransform = new ScaleTransform(-1, 1, 0, 0);
                }

                if (playeranimationcounter >= runchar.Count)
                {
                    playeranimationcounter = 0;
                }
                PlayerCanvas.Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(runchar[playeranimationcounter], UriKind.Absolute))
                };
                playeranimationcounter++;
            }
            else if(player.Y!=0)
            {
                if(player.Y!=0 && player.X<0)
                {
                    PlayerCanvas.LayoutTransform = new ScaleTransform(1, 1, 0, 0);
                }
                else if(player.Y!=0&&player.X>0)
                {
                    PlayerCanvas.LayoutTransform = new ScaleTransform(-1, 1, 0, 0);
                }
                if (playerjumpanimationcounter >= jumpchar.Count)
                {
                    playerjumpanimationcounter = 0;
                }
                if(playerfallanimationcounter >= fallanimation.Count)
                {
                    playerfallanimationcounter = 0;
                }
                if(player.Y<0)
                {
                    PlayerCanvas.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri(jumpchar[playerjumpanimationcounter], UriKind.Absolute))
                    };
                }
                else if(player.Y>0)
                {
                    PlayerCanvas.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri(fallanimation[playerfallanimationcounter], UriKind.Absolute))
                    };
                }              
                playerfallanimationcounter++;
                playerjumpanimationcounter++;
            }
        }
        public void CoinAnimation(Shape coin)
        {
            if (coinCounter >= coinanimation.Count)
            {
                coinCounter = 0;
            }
            coin.Fill = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(coinanimation[coinCounter], UriKind.Absolute))
            };
            coinCounter++;
        }
        public void PlayCoinAnimation(Canvas playground, Player player, double visibleOffset)
        {

            if (coinCounter >= coinanimation.Count)
            {
                coinCounter = 0;
            }
            foreach (Shape element in playground.Children)
            {
                if (Equals(element.GetType(), typeof(Ellipse)) && (Canvas.GetLeft(element) > player.Left - visibleOffset && Canvas.GetLeft(element) < player.Left + visibleOffset))
                {
                    element.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri(coinanimation[coinCounter], UriKind.Absolute))
                    };
                }

            }
            coinCounter++;

        }

    }
}
