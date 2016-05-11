using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Smartpool.Application.Presentation;
using Smartpool.Application.Win;
using Smartpool.Connection.Client;
using Smartpool.Connection.Model;

namespace Smartpool.Application.Win
{
    /// <summary>
    /// Interaction logic for CreateUserView.xaml
    /// </summary>
    public partial class WinCreateUserView : Window, ISignUpView
    {
        public WinCreateUserView()
        {
            InitializeComponent();
            ThemeProperties.SetPlaceholderText(NameTextBox, "Name");
            ThemeProperties.SetPlaceholderText(EmailTextBox, "E-mail");
            ThemeProperties.SetPlaceholderText(PasswordTextBox, "Password");
            ThemeProperties.SetPlaceholderText(RepeatPasswordTextBox, "Repeat password");

            string Ip = System.IO.File.ReadAllText("IpTextFile.txt");
            var clientMessager = new ClientMessenger(new SynchronousSocketClient(Ip));
            Controller = new SignUpViewController(this, clientMessager);
            Controller.ViewDidLoad();
        }

        //IView Interface Implementation
        public IViewController Controller { get; set; }

        //ISignUpView interface implementation
        public void SetNameText(string text)
        {
            NameTextBox.Text = text;
        }

        public void SetEmailText(string text)
        {
            EmailTextBox.Text = text;
        }

        public void SetPasswordText(string text)
        {
            PasswordTextBox.Text = text;
            RepeatPasswordTextBox.Text = text;
        }

        public void SetPasswordValid(bool valid)
        {
            ValidEllipse.Fill = valid ? new SolidColorBrush(Color.FromRgb(0, 255, 0)) : new SolidColorBrush(Color.FromRgb(255, 88, 77));
        }

        public void SetButtonEnabled(bool enabled)
        {
            SignUpButton.IsEnabled = enabled;
        }

        public void DisplayAlert(string title, string content)
        {
            MessageBox.Show(content, title);
        }

        public void SignUpAccepted()
        {
            MessageBox.Show("User created succesfully", "Smartpool");
            this.Close();
        }

        //Events
        private void SignUpButton_OnClick(object sender, RoutedEventArgs e)
        {
            var controller = Controller as ISignUpViewController;
            controller?.ButtonPressed();
        }

        private void NameTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var controller = Controller as ISignUpViewController;
            controller?.DidChangeNameText(NameTextBox.Text);
        }

        private void EmailTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var controller = Controller as ISignUpViewController;
            controller?.DidChangeEmailText(EmailTextBox.Text);
        }

        private void PasswordTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var textField = sender as TextBox;
            var controller = Controller as ISignUpViewController;
            if (textField?.Name == PasswordTextBox.Name)
            {
                controller?.DidChangePasswordText(textField?.Text, 0);
            }
            else controller?.DidChangePasswordText(textField?.Text, 1);
        }
    }
}
