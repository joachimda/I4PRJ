using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Smartpool.Application.Presentation;

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Win
{
    #region AttachedProperty
    public static class ThemeProperties
    {
        public static string GetPlaceholderText(DependencyObject obj)
        {
            return (string)obj.GetValue(PlaceholderTextProperty);
        }

        public static void SetPlaceholderText(DependencyObject obj, string value)
        {
            obj.SetValue(PlaceholderTextProperty, value);
        }

        public static readonly DependencyProperty PlaceholderTextProperty =
            DependencyProperty.RegisterAttached(
                "PlaceholderText",
                typeof(string),
                typeof(ThemeProperties),
                new FrameworkPropertyMetadata("Placeholder"));
    }
    #endregion

    /// <summary>
    /// Interaction logic for WinLoginView.xaml
    /// </summary>
    public partial class WinLoginView : Window, ILoginView
    {
        //UI related
        public WinLoginView()
        {
            InitializeComponent();
            ThemeProperties.SetPlaceholderText(EmailTextBox, "E-mail");
            ThemeProperties.SetPlaceholderText(PasswordTextBox, "Password");

            Controller = new LoginViewController(this);
            Controller.ViewDidLoad();
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

        //IView Interface Implementation
        public IViewController Controller { get; set; }

        //ILoginView interface implementation
        public void LoginAccepted()
        {
            WinStatView view = new WinStatView();
            view.Show();
            this.Close();
        }

        public void SetEmailText(string text)
        {
            EmailTextBox.Text = text;
        }

        public void SetPasswordText(string text)
        {
            PasswordTextBox.Text = text;
        }

        public void SetLoginButtonEnabled(bool enabled)
        {
            LoginButton.IsEnabled = enabled;
        }

        public void DisplayAlert(string title, string content)
        {
            MessageBox.Show(content, title);
        }

        //Events
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var controller = Controller as ILoginViewController;
            controller?.ButtonPressed(LoginViewButton.LoginButton);
        }

        private void CreateUser_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var controller = Controller as ILoginViewController;
            controller?.ButtonPressed(LoginViewButton.SignUpButton);
        }

        private void ForgotUser_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var controller = Controller as ILoginViewController;
            controller?.ButtonPressed(LoginViewButton.ForgotButton);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textField = sender as TextBox;
            var controller = Controller as ILoginViewController;
            if (textField != null && textField.Name == PasswordTextBox.Name)
            {
                controller?.DidChangePasswordText(textField.Text);
            }
            else if (textField != null && textField.Name == EmailTextBox.Name)
            {
                controller?.DidChangeEmailText(textField.Text);
            }
        }
    }

}
