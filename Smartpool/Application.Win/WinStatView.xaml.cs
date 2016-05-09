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

            //Sets up the tabBars event handlers
            //SpTabControl1.OnShowStatButtonClicked += TabBarController.ShowStatButtonPressed;
            SpTabControl1.OnShowHistoryButtonClicked += TabBarController.ShowHistoryButtonPressed;
            SpTabControl1.OnShowAddPoolButtonClicked += TabBarController.ShowAddPoolButtonPressed;
            SpTabControl1.OnShowEditPoolButtonClicked += TabBarController.ShowEditPoolButtonPressed;
            SpTabControl1.OnShowEditUserButtonClicked += TabBarController.ShowEditUserButtonPressed;
        }


    }
}
