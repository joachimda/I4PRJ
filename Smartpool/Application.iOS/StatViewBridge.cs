//========================================================================
// FILENAME :   StatViewBridge.cs
// DESCR.   :   Bridge between stat view controller and iOS stat view
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
	public partial class StatViewBridge : UITableViewController, IStatView
	{
		private IStatViewController _specializedController => Controller as IStatViewController;
		private List<Tuple<SensorTypes, double>> _sensorData;
		private string _reuseIdentifier = "statViewCell";

		public StatViewBridge (IntPtr handle) : base (handle)
		{
			// Initialize view controller.
			_sensorData = new List<Tuple<SensorTypes, double>>();
			Controller = new StatViewController (this, iOSClientFactory.DefaultClient ());
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.


			TableView.RegisterNibForCellReuse(StatViewCell.Nib, _reuseIdentifier);
			TableView.TableFooterView = new UIView ();

			// Let the controller know that the view has finished loading.
			Controller.ViewDidLoad();
		}

		// IStatView Interface Implementation

		public IViewController Controller { get; set; }

		public void DisplaySensorData(List<Tuple<SensorTypes, double>> sensorData)
		{
			_sensorData = sensorData;
			_sensorData.Sort ();
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

		// IAlartDisplaying

		public void DisplayAlert(string title, string content)
		{
			// Missing implementation
		}

		// UITableViewController Implementation

		public override nint RowsInSection (UITableView tableView, nint section)
		{
			return _sensorData.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{	
			var cell = tableView.DequeueReusableCell (_reuseIdentifier) as StatViewCell;
			var type = string.Format ($"{_sensorData [indexPath.Row].Item1}");
			cell.DataLabel.Text = string.Format ($"{_sensorData [indexPath.Row].Item2}") + GuiCharacter.SignForType(_sensorData [indexPath.Row].Item1);
			cell.NameLabel.Text = type;
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


