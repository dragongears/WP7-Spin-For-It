using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;

namespace SpinForIt
{
    public partial class Spinner : UserControl
    {
        int dur;

        public string ImageName 
        {
            set
            {
                this.img.Source = new BitmapImage(new Uri("images/" + value + ".png", UriKind.Relative));
            }
        }
        
        public double Rotation
        {
            get
            {
                return this.MyTransform.Rotation;
            }
            set
            {
                this.MyTransform.Rotation = value;
            }
        }

        public int Duration
        {
            get
            {
                return this.dur;
            }
            set
            {
                this.dur = value;
            }
        }

        public Spinner()
        {
            InitializeComponent();
        }

        public void spinIt()
        {
            Random random = new Random();
            int rndAdd = random.Next(0, 359);

            this.SpinAni.From = MyTransform.Rotation % 360;
            this.SpinAni.To = (360 * this.dur) + rndAdd;
            this.SpinAni.Duration = new Duration(TimeSpan.FromMilliseconds(this.dur * 500));
            this.Storyboard1.Begin();
        }
    }
}
