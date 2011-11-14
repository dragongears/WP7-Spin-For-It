using System;
using System.Windows;
using System.Windows.Controls;
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
        }

        // Main page loaded
        private void MainPageSetup()
        {
            switch (Settings.Duration.Value)
            {
                case 2:
                    rdoDurShort.IsChecked = true; break;
                case 6:
                    rdoDurNormal.IsChecked = true; break;
                case 20:
                    rdoDurLong.IsChecked = true; break;
            }

            MySpinner.Duration = Settings.Duration.Value;

            switch (Settings.Type.Value)
            {
                case "hand":
                    rdoHand.IsChecked = true; break;
                case "arrow":
                    rdoArrow.IsChecked = true; break;
                case "bottle":
                    rdoBottle.IsChecked = true; break;
                case "pointer":
                    rdoPointer.IsChecked = true; break;
            }

            MySpinner.ImageName = Settings.Type.Value;
            
            Random random = new Random();
            MySpinner.Rotation = random.Next(0, 359);

        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            MainPageSetup();
        }

        void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            // Save the chosen setting
            int dur = int.Parse((sender as RadioButton).Tag.ToString());
            Settings.Duration.Value = dur;
            MySpinner.Duration = dur;
        }

        void TypeRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            // Save the chosen setting
            String type = (sender as RadioButton).Tag.ToString();
            Settings.Type.Value = type;
            MySpinner.ImageName = Settings.Type.Value;
        }

        private void MySpinner_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MySpinner.spinIt();
        }

    }
}