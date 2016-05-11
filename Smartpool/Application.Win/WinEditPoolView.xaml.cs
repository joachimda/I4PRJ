//========================================================================
// DESCR.   :   Codebehind that calls the presenter.
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  EN      Initial version with GUI
//========================================================================
using System.Windows;
using System.Windows.Controls;
using Smartpool.Application.Presentation;
using Smartpool.Connection.Client;
using Smartpool.Connection.Model;

//ReSharper disable once CheckNamespace
namespace Smartpool.Application.Win
{
    /// <summary>
    /// Interaction logic for WinEditPoolView.xaml
    /// </summary>
    public partial class WinEditPoolView : Window
    {
        public WinEditPoolView()
        {
            InitializeComponent();

            //UI related. Sets placeholder text
            ThemeProperties.SetPlaceholderText(NameTextBox, "Pool name");
            ThemeProperties.SetPlaceholderText(VolumeTextBox, "Volume in m^3");
            ThemeProperties.SetPlaceholderText(LengthTextBox, "Width");
            ThemeProperties.SetPlaceholderText(WidthTextBox, "Length");
            ThemeProperties.SetPlaceholderText(DepthTextBox, "Depth");
            ThemeProperties.SetPlaceholderText(SerialTextBox, "Depth");

            //Sets up the tabBars event handlers
            SpTabControl1.OnShowStatButtonClicked += TabBarController.ShowStatButtonPressed;
            SpTabControl1.OnShowHistoryButtonClicked += TabBarController.ShowHistoryButtonPressed;
            SpTabControl1.OnShowAddPoolButtonClicked += TabBarController.ShowAddPoolButtonPressed;
            //SpTabControl1.OnShowEditPoolButtonClicked += TabBarController.ShowEditPoolButtonPressed;
            SpTabControl1.OnShowEditUserButtonClicked += TabBarController.ShowEditUserButtonPressed;

            string Ip = System.IO.File.ReadAllText("IpTextFile.txt");
            //Controller
            /*var clientMessager = new ClientMessenger(new SynchronousSocketClient(Ip));
            Controller = new EditPoolViewController(this, clientMessager);
            Controller.ViewDidLoad();*/
        }

        //IView Interface Implementation
        public IViewController Controller { get; set; }

        //UI Related. Allows user to enter pool properties
        private void PropertiesRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            VolumeTextBox.IsEnabled = false;
            LengthTextBox.IsEnabled = true;
            WidthTextBox.IsEnabled = true;
            DepthTextBox.IsEnabled = true;
        }

        //UI Related. Allows user to enter pool volume
        private bool _isStartup = true;
        private void VolumeRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //Window crashes if the event is called during initialization
            if (_isStartup)
            {
                _isStartup = false;
                return;
            }
            VolumeTextBox.IsEnabled = true;
            LengthTextBox.IsEnabled = false;
            WidthTextBox.IsEnabled = false;
            DepthTextBox.IsEnabled = false;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void EditButton_OnClickButton_Click(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void DeleteButton_OnClickButton_OnClickButton_Click(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
