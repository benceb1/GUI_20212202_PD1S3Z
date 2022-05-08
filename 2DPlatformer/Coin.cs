using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace _2DPlatformer
{
    class Coin : _2DPlatformerObject
    {
        Ellipse ellipse = new Ellipse();
        Canvas ground;
        public Coin(double width, double height, Canvas _ground, double left, double top)
        {            
            Width = width;
            Height = height;
            ground = _ground;
            ellipse.Name = "Coin";

            ellipse.Width = Width;
            ellipse.Height = Height;
            ground.Children.Add(ellipse);
            Canvas.SetLeft(ellipse, left);
            Canvas.SetTop(ellipse, top);
        }
    }
}
