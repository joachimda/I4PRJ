using System.Windows;

namespace SWDGUI
{
    /// <summary>
    /// Interaction logic for WinStatView.xaml
    /// </summary>
    public partial class WinStatView : Window
    {
        public WinStatView()
        {
            InitializeComponent();

            SpTabControl1.OnShowStatButtonClicked += SpTabControl1_OnClickMeClicked;
        }
        
        private void SpTabControl1_OnClickMeClicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Show StatView");
        }
    }
}
