//========================================================================
// FILENAME :   HistoryViewBridge.cs
// DESCR.   :   Bridge between history view controller and iOS history view
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version, missing pool switching
// 1.1	LP		Added pool cycling
// 1.2	LP		Added graph drawing (modified EN's win graph)
//========================================================================


using Smartpool.Application.Presentation;
using Smartpool.Connection.Model;
using System.Collections.Generic;
using System;
using UIKit;
using CoreGraphics;
using CoreAnimation;

namespace Application.iOS
{
	public partial class HistoryViewBridge : UITableViewController, IHistoryView
	{
		private IHistoryViewController _specializedController => Controller as IHistoryViewController;
		private List<Tuple<SensorTypes, List<double>>> _historicData;

		private string _reuseIdentifier = "historyViewCell";

		public HistoryViewBridge (IntPtr handle) : base (handle)
		{
			// Initialize view controller.
			_historicData = new List<Tuple<SensorTypes, List<double>>>();
			Controller = new HistoryViewController(this, iOSClientFactory.DefaultClient());
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			TableView.RegisterNibForCellReuse(HistoryViewCell.Nib, _reuseIdentifier);
			TableView.TableFooterView = new UIView ();
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			// Let the controller know that the view has finished loading.
			Controller.ViewDidLoad();
		}

		// IStatView Interface Implementation

		public IViewController Controller { get; set; }

		public void DisplayHistoricData(List<Tuple<SensorTypes, List<double>>> historicData)
		{
			_historicData = historicData;
			_historicData.Sort ();
			TableView.ReloadData ();
		}

		// IPoolDisplaying

		private List<Tuple<string, bool>> _pools = new List<Tuple<string, bool>> ();

		private int _selectedIndex = 0;

		public void SetAvailablePools(List<Tuple<string, bool>> pools)
		{
			_pools = pools;
		}

		public void SetSelectedPoolIndex(int index)
		{
			_selectedIndex = index;
			PoolsBarButtonItem.Title = _pools [index].Item1;
		}

		// IAlertDisplaying

		public void DisplayAlert(string title, string content)
		{
			// Missing implementation
		}

		// UITableViewController Implementation

		public override nint RowsInSection (UITableView tableView, nint section)
		{
			return _historicData.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (_reuseIdentifier) as HistoryViewCell;
			var type = string.Format ($"{_historicData [indexPath.Row].Item1}");
			cell.TypeLabel.Text = type;
			cell.BorderImage.Image = UIImage.FromFile (type.ToLower () + ".png");
			DrawGraph (cell.GraphView, _historicData [indexPath.Row].Item2, _historicData [indexPath.Row].Item1);
			return cell;

		}

		public override nfloat GetHeightForRow (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			return 140;
		}

		// Graph drawing

		private void DrawGraph(UIView view, List<double> values, SensorTypes type)
		{
			var bounds = GraphBounds (values, (type == SensorTypes.Chlorine || type == SensorTypes.Ph));
			var points = GraphPoints (values, bounds, view);
			var numberOfPoints = points.Count;

			if (numberOfPoints == 0)
				return;

			var path = new UIBezierPath ();
			path.MoveTo (points[0]);

			for (var i = 1; i < numberOfPoints; i++) {
				path.AddLineTo (points[i]);
			}

			var layer = new CAShapeLayer ();
			layer.Path = path.CGPath;
			layer.StrokeColor = UIColor.White.CGColor;
			layer.LineWidth = 2;
			layer.FillColor = UIColor.Clear.CGColor;

			view.Layer.AddSublayer (layer);
		}

		private Tuple<double, double> GraphBounds(List<double> values, bool isPhOrChlorine)
		{
			//Sets up graphs upper and lower bounds
			var upperBound = 0d;
			var lowerBound = 200d;

			foreach (var value in values)
			{
				if (value > upperBound) upperBound = value;
				if (value < lowerBound) lowerBound = value;
			}
			//If isPhOrChlorine bounds are +- 0.5 else +-5
			if (isPhOrChlorine)
			{
				upperBound += 0.5;
				lowerBound -= 0.5;
			}
			else
			{
				upperBound += 5;
				lowerBound -= 5;
				//Make bounds even, because I asume people like even numbers
				if (!(upperBound % 2 == 0)) upperBound++;
				if (!(lowerBound % 2 == 0)) lowerBound++;
			}

			return new Tuple<double, double> (lowerBound, upperBound);
		}

		private List<CGPoint> GraphPoints(List<double> values, Tuple<double, double> bounds, UIView view)
		{
			var points = new List<CGPoint> ();
			var numberOfPoints = values.Count;

			// Bounds
			var lowerBound = bounds.Item1;
			var upperBound = bounds.Item2;

			// Canvas size
			var canvasWidth = view.Frame.Width;
			var canvasHeight = view.Frame.Height;

			// Holds last point drawn. Is used to draw tendency line
			var lastPointX = 0d;
			var lastPointY = 0d;

			// Draw graph
			for (var i = 0; i < numberOfPoints; i++)
			{
				var pointHeight = ((upperBound - values[i])) / (upperBound - lowerBound) * canvasHeight;
				var pointWidth = (canvasWidth/(numberOfPoints - 1))*i;

				var point = new CGPoint ();
				point.X = (nfloat)pointWidth;
				point.Y = (nfloat)pointHeight;

				points.Add (point);

				//Remember info on point for drawing the tendency line
				lastPointY = pointHeight;
				lastPointX = pointWidth;
			}

			return points;
		}

		// Actions

		partial void PoolsBarButtonItemTouchUpInside (UIKit.UIBarButtonItem sender)
		{
			// Cycle through available pools
			var newIndex = (_selectedIndex + 1) % _pools.Count;
			_specializedController.DidSelectPool(newIndex);
			SetSelectedPoolIndex(newIndex);
		}
	}
}


