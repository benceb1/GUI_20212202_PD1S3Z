using _2DPlatformer.Enemies.Slime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace _2DPlatformer
{
    
   
    public class Animation
    {
        List<string> slimechar = new List<string>
        {
              "pack://application:,,,/2DPlatformer;component/PNG/Enemies/Slime/Idle1.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Enemies/Slime/Idle2.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Enemies/Slime/Idle3.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Enemies/Slime/Idle4.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Enemies/Slime/Idle5.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Enemies/Slime/Idle6.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Enemies/Slime/Idle7.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Enemies/Slime/Idle8.png",
              "pack://application:,,,/2DPlatformer;component/PNG/Enemies/Slime/Idle9.png",         
        };
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
        int playerattack1animationcounter = 0;
        int playerattack2animationcounter = 0;
        int playerattack3animationcounter = 0;
        int coinCounter = 0;
        int slimeCounter = 0;
        public void PlayerAnimation(Rectangle PlayerCanvas, Player player)
        {
            if (player.IsAttacking == false) 
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
        }
        public void PlayerAttackAnimation(Rectangle playercanvas,Player player, int attacknumber)
        {
            if (player.IsAttacking == true)
            {
                    if (playerattack1animationcounter >= attackanim1.Count)
                    {
                        playerattack1animationcounter = 0;
                        player.IsAttacking = false;
                    }
                    if (playerattack2animationcounter >= attackanim2.Count)
                    {
                        playerattack2animationcounter = 0;
                        player.IsAttacking = false;
                    }
                    if (playerattack3animationcounter >= attackanim3.Count)
                    {
                        playerattack3animationcounter = 0;
                        player.IsAttacking = false;
                    }
                    if (attacknumber == 1)
                    {

                            playercanvas.Fill = new ImageBrush
                            {
                                ImageSource = new BitmapImage(new Uri(attackanim1[playerattack1animationcounter], UriKind.Absolute))
                            };
                        
                    }
                    else if (attacknumber == 2)
                    {
                            playercanvas.Fill = new ImageBrush
                            {
                                ImageSource = new BitmapImage(new Uri(attackanim2[playerattack2animationcounter], UriKind.Absolute))
                            };
                        
                    }
                    else if (attacknumber == 3)
                    {
                            playercanvas.Fill = new ImageBrush
                            {
                                ImageSource = new BitmapImage(new Uri(attackanim3[playerattack3animationcounter], UriKind.Absolute))
                            };
                        
                    }
                playerattack1animationcounter++;
                playerattack2animationcounter++;
                playerattack3animationcounter++;






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
        public void SlimeAnimation(Rectangle rect)
        {
            if (slimeCounter >= slimechar.Count)
            {
                slimeCounter = 0;
            }
            rect.Fill = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(slimechar[slimeCounter], UriKind.Absolute))
            };
            slimeCounter++;
        }
        public void PlaySlimeAnimation(Canvas playground)
        {
            if (slimeCounter >= slimechar.Count)
            {
                slimeCounter = 0;
            }
            foreach (Shape element in playground.Children)
            {
                if (Equals(element.GetType(), typeof(Rectangle)) && element.Name=="Slime")
                {
                    element.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri(slimechar[slimeCounter], UriKind.Absolute))
                    };
                }

            }
            slimeCounter++;
        }
        public void PlayCoinAnimation(Canvas playground)
        {

            if (coinCounter >= coinanimation.Count)
            {
                coinCounter = 0;
            }
            foreach (Shape element in playground.Children)
            {
                if (Equals(element.GetType(), typeof(Ellipse)))
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
