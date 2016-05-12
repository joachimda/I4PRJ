//========================================================================
// DESCR.   :   Codebehind that calls the presenter.
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 0.1  EN      Initial version with partial GUI
//========================================================================

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Smartpool.Application.Presentation;

//ReSharper disable once CheckNamespace
namespace Smartpool.Application.Win
{
    /// <summary>
    /// Interaction logic for WinHistoryView.xaml
    /// </summary>
    public partial class WinHistoryView : Window
    {
        public WinHistoryView()
        {
            InitializeComponent();
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

        //IHistoryView implementation
        public void DisplayAlert(string title, string content)
        {
            MessageBox.Show(content, title);
        }

        public void SetSelectedPoolIndex(int index)
        {
            PoolComboBox.SelectedIndex = index;
        }

        public List<string> AvailablePoolsList { get; set; } = new List<string>();
        public void SetAvailablePools(List<Tuple<string, bool>> pools)
        {
            PoolComboBox.ItemsSource = null;
            AvailablePoolsList.Clear();

            foreach (var pool in pools)
            {
                AvailablePoolsList.Add(pool.Item1);
            }
            PoolComboBox.ItemsSource = AvailablePoolsList;
        }

        //Events that call controller
        public void PoolComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = PoolComboBox.SelectedIndex;

            if (selected != -1)
            {
                _specializedController?.DidSelectPool(selected);
            }
        }
    }
}
