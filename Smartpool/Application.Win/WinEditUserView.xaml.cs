//========================================================================
// DESCR.   :   Codebehind that calls the presenter.
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  EN      Initial version with GUI
// 1.1  EN      Redid part of GUI and implemented presenter
//========================================================================

using System;
using System.Windows;
using System.Windows.Controls;
using Smartpool.Application.Presentation;
using Smartpool.Connection.Client;
using Smartpool.Connection.Model;

//ReSharper disable once CheckNamespace
namespace Smartpool.Application.Win
{
    /// <summary>
    /// Interaction logic for WinEditUserView.xaml
    /// </summary>
    public partial class WinEditUserView : Window, IEditUserView
    {
        public WinEditUserView()
        {
            InitializeComponent();
            //UI related. Sets placeholder text
            ThemeProperties.SetPlaceholderText(CurrentPasswordTextBox, "Current password");
            ThemeProperties.SetPlaceholderText(PasswordTextBox, "New password");
            ThemeProperties.SetPlaceholderText(RepeatPasswordTextBox, "Repeat new password");

            //Sets up the tabBars event handlers
            SpTabControl1.OnShowStatButtonClicked += TabBarController.ShowStatButtonPressed;
            SpTabControl1.OnShowHistoryButtonClicked += TabBarController.ShowHistoryButtonPressed;
            SpTabControl1.OnShowAddPoolButtonClicked += TabBarController.ShowAddPoolButtonPressed;
            SpTabControl1.OnShowEditPoolButtonClicked += TabBarController.ShowEditPoolButtonPressed;
            //SpTabControl1.OnShowEditUserButtonClicked += TabBarController.ShowEditUserButtonPressed;

            string Ip = System.IO.File.ReadAllText("IpTextFile.txt");
            var clientMessager = new ClientMessenger(new SynchronousSocketClient(Ip));
            Controller = new EditUserViewController(this, clientMessager);
            Controller.ViewDidLoad();
        }

        //IView Interface Implementation
        public IViewController Controller { get; set; }

        private IEditUserViewController _specializedController => Controller as IEditUserViewController;

        //IEditUserView implementation
        public void DisplayAlert(string title, string content)
        {
            MessageBox.Show(content, title);
        }

        public void ClearAllText()
        {
            CurrentPasswordTextBox.Text = "";
            PasswordTextBox.Text = "";
            RepeatPasswordTextBox.Text = "";
        }

        public void SetSaveButtonEnabled(bool enabled)
        {
            EditButton.IsEnabled = enabled;
        }

        public void SetNewPasswordValid(bool valid)
        {
            //EditButton.IsEnabled = valid;

            ValidEllipse.Visibility = valid ? Visibility.Collapsed : Visibility.Visible;
        }

        public void UpdateSuccessful()
        {
            MessageBox.Show("Password successfully changed", "Smartpool");
        }

        //Functions that call controller
        public void EditButton_OnClickButton_Click(object sender, EventArgs e)
        {
            _specializedController.SaveButtonPressed();
        }

        private void PasswordTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var textField = sender as TextBox;
            _specializedController.DidChangeOldPasswordText(textField?.Text);
        }

        private void CurrentPasswordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textField = sender as TextBox;
            _specializedController.DidChangeNewPasswordText(textField?.Text,
                textField?.Name == "PasswordTextBox" ? 0 : 1);
        }
    }
}
