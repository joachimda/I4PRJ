using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
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

namespace SWDGUI
{
    /// <summary>
    /// Interaction logic for WinLoginView.xaml
    /// </summary>
    public partial class WinLoginView : Window
    {
        public WinLoginView()
        {
            InitializeComponent();
            ThemeProperties.SetPlaceholderText(EmailTextBox, "E-mail");
            ThemeProperties.SetPlaceholderText(TextBoxPassword, "Password");
        }

        private void Control_MouseEnter(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            if (control == null) return;
            control.Foreground = new SolidColorBrush(Color.FromRgb(0xFD, 0xA0, 0x29));
        }

        private void Control_MouseLeave(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            if (control == null) return;
            control.Foreground = new SolidColorBrush(Color.FromRgb(0xAB, 0xAB, 0xAC));
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Email: {EmailTextBox.Text}\nPass: {TextBoxPassword.Text}");
        }
    }

    public static class ThemeProperties
    {
        public static string GetPlaceholderText(DependencyObject obj)
        {
            return (string) obj.GetValue(PlaceholderTextProperty);
        }

        public static void SetPlaceholderText(DependencyObject obj, string value)
        {
            obj.SetValue(PlaceholderTextProperty, value);
        }

        public static readonly DependencyProperty PlaceholderTextProperty =
            DependencyProperty.RegisterAttached(
                "PlaceholderText",
                typeof (string),
                typeof (ThemeProperties),
                new FrameworkPropertyMetadata("Placeholder"));
    }
}