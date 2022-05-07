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
        Player player = new Player(73, 42, 1, 1, true);

        Animation anim = new Animation();
        SoundController soundcontroll = new SoundController();
        Task task1;
        Task task2;
        Task task3;
        public MainWindow()
        {
            DataContext = player;
            InitializeComponent();
            soundcontroll.PlayMusic();

            MapGenerator.MapCreate(game_canvas,4);

            Effects.EndTransiton(game_canvas, MainWindows_Page);
            var PhysicsTimer = new DispatcherTimer();
            var AnimationTimer = new DispatcherTimer();
            var CoinTimer = new DispatcherTimer();
            PhysicsTimer.Tick += PhysicsTimerTick;
            PhysicsTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);

            CoinTimer.Tick += CoinTimerTick;
            CoinTimer.Interval = new TimeSpan(0, 0, 0, 0, 50);

            AnimationTimer.Tick += AnimationTimerTick;
            AnimationTimer.Interval = new TimeSpan(0, 0, 0, 0, 140);
            task1 = new Task(PhysicsTimer.Start);
            task2 = new Task(AnimationTimer.Start);
            task3 = new Task(CoinTimer.Start);
            task1.Start();
            task2.Start();
            task3.Start();
            ;








        }

        private void PhysicsTimerTick(object sender, EventArgs e)
        {
            Controller.PlayerMove(game_canvas, player, true);
            Physics.Gravity(game_canvas, player);
            CameraFollow.CameraFollowPlayer(player, Scroller, 250);
            Effects.IngameParallexBackground4(background1, background2, background3, background4, background5, background6, background7, background8, 1,player.X ,MainWindows_Page.ActualWidth, Collision.CollisionDetectLeft(game_canvas, player, false), Collision.CollisionDetectRight(game_canvas, player, false));
        }
        private void AnimationTimerTick(object sender, EventArgs e)
        {
            anim.PlayerAnimation(player_canvas, player);

        }

        public void CoinTimerTick(object sender, EventArgs e)
        {
            anim.PlayCoinAnimation(game_canvas, player, 600);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            player.X = Controller.MoveX(sender, e, player.X, player.VelocityX);
            player.Y = Controller.MoveY(sender, e, player.Y, player.VelocityY, Collision.CollisionDetectTop(game_canvas, player, false));

            if (e.Key == Key.Escape)
            {
                this.NavigationService.Navigate(new Titlescreen());
            }
        }
        private void OnGameOver(Player sender, int e)
        {
            NavigationService.Navigate(new Titlescreen());
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            player.X = Controller.ResetX(sender, e, player.X);
            player.Y = Controller.ResetY(sender, e, player.Y);
        }
        

    }
}
