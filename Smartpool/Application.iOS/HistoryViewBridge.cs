//========================================================================
// FILENAME :   HistoryViewBridge.cs
// DESCR.   :   Bridge between history view controller and iOS history view
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version, missing pool switching
// 1.1	LP		Added pool cycling
//========================================================================


using Smartpool.Application.Presentation;
using Smartpool.Connection.Model;
using System.Collections.Generic;
using System;
using UIKit;

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
			return cell;

		}

		public override nfloat GetHeightForRow (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			return 140;
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


