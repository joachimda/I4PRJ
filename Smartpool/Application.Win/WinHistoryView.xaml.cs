//========================================================================
// DESCR.   :   Codebehind that calls the presenter.
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 0.1  EN      Initial version with partial GUI
// 0.2  EN      Draws points on temp graph
// 0.3  EN      Draws tendency lines and value text
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

            //Sets up graphs upper and lower bounds
            var upperBound = 0d;
            var lowerBound = 200d;
            foreach (var value in history)
            {
                if (value > upperBound) upperBound = value + 5;
                if (value < lowerBound) lowerBound = value - 5;
            }
            //Make bounds even, because I asume constumers like even numbers
            if (!(upperBound % 2 == 0)) upperBound++;
            if (!(lowerBound % 2 == 0)) lowerBound++;

            var canvasHeight = historyCanvas.ActualHeight;
            var canvasWidth = historyCanvas.ActualWidth;

            var i = 0;
            var lastPointX = 0d;
            var lastPointY = 0d;
            var lastPointBottom = 0d;
            var lastPointLeft = 0d;
            // Draw ellipses
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
                    var pointHeight = (1.0 - ((upperBound - value)) / (upperBound - lowerBound)) * canvasHeight;
                    Canvas.SetBottom(point, pointHeight);
                    var pointWidth = (canvasWidth/(PointsOnGraphs - 1))*i;
                    Canvas.SetLeft(point, pointWidth);

                    var valueText = new TextBlock();
                    valueText.Text = value.ToString();
                    valueText.FontSize = 7;
                    valueText.Foreground = new SolidColorBrush(Color.FromRgb(0xFF, 0xFF, 0xFF));
                    historyCanvas.Children.Add(valueText);
                    Canvas.SetBottom(valueText, pointHeight + 5);
                    Canvas.SetLeft(valueText, pointWidth);
                    //Draw tendency line
                    if (!(i == 0))
                    {
                        var line = new Line();
                        line.StrokeThickness = 1;
                        line.Stroke = new SolidColorBrush(Color.FromRgb(0xFF, 0xFF, 0xFF));
                        line.X1 = lastPointX + 1;
                        line.Y1 = lastPointY + 1;
                        line.X2 = pointWidth + 1;
                        line.Y2 = ((upperBound - value)) / (upperBound - lowerBound) * canvasHeight + 1;

                        historyCanvas.Children.Add(line);
                        Canvas.SetBottom(line, lastPointBottom);
                        //Canvas.SetLeft(line, lastPointLeft);
                    }
                    //Remember info on point for drawing the tendency line
                    lastPointY = ((upperBound - value)) / (upperBound - lowerBound) * canvasHeight;
                    lastPointX = pointWidth;
                    lastPointBottom = Canvas.GetBottom(point);
                    lastPointLeft = Canvas.GetLeft(point);

                    i++;
                }));
            }
            //Write bounds on graph
            Dispatcher.Invoke((Action) (() =>
            {
                var topText = new TextBlock();
                topText.Text = upperBound.ToString();
                topText.FontSize = 8;
                topText.Foreground = new SolidColorBrush(Color.FromRgb(0xFF, 0xFF, 0xFF));
                historyCanvas.Children.Add(topText);
                Canvas.SetBottom(topText, canvasHeight - 6);
                Canvas.SetLeft(topText, -4);
                var bottomText = new TextBlock();
                bottomText.Text = lowerBound.ToString();
                bottomText.FontSize = 8;
                bottomText.Foreground = new SolidColorBrush(Color.FromRgb(0xFF, 0xFF, 0xFF));
                historyCanvas.Children.Add(bottomText);
                Canvas.SetBottom(bottomText, -4);
                Canvas.SetLeft(bottomText, -3);
            }));
        }

        private void WinHistoryView_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            DisplayGraph(TemperatureCanvas, _temperatureValues);
        }
    
    }
}
