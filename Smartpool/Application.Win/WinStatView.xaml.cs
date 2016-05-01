//========================================================================
// DESCR.   :   Codebehind that calls the presenter.
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  EN      Initial version with event for Stats
// 1.01 EN      Added event for History
// 1.02 EN      Added event for AddPool and EditPool
// 1.03 EN      Added more statviewers
//========================================================================

using System.Windows;
using System.Windows.Media;

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Win
{
    /// <summary>
    /// Interaction logic for WinStatView.xaml
    /// </summary>
    public partial class WinStatView : Window
    {
        public WinStatView()
        {
            InitializeComponent();

            PhStatViewer.BorderColor = new SolidColorBrush(Color.FromRgb(0xFD, 0xA0, 0x29));
            ChlorineStatViewer.BorderColor = new SolidColorBrush(Color.FromRgb(0x49, 0xBA, 0xE1));
            HumidityStatViewer.BorderColor = new SolidColorBrush(Color.FromRgb(0x03, 0x54, 0xA5));

            SpTabControl1.OnShowStatButtonClicked += SpTabControl1_ShowStatView;
            SpTabControl1.OnShowHistoryButtonClicked += SpTabControl1_ShowHistoryView;
            SpTabControl1.OnShowAddPoolButtonClicked += SpTabControl1_ShowAddPoolView;
            SpTabControl1.OnShowEditPoolButtonClicked += SpTabControl1_ShowEditPoolView;
        }

        private void SpTabControl1_ShowStatView(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Show Stats");
        }

        private void SpTabControl1_ShowHistoryView(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Show History");
        }

        private void SpTabControl1_ShowAddPoolView(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Show AddPool");
            Window view = new WinAddPoolView();
            view.Show();
            this.Close();
        }

        private void SpTabControl1_ShowEditPoolView(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Show EditPool");
        }
    }
}
