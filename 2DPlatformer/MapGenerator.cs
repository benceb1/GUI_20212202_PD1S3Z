using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _2DPlatformer
{
    class MapGenerator
    {
        public static void MapCreate(Canvas playground, int mapseed)
        {

            for (int i = 0; i <= 30000; i += 200)
            {
                Random rnd = new Random(i * mapseed);
                double rndRectHeight = rnd.Next(20, 50); //Tile height
                double rndRectWidth = rnd.Next(100, 500);//Tile width

                double rndX = rnd.Next(i + 50, i + 200);
                double rndY = rnd.Next(100, 500);        
                
                int rndCoin = rnd.Next(0, 2); //Tile has coins or not
                if (rndCoin == 1)
                {
                    int rndWidthint = (int)(rndRectWidth);
                    double tmpX = rndX;
                    int cnt = rndWidthint / 40;

                    for (int a = 0; a < cnt; a++)
                    {
                        new Coin(38, 38, playground, tmpX + (40 * a), rndY - 40);
                    }
                }

                Rectangle rect = new Rectangle();
                rect.Height = rndRectHeight;
                rect.Width = rndRectWidth;
                rect.StrokeThickness = 1;
                rect.Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri("pack://application:,,,/2DPlatformer;component/PNG/Tile/Tile.png", UriKind.Absolute))
                };
                rect.Stretch = Stretch.Fill;
                rect.RadiusX = 5;
                rect.RadiusY = 5;
                playground.Children.Add(rect);
                Canvas.SetLeft(rect, rndX);
                Canvas.SetTop(rect, rndY);
            }
        }
    }
}
