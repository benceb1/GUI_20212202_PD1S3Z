using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlatformer
{
    public abstract class _2DPlatformerObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected double height;
        protected double width;
        protected double top;
        protected double left;
        protected void NotifyPropertyChanged(String propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public virtual double Height
        {
            get { return height; }
            set { height = value; NotifyPropertyChanged(); }
        }
        public virtual double Width
        {
            get { return width; }
            set { width = value; NotifyPropertyChanged(); }
        }
        public virtual double Top
        {
            get { return top; }
            set { top = value; NotifyPropertyChanged(); }
        }
        public virtual double Left
        {
            get { return left; }
            set { left = value; NotifyPropertyChanged(); }
        }
    }
}
