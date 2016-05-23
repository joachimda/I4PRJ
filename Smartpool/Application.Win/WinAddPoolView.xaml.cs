//========================================================================
// DESCR.   :   Codebehind that calls the presenter.
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  EN      Initial version with GUI
// 1.1  EN      Implemented IAddPoolViewInterface
//========================================================================
using System.Windows;
using System.Windows.Controls;
using Smartpool.Application.Presentation;
using Smartpool.Connection.Client;
using Smartpool.Connection.Model;

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Win
{
    /// <summary>
    /// Interaction logic for WinAddPoolView.xaml
    /// </summary>
    public partial class WinAddPoolView : Window, IAddPoolView
    {
        public WinAddPoolView()
        {
            InitializeComponent();
            //UI related. Sets placeholder text
            ThemeProperties.SetPlaceholderText(NameTextBox, "Pool name");
            ThemeProperties.SetPlaceholderText(VolumeTextBox, "Volume in m^3");
            ThemeProperties.SetPlaceholderText(LengthTextBox, "Width");
            ThemeProperties.SetPlaceholderText(WidthTextBox, "Length");
            ThemeProperties.SetPlaceholderText(DepthTextBox, "Depth");
            ThemeProperties.SetPlaceholderText(SeialTextBox, "Moniter unit serial number");

            //Sets up the tabBars event handlers
            SpTabControl1.OnShowStatButtonClicked += TabBarController.ShowStatButtonPressed;
            SpTabControl1.OnShowHistoryButtonClicked += TabBarController.ShowHistoryButtonPressed;
            //SpTabControl1.OnShowAddPoolButtonClicked += TabBarController.ShowAddPoolButtonPressed;
            SpTabControl1.OnShowEditPoolButtonClicked += TabBarController.ShowEditPoolButtonPressed;
            SpTabControl1.OnShowEditUserButtonClicked += TabBarController.ShowEditUserButtonPressed;

            string Ip = System.IO.File.ReadAllText("IpTextFile.txt");
            //Controllers
            var clientMessager = new ClientMessenger(new SynchronousSocketClient(Ip));
            Controller = new AddPoolViewController(this, clientMessager);
            Controller.ViewDidLoad();

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

        //IAddPoolView interface implementation
        public void SetSerialNumberText(string text)
        {
            SeialTextBox.Text = text;
        }
        
        public void SetAddPoolButtonEnabled(bool enabled)
        {
            AddButton.IsEnabled = enabled;
        }
        
        public void DisplayAlert(string title, string content)
        {
            MessageBox.Show(content, title);
        }
        
        public void PoolAdded()
        {
            MessageBox.Show("Pool was added to your user.", "Smartpool - Succes");
        }

        public void ClearVolumeText()
        {
            VolumeTextBox.Text = "";
        }
        
        public void ClearDimensionText()
        {
            LengthTextBox.Text = "";
            WidthTextBox.Text = "";
            DepthTextBox.Text = "";
        }

        //Events that call the controller
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var controller = Controller as IAddPoolViewController;
            controller?.AddPoolButtonPressed();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textField = sender as TextBox;
            var controller = Controller as IAddPoolViewController;
            if (textField != null && textField.Name == NameTextBox.Name)
            {
                controller?.DidChangeText(AddPoolTextField.PoolName, textField.Text);
            }
            else if (textField != null && textField.Name == VolumeTextBox.Name)
            {
                controller?.DidChangeText(AddPoolTextField.Volume, textField.Text);
            }
            else if (textField != null && textField.Name == LengthTextBox.Name)
            {
                controller?.DidChangeText(AddPoolTextField.Length, textField.Text);
            }
            else if (textField != null && textField.Name == WidthTextBox.Name)
            {
                controller?.DidChangeText(AddPoolTextField.Width, textField.Text);
            }
            else if (textField != null && textField.Name == DepthTextBox.Name)
            {
                controller?.DidChangeText(AddPoolTextField.Depth, textField.Text);
            }
            else if (textField != null && textField.Name == SeialTextBox.Name)
            {
                controller?.DidChangeText(AddPoolTextField.SerialNumber, textField.Text);
            }
        }
    }
}
