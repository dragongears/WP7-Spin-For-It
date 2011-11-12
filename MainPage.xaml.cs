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
using Microsoft.Phone.Controls;
using System.Windows.Media.Imaging;

namespace SpinForIt
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            Storyboard1.Completed += storyBoard_Completed;
        }

        // Main page loaded
        private void MainPageSetup()
        {
            switch (Settings.Duration.Value)
            {
                case 2:
                    this.rdoDurShort.IsChecked = true; break;
                case 6:
                    this.rdoDurNormal.IsChecked = true; break;
                case 20:
                    this.rdoDurLong.IsChecked = true; break;
            }

            switch (Settings.Type.Value)
            {
                case "hand":
                    this.rdoHand.IsChecked = true; break;
                case "arrow":
                    this.rdoArrow.IsChecked = true; break;
                case "bottle":
                    this.rdoBottle.IsChecked = true; break;
                case "pointer":
                    this.rdoPointer.IsChecked = true; break;
            }

            Random random = new Random();
            MyTransform.Rotation = random.Next(0, 359);

        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            MainPageSetup();
        }


        private void spinIt()
        {
            Random random = new Random();
            int rndAdd = random.Next(0, 359);

            SpinAni.From = MyTransform.Rotation % 360;
            SpinAni.To = (360 * Settings.Duration.Value) + rndAdd;
            SpinAni.Duration = new Duration(TimeSpan.FromMilliseconds(Settings.Duration.Value*500));
            Storyboard1.Begin();
        }

        void storyBoard_Completed(object sender, EventArgs e)
        {
        }

        private void img_Tap(object sender, GestureEventArgs e)
        {
            spinIt();
        }

        private void img_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
        }

        void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            // Save the chosen setting
            int dur = int.Parse((sender as RadioButton).Tag.ToString());
            Settings.Duration.Value = dur;
        }

        void TypeRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            // Save the chosen setting
            String type = (sender as RadioButton).Tag.ToString();
            Settings.Type.Value = type;
            img.Source = new BitmapImage(new Uri("images/" + Settings.Type.Value + ".png", UriKind.Relative));
        }

    }
}