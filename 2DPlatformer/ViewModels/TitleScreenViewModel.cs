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
                        MessageBox.Show("Nincs ilyen játékos!");
                    }
                    else
                    {
                        Effects.Transition<MainWindow>(canvas, playerModel);
                    }
                }
                else
                {
                    MessageBox.Show("Üres a játékos név!");
                }
            });

            CreatePlayerCommand = new RelayCommand(() =>
            {
                if (PlayerName != null && PlayerName.Length > 0)
                {
                    var playerModel = GameDatabase.GetPlayers().FirstOrDefault(x => x.Name == PlayerName);
                    if (playerModel == null)
                    {
                        var newPlayer = GameDatabase.CreatePlayer(new PlayerModel() { Name = PlayerName, Score = 0 });
                        Effects.Transition<MainWindow>(canvas, playerModel);
                    }
                    else
                    {
                        MessageBox.Show("Ilyen játékos már létezik!");
                    }
                }
                else
                {
                    MessageBox.Show("Üres a játékos név!");
                }
            });
        }

        public void SetupCanvas(Canvas canvas)
        {
            this.canvas = canvas;
        }
    }
}
