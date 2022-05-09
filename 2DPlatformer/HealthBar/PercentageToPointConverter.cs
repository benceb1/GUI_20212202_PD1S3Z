using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace _2DPlatformer.HealthBar
{
    public class PercentageToPointConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int number = int.Parse(value.ToString());
            if(number >80)
            {
                return Brushes.LawnGreen;
            }
            if (number <= 80 && number > 60)
                return Brushes.LimeGreen;
            if (number <= 60 && number > 40)
                return Brushes.DarkOrange;
            if (number <= 40 && number > 20)
                return Brushes.OrangeRed;
            else return Brushes.Red;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
           return Binding.DoNothing;
        }
    }
}
