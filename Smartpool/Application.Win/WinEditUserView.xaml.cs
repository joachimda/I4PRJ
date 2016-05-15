//========================================================================
// DESCR.   :   Codebehind that calls the presenter.
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  EN      Initial version with GUI
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
    public partial class WinEditUserView : Window
    {
        public WinEditUserView()
        {
            InitializeComponent();
            //UI related. Sets placeholder text
            ThemeProperties.SetPlaceholderText(NameTextBox, "Name");
            ThemeProperties.SetPlaceholderText(EmailTextBox, "E-mail");
            ThemeProperties.SetPlaceholderText(PasswordTextBox, "Password");
            ThemeProperties.SetPlaceholderText(RepeatPasswordTextBox, "Repeat password");

            //Sets up the tabBars event handlers
            SpTabControl1.OnShowStatButtonClicked += TabBarController.ShowStatButtonPressed;
            SpTabControl1.OnShowHistoryButtonClicked += TabBarController.ShowHistoryButtonPressed;
            SpTabControl1.OnShowAddPoolButtonClicked += TabBarController.ShowAddPoolButtonPressed;
            SpTabControl1.OnShowEditPoolButtonClicked += TabBarController.ShowEditPoolButtonPressed;
            //SpTabControl1.OnShowEditUserButtonClicked += TabBarController.ShowEditUserButtonPressed;

            string Ip = System.IO.File.ReadAllText("IpTextFile.txt");
            //var clientMessager = new ClientMessenger(new SynchronousSocketClient(Ip));
            //Controller = new EditUserViewController(this, clientMessager);
            //Controller.ViewDidLoad();
        }

        //IView Interface Implementation
        public IViewController Controller { get; set; }

        private IEditPoolViewController _specializedController => Controller as IEditPoolViewController;

        //Functions that call controller
        public void EditButton_OnClickButton_Click(object sender, EventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void EmailTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PasswordTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
