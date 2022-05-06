using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformer
{
    class Player : _2DPlatformerObject
    {
        public delegate void GameOverEventHandler(Player sender, int e);
        public event GameOverEventHandler GameOver;

        private double x;
        private double y;

        private double velocityX = 3;
        private double velocityY = 5;

        private int coinCounter = 0;

        private bool endofgame = false;
        private bool singleplayer;

        



        public Player(double height, double width, double left, double top, bool _singleplayer)
        {
            singleplayer = _singleplayer;
            Height = height;
            Width = width;
            Left = left;
            Top = top;
            
            
        }
        public double X
        {
            get { return x; }
            set { x = value; NotifyPropertyChanged(); }
        }
        public double Y
        {
            get { return y; }
            set { y = value; NotifyPropertyChanged(); }
        }
        public double VelocityX
        {
            get { return velocityX; }
            set { velocityX = value; }
        }
        public double VelocityY
        {
            get { return velocityY; }
            set { velocityY = value; }
        }

        public override double Top
        {
            get { return top; }
            set
            {
                if (value < 800)
                {
                    top = value; 
                    NotifyPropertyChanged();
                }
                else if (endofgame == false)
                {
                    OnGameOver();
                    endofgame = true;
                }
            }
        }
        
        public bool Singleplayer
        {
            get { return singleplayer; }
            set { singleplayer = value; }
        }
        public int CoinCounter
        {
            get { return coinCounter; }
            set { coinCounter = value; NotifyPropertyChanged(); }

        }


        public virtual void OnGameOver()
        {
            if (GameOver != null)
            {
                GameOver(this, CoinCounter);
            }
        }
    }
}
