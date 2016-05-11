//========================================================================
// DESCR.   :   Codebehind that calls the presenter.
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  EN      Initial version with event for Stats
// 1.01 EN      Added event for History
// 1.02 EN      Added event for AddPool and EditPool
// 1.03 EN      Added more statviewers
//========================================================================

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Smartpool.Application.Presentation;
using Smartpool.Connection.Client;
using Smartpool.Connection.Model;

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Win
{
    /// <summary>
    /// Interaction logic for WinStatView.xaml
    /// </summary>
    public partial class WinStatView : Window, IStatView
    {
        public WinStatView()
        {
            InitializeComponent();
            PoolComboBox.ItemsSource = AvailablePoolsList;

            TemperatureStatViewer.BorderColor = new SolidColorBrush(Color.FromRgb(0xFF, 0x58, 0x4D));
            PhStatViewer.BorderColor = new SolidColorBrush(Color.FromRgb(0xFD, 0xA0, 0x29));
            ChlorineStatViewer.BorderColor = new SolidColorBrush(Color.FromRgb(0x49, 0xBA, 0xE1));
            HumidityStatViewer.BorderColor = new SolidColorBrush(Color.FromRgb(0x03, 0x54, 0xA5));

            //Sets up the tabBars event handlers
            SpTabControl1.OnShowStatButtonClicked += TabBarController.ShowStatButtonPressed;
            //SpTabControl1.OnShowHistoryButtonClicked += TabBarController.ShowHistoryButtonPressed;

            SpTabControl1.OnShowHistoryButtonClicked += Set_PoolComboBox_Selection;

            SpTabControl1.OnShowAddPoolButtonClicked += TabBarController.ShowAddPoolButtonPressed;
            SpTabControl1.OnShowEditPoolButtonClicked += TabBarController.ShowEditPoolButtonPressed;
            SpTabControl1.OnShowEditUserButtonClicked += TabBarController.ShowEditUserButtonPressed;

            string Ip = System.IO.File.ReadAllText("IpTextFile.txt");
            //Controller
            var clientMessager = new ClientMessenger(new SynchronousSocketClient(Ip));
            Controller = new StatViewController(this, clientMessager);
            Controller.ViewDidLoad();
        }

        //IView Interface Implementation
        public IViewController Controller { get; set; }

        public void DisplaySensorData(List<Tuple<SensorTypes, double>> sensorData)
        {
            foreach (var sensor in sensorData)
            {
                switch (sensor.Item1)
                {
                    case SensorTypes.Temperature:
                        TemperatureStatViewer.Parameter = string.Format($"{sensor.Item2}");
                        break;
                    case SensorTypes.Ph:
                        PhStatViewer.Parameter = string.Format($"{sensor.Item2}");
                        break;
                    case SensorTypes.Chlorine:
                        ChlorineStatViewer.Parameter = string.Format($"{sensor.Item2}");
                        break;
                    case SensorTypes.Humidity:
                        HumidityStatViewer.Parameter = string.Format($"{sensor.Item2}");
                        break;
                } 
            }
        }

        public List<string> AvailablePoolsList { get; set; } = new List<string>();
        public void SetAvailablePools(List<Tuple<string, bool>> pools)
        {
            AvailablePoolsList.Clear();
            foreach (var pool in pools)
            {
                AvailablePoolsList.Add(pool.Item1);
            }
        }

        public void DisplayAlert(string title, string content)
        {
            MessageBox.Show(content, title);
        }

        //private bool _selectionSetByControlller = false;

        public void PoolComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (!_selectionSetByControlller)  
            var selected = PoolComboBox.SelectedIndex;
            if (selected != -1)
            {
                MessageBox.Show(selected.ToString());
            }
            //else _selectionSetByControlller = false;
        }

        public void Set_PoolComboBox_Selection(object sender, EventArgs e)
        {
            PoolComboBox.SelectedIndex = 1;
            //_selectionSetByControlller = true;
            MessageBox.Show("Set PoolComboBox");
        }
    }
}
