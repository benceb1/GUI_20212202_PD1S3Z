using _2DPlatformer.GameMongoClient;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _2DPlatformer.ViewModels
{
    public class TitleScreenViewModel : ObservableRecipient
    {
        public string PlayerName { get; set; }

        Canvas canvas;

        public ICommand ListPlayersCommand { get; set; }
        public ICommand LoginPlayerCommand { get; set; }
        public ICommand CreatePlayerCommand { get; set; }

        public TitleScreenViewModel()
        {
            ListPlayersCommand = new RelayCommand(() =>
            {
                StartupWindow.PublicStartupFrame.Navigate(new PlayerListPage());
            });

            LoginPlayerCommand = new RelayCommand(() =>
            {
                if (PlayerName != null && PlayerName.Length > 0)
                {
                    var playerModel = GameDatabase.GetPlayers().FirstOrDefault(x => x.Name == PlayerName);
                    if (playerModel == null)
                    {
                        MessageBox.Show("No such player!");
                    }
                    else
                    {
                        Effects.Transition<MainWindow>(canvas, playerModel);
                    }
                }
                else
                {
                    MessageBox.Show("The player name is empty!");
                }
            });

            CreatePlayerCommand = new RelayCommand(() =>
            {
                if (PlayerName != null && PlayerName.Length > 0)
                {
                    var playerModel = GameDatabase.GetPlayers().FirstOrDefault(x => x.Name == PlayerName);
                    if (playerModel == null)
                    {
                        var newPlayer = GameDatabase.CreatePlayer(
                            new PlayerModel() { Name = PlayerName, CoinCounter = 0, Experience = 0, Health = 100, Level = 1, SlimeKilled = 0 });
                        Effects.Transition<MainWindow>(canvas, newPlayer);
                    }
                    else
                    {
                        MessageBox.Show("Such a player already exists!");
                    }
                }
                else
                {
                    MessageBox.Show("The player name is empty!");
                }
            });
        }

        public void SetupCanvas(Canvas canvas)
        {
            this.canvas = canvas;
        }
    }
}
