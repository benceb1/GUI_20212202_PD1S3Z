using _2DPlatformer.GameMongoClient;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _2DPlatformer.ViewModels
{
    public class PlayerListViewModel
    {
        public List<PlayerModel> Players { get; set; }

        public ICommand BackToMainMenuCommand { get; set; }

        public PlayerListViewModel()
        {
            var collection = GameDatabase.GetPlayers();
            Players = new List<PlayerModel>(collection);

            BackToMainMenuCommand = new RelayCommand(() => StartupWindow.PublicStartupFrame.Content = new Titlescreen());
        }
    }
}
