//========================================================================
// DESCR.   :   Codebehind that calls the presenter.
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  EN      Initial version with GUI
//========================================================================
using System.Windows;

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Win
{
    /// <summary>
    /// Interaction logic for WinAddPoolView.xaml
    /// </summary>
    public partial class WinAddPoolView : Window
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
            ThemeProperties.SetPlaceholderText(MUSeialTextBox, "Moniter unit serial number");
        }

        private void PropertiesRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            VolumeTextBox.IsEnabled = false;
            LengthTextBox.IsEnabled = true;
            WidthTextBox.IsEnabled = true;
            DepthTextBox.IsEnabled = true;
        }

        private bool _isStartup = true; //Window crashes if the event is called during initialization
        private void VolumeRadioButton_Checked(object sender, RoutedEventArgs e)
        {
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

    }
}
