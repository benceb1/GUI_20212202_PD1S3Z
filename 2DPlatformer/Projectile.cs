﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace _2DPlatformer
{
    public class Projectile :_2DPlatformerObject
    {
        Rectangle rectangle = new Rectangle();
        Canvas ground;
        private int damage = 10;
        public int Damage
        {
            get { return damage; }
            set
            {
                damage = value;
            }
        }
        public Projectile(double width, double height, Canvas _ground, double left, double top)
        {
            Width = width;
            Height = height;
            ground = _ground;

            rectangle.Width = Width;
            rectangle.Height = Height;
            rectangle.Name = "Projectile";
            ground.Children.Add(rectangle);
            Canvas.SetLeft(rectangle, left);
            Canvas.SetTop(rectangle, top);
        }
    }
}
