using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace _04___Mouse_and_keyboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Sailboat sailboat = new Sailboat();

        public MainWindow()
        {
            InitializeComponent();

            Thread.Sleep(1000);
            Debug.WriteLine("FontSize is now: " + FontSize);
            Debug.WriteLine("WindowSize is: " + Height + " by " + Width);
        }

        private void CalculateHS_Click(object sender, RoutedEventArgs e)
        {
            sailboat.Name = NameBox.Text;
            try
            {
                sailboat.Length = double.Parse(LenghtBox.Text);
            }
            catch (System.FormatException)
            {
                sailboat.Length = -1;
            }

            Debug.WriteLine("Boatname set to: " + sailboat.Name.ToString());
            Debug.WriteLine("Boatlenght set to: " + sailboat.Length.ToString());

            HSResultBlock.Text = sailboat.Hullspeed().ToString(format: "F");
        }

        private void MainWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            int fontSizeChangeRate = 5;
            int windowSizeChangeRate = 100;
            double windowsRadio = Width / Height;

            if ((Keyboard.Modifiers & ModifierKeys.Control) != 0 && e.Key == Key.L)
            {
                Debug.WriteLine("Ctrl+L was pressed.");
                if (FontSize < 100)
                {
                    FontSize += fontSizeChangeRate;

                    Height += windowSizeChangeRate;
                    Width = windowsRadio * Height;

                    Debug.WriteLine("FontSize is now: " + FontSize);
                    Debug.WriteLine("WindowSize is: " + Height + " by " + Width);
                }
            }

            if ((Keyboard.Modifiers & ModifierKeys.Control) != 0 && e.Key == Key.S)
            {
                Debug.WriteLine("Ctrl+S was pressed.");
                if (FontSize > 12)
                {
                    FontSize -= fontSizeChangeRate;

                    Height -= windowSizeChangeRate;
                    Width = windowsRadio * Height;

                    Debug.WriteLine("FontSize is now: " + FontSize);
                    Debug.WriteLine("WindowSize is: " + Height + " by " + Width);
                }
            }
        }

        //private void Image_OnMouseMove(object sender, MouseEventArgs e)
        //{
        //    string messageForUser;

        //    if (sailboat.Name == null)
        //    {
        //        messageForUser = "The boat has not been given a name yet";
        //    }
        //    else if (sailboat.Name == "")
        //    {
        //        messageForUser = "The boat has lost its name";
        //    }
        //    else
        //    {
        //        messageForUser = "The name of the boat is " + sailboat.Name;
        //    }

        //    MessageBox.Show(messageForUser, "Windows Admin", MessageBoxButton.OK, MessageBoxImage.Information);
        //}

        private void ImageButton_OnClick(object sender, RoutedEventArgs e)
        {
            string messageForUser;

            if (sailboat.Name == null)
            {
                messageForUser = "The boat has not been given a name yet";
            }
            else if (sailboat.Name == "")
            {
                messageForUser = "The boat has lost its name";
            }
            else
            {
                messageForUser = "The name of the boat is " + sailboat.Name;
            }

            MessageBox.Show(messageForUser, "Windows Admin", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
