using _2DPlatformer.ViewModels;
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

namespace _2DPlatformer
{
    /// <summary>
    /// Interaction logic for Titlescreen.xaml
    /// </summary>
    public partial class Titlescreen : Page
    {
        int clck = 0;
        public Titlescreen()
        {
            InitializeComponent();
            TitleScreenViewModel viewModel = new TitleScreenViewModel();
            viewModel.SetupCanvas(title_canvas);
            this.DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (clck == 0)
            {
                //Effects.Transition<MainWindow>(title_canvas, Title_page);
                //Title_page.NavigationService.Navigate(new MainWindow());
                clck++;
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
