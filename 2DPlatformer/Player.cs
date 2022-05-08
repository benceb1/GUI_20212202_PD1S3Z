using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformer
{
    public class Player : _2DPlatformerObject
    {
        public delegate void GameOverEventHandler(Player sender, int e);
        public event GameOverEventHandler GameOver;

        private double x; //Current X velocity of character 
        private double y; //Current Y velocity of character 

        private double velocityX = 3; // Change in velocity during movement
        private double velocityY = 6; // Change in velocity during movement



        private bool endofgame = false;
        private bool singleplayer;
        private int health = 100;
        private bool isAttacking = false;
        private bool isDealingDamage;
        private int experience = 0; // Experience of the player
        private int coinCounter = 0; //Ammount of coin picked up

        



        public Player(double height, double width, double left, double top, bool _singleplayer)
        {
            Singleplayer = _singleplayer;
            Height = height;
            Width = width;
            Left = left;
            Top = top;
            Health = health;
            isDealingDamage = false;

            
            
        }
        public bool IsDealingDamage
        {
            get { return isDealingDamage; }
            set
            {
                isDealingDamage = value;
            }
        }
        public bool IsAttacking
        {
            get { return isAttacking; }
            set { isAttacking = value; }
        }
        public int CoinCounter
        {
            get { return coinCounter; }
            set { coinCounter = value; NotifyPropertyChanged(); }
        }
        public double X
        {
            get { return x; }
            set { x = value; NotifyPropertyChanged(); }
        }
        public double Y
        {
            get { return y; }
            set { y = value; 
                NotifyPropertyChanged(); 
            }
        }
        public int Health
        {
            get { return health; }
            set
            {
                health = value;
                NotifyPropertyChanged();
            }
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
        public int Experience
        {
            get { return experience; }
            set
            {
                experience = value;
                NotifyPropertyChanged();
            }
        }

        public override double Top
        {
            get { return top; }
            set
            {
                if (value < 768)
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
        


        public virtual void OnGameOver()
        {
            if (GameOver != null)
            {
                GameOver?.Invoke(this, Experience);
            }
        }
    }
}
