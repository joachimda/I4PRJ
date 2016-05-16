//========================================================================
// DESCR.   :   Codebehind that calls the presenter.
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 0.1  EN      Initial version with partial GUI
// 0.2  EN      Draws points on temp graph
//========================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Smartpool.Application.Presentation;
using Smartpool.Connection.Client;
using Smartpool.Connection.Model;

//ReSharper disable once CheckNamespace
namespace Smartpool.Application.Win
{
    /// <summary>
    /// Interaction logic for WinHistoryView.xaml
    /// </summary>
    public partial class WinHistoryView : Window, IHistoryView
    {
        public WinHistoryView()
        {
            InitializeComponent();

            //Sets up the tabBars event handlers
            SpTabControl1.OnShowStatButtonClicked += TabBarController.ShowStatButtonPressed;
            SpTabControl1.OnShowHistoryButtonClicked += TabBarController.ShowHistoryButtonPressed;
            SpTabControl1.OnShowAddPoolButtonClicked += TabBarController.ShowAddPoolButtonPressed;
            SpTabControl1.OnShowEditPoolButtonClicked += TabBarController.ShowEditPoolButtonPressed;
            SpTabControl1.OnShowEditUserButtonClicked += TabBarController.ShowEditUserButtonPressed;

            string Ip = System.IO.File.ReadAllText("IpTextFile.txt");
            var clientMessager = new ClientMessenger(new SynchronousSocketClient(Ip));
            Controller = new HistoryViewController(this, clientMessager);
            Controller.ViewDidLoad();
        }

        //IView Interface Implementation
        public IViewController Controller { get; set; }

        private IHistoryViewController _specializedController => Controller as IHistoryViewController;

        //IHistoryView implementation
        public void DisplayAlert(string title, string content)
        {
            MessageBox.Show(content, title);
        }

        public void SetSelectedPoolIndex(int index)
        {
            PoolComboBox.SelectedIndex = index;
        }

        private const int PointsOnGraphs = 13;
        List<double> _temperatureValues;

        public void DisplayHistoricData(List<Tuple<SensorTypes, List<double>>> historicData)
        {
            foreach (var sensor in historicData)
            {
                switch (sensor.Item1)
                {
                    case SensorTypes.Temperature:
                        if (sensor.Item2.Count < PointsOnGraphs)
                        {
                            _temperatureValues = sensor.Item2.GetRange(0, sensor.Item2.Count);
                        }
                        else
                        {
                            _temperatureValues = sensor.Item2.GetRange(0, PointsOnGraphs);
                            DisplayGraph(TemperatureCanvas, _temperatureValues);
                        }
                        break;
                    
                }
            }
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

        private void DisplayGraph(Canvas historyCanvas, List<double> history)
        {
            if (!history.Any()) return;

            Dispatcher.Invoke((Action)(() =>
            {
                // Remove children from canvas
                historyCanvas.Children.Clear();
            }));
            
            var canvasHeight = historyCanvas.ActualHeight;
            var canvasWidth = historyCanvas.ActualWidth;

            var i = 0;

            // Draw tracks as ellipses
            foreach (var value in history)
            {
                Dispatcher.Invoke((Action)(() =>
                {
                    // Draw ellipse
                    var point = new Ellipse();
                    point.Height = 4;
                    point.Width = 4;
                    point.Fill = new SolidColorBrush(Color.FromRgb(0xFF, 0xFF, 0xFF));

                    historyCanvas.Children.Add(point);
                    var pointHeight = (1.0 - (100 - value) / 100) * canvasHeight;
                    Canvas.SetBottom(point, pointHeight);
                    Canvas.SetLeft(point, (canvasWidth/10) * i - 2);
                    i++;
                }));
            }

            var topText = new TextBlock();
            topText.Text = "100";
            topText.FontSize = 8;
            topText.Foreground = new SolidColorBrush(Color.FromRgb(0xFF, 0xFF, 0xFF));
            historyCanvas.Children.Add(topText);
            Canvas.SetBottom(topText, canvasHeight - 6);
            Canvas.SetLeft(topText, - 4);
            var bottomText = new TextBlock();
            bottomText.Text = "0";
            bottomText.FontSize = 8;
            bottomText.Foreground = new SolidColorBrush(Color.FromRgb(0xFF, 0xFF, 0xFF));
            historyCanvas.Children.Add(bottomText);
            Canvas.SetBottom(bottomText, -4);
            Canvas.SetLeft(bottomText, -4);
        }

        private void WinHistoryView_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            DisplayGraph(TemperatureCanvas, _temperatureValues);
        }
    
    }
}
