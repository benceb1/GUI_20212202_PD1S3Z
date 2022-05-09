using _2DPlatformer.GameMongoClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace _2DPlatformer
{
    public class Player : _2DPlatformerObject
    {
        public delegate void GameOverEventHandler(Player sender, int e);
        public event GameOverEventHandler GameOver;

        private string id;
        private double x; //Current X velocity of character 
        private double y; //Current Y velocity of character 

        private double velocityX = 3; // Change in velocity during movement
        private double velocityY = 6; // Change in velocity during movement

        private bool endofgame = false;
        private bool singleplayer;
        private int health = 100;
        private int xpneededtolvlup = 10;
        private bool isAttacking = false;
        private bool isFiring = false;
        private bool isDamaged = false;
        
        
        private int experience = 0; // Experience of the player
        private int level = 1;
        private int coinCounter = 0; //Ammount of coin picked up
        private int slimeKilled = 0;
        private string name;
        public void playerDamaged()
        {
            IsDamaged = true;
            Health = Health - 10;
            DispatcherTimer hptimer = new DispatcherTimer();
            hptimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            int count = 0;
            hptimer.Start();
            hptimer.Tick += (sender, e) =>
             {
                 if (count == 3)
                 {
                     IsDamaged = false;
                     hptimer.Stop();
                 }
                 count++;
             };
        }

        public Player(double height, double width, double left, double top, bool _singleplayer)
        {
            Singleplayer = _singleplayer;
            Height = height;
            Width = width;
            Left = left;
            Top = top;
            Health = health;
        }

        public Player(double height, double width, double left, double top, bool _singleplayer, PlayerModel playerModel) : this(height, width, left, top, _singleplayer)
        {
            this.id = playerModel.Id;
            this.name = playerModel.Name;
            this.experience = playerModel.Experience;
            this.level = playerModel.Level;
            this.coinCounter = playerModel.CoinCounter;
            this.slimeKilled = playerModel.SlimeKilled;
            this.health = playerModel.Health;
        }

        public int SlimeKilled
        {
            get { return slimeKilled; }
            set { slimeKilled = value; NotifyPropertyChanged(); }
        }

        public bool CanUseBow()
        {
            if (this.Level >= 2)
            {
                return true;
            }
            else return false;
        }
        public int Level
        {
            get { return level; }
            set
            {
                level = value;
                NotifyPropertyChanged();
            }
        }
        public bool IsDamaged
        {
            get { return isDamaged; }
            set{
                isDamaged = value;
            }
        }
        public bool IsAttacking
        {
            get { return isAttacking; }
            set { isAttacking = value; }
        }
        public bool IsFiring
        {
            get { return isFiring; }
            set
            {
                isFiring = value;
            }
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
        public int Health
        {
            get { return health; }
            set
            {
                if(value>0)
                {
                    health = value;
                    NotifyPropertyChanged();
                }
                
                if (value <= 0&&endofgame==false)
                {

                    OnGameOver();
                    endofgame = true;
                }
            }
        }
        public int Experience
        {
            get { return experience; }
            set
            {
                if (value >= xpneededtolvlup)
                {
                    Level++;
                    Experience = 0;
                    Health = 100;
                    NotifyPropertyChanged();
                }
                else if(value< xpneededtolvlup)
                {
                    experience = value;
                    NotifyPropertyChanged();
                }
                
            }
        }

        public bool Singleplayer
        {
            get { return singleplayer; }
            set { singleplayer = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual void OnGameOver()
        {
            if (GameOver != null)
            {
                GameOver?.Invoke(this, Experience);
            }
        }

        public PlayerModel ToPlayerModel()
        {
            return new PlayerModel()
            {
                Id = this.id,
                CoinCounter = this.CoinCounter,
                Experience = this.Experience,
                Health = this.Health,
                Level = this.Level,
                Name = this.Name,
                SlimeKilled = this.SlimeKilled
            };
        }
    }
}
