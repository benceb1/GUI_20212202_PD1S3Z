using _2DPlatformer.GameMongoClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace _2DPlatformer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Page
    {
        Player player;
        private int attacknumber=1;
        Animation anim = new Animation();
        List<Projectile> projectiles = new List<Projectile>();
        SoundController soundcontroll = new SoundController();
        Task task1;
        Task task2;
        Task task3;
        Task task4;
        Task task5;
        Task task6;

        static Random randomattack = new Random();

        public MainWindow(PlayerModel playerModel)
        {
            this.player = new Player(80, 50, 1, 1, true, playerModel);
            DataContext = player;
            InitializeComponent();
            soundcontroll.PlayMusic();

            MapGenerator.MapCreate(game_canvas,4);

            Effects.EndTransiton(game_canvas, MainWindows_Page);
            var PhysicsTimer = new DispatcherTimer();
            var AnimationTimer = new DispatcherTimer();
            var AttackAnimationTimer = new DispatcherTimer();
            var CoinTimer = new DispatcherTimer();
            var SlimeTimer = new DispatcherTimer();
            var ProjectileTimer= new DispatcherTimer();

            ProjectileTimer.Tick += ProjectileTick;
            ProjectileTimer.Interval= new TimeSpan(0, 0, 0, 0, 75);

            SlimeTimer.Tick += SlimeAnimationTick;
            SlimeTimer.Interval = new TimeSpan(0, 0, 0, 0, 75);

            AttackAnimationTimer.Tick += AttackAnimationTick;
            AttackAnimationTimer.Interval = new TimeSpan(0, 0, 0, 0, 200);

            PhysicsTimer.Tick += PhysicsTimerTick;
            PhysicsTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);

            CoinTimer.Tick += CoinTimerTick;
            CoinTimer.Interval = new TimeSpan(0, 0, 0, 0, 50);

            AnimationTimer.Tick += AnimationTimerTick;
            AnimationTimer.Interval = new TimeSpan(0, 0, 0, 0, 140);

            task1 = new Task(PhysicsTimer.Start);
            task2 = new Task(AnimationTimer.Start);
            task3 = new Task(CoinTimer.Start);
            task4 = new Task(AttackAnimationTimer.Start);
            task5 = new Task(SlimeTimer.Start);
            task6 = new Task(ProjectileTimer.Start);

            task1.Start();
            task2.Start();
            task3.Start();
            task4.Start();
            task5.Start();
            task6.Start();

            player.GameOver += OnGameOver;
        }

        private void AttackAnimationTick(object sender, EventArgs e)
        {
            anim.PlayerAttackAnimation(player_canvas, player, attacknumber);
        }

        private void PhysicsTimerTick(object sender, EventArgs e)
        {
            Controller.PlayerMove(game_canvas, player, true,true);
            Physics.Gravity(game_canvas, player);
            CameraFollow.CameraFollowPlayer(player, Scroller, 250);
            Effects.IngameParallexBackground4(background1, background2, background3, background4, background5, background6, background7, background8, 1,player.X ,MainWindows_Page.ActualWidth, Collision.CollisionDetectLeft(game_canvas, player, false,false), Collision.CollisionDetectRight(game_canvas, player, false,false));
        }
        private void AnimationTimerTick(object sender, EventArgs e)
        {
            anim.PlayerAnimation(player_canvas, player);

        }
        private void ProjectileTick(object sender,EventArgs e)
        {
            anim.ProjectileAnimation(game_canvas,player_canvas, player);
        }

        public void CoinTimerTick(object sender, EventArgs e)
        {
            anim.PlayCoinAnimation(game_canvas);
        }
        public void SlimeAnimationTick(object sender, EventArgs e)
        {
            anim.PlaySlimeAnimation(game_canvas);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            player.X = Controller.MoveX(sender, e, player.X, player.VelocityX);
            player.Y = Controller.MoveY(sender, e, player.Y, player.VelocityY, Collision.CollisionDetectTop(game_canvas, player, false,false));

            if (e.Key == Key.Escape)
            {
                GameDatabase.SavePlayer(player.ToPlayerModel());
                this.NavigationService.Navigate(new Titlescreen());
            }
            if(e.Key==Key.Space)
            {
                player.IsAttacking = true;
                if(attacknumber<3)
                {
                    attacknumber++;
                }
                if(attacknumber >=3)
                {                  
                    attacknumber = 1;
                }                   
            }
            if(e.Key==Key.LeftShift)
            {
               player.IsFiring = true;
            }
        }
        private void OnGameOver(Player sender, int e)
        {
            player.Health = 100;
            player.Experience = 0;
            player.Level = 0;
            GameDatabase.SavePlayer(player.ToPlayerModel());

            var result = MessageBox.Show("Try again?", "Game Over", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                soundcontroll.StopMusic();
                NavigationService.Navigate(new Titlescreen());
            }
            if (result == MessageBoxResult.No)
            {
                Application.Current.Shutdown();
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            player.X = Controller.ResetX(sender, e, player.X);
            player.Y = Controller.ResetY(sender, e, player.Y);
        }
        

    }
}
