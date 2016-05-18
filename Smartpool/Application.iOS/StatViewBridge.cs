﻿//========================================================================
// FILENAME :   StatViewBridge.cs
// DESCR.   :   Bridge between stat view controller and iOS stat view
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version, missing pool switching
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

			TableView.TableFooterView = new UIView ();

			// Let the controller know that the view has finished loading.
			Controller.ViewDidLoad();
		}

		// IStatView Interface Implementation

		public IViewController Controller { get; set; }

		public void DisplaySensorData(List<Tuple<SensorTypes, double>> sensorData)
		{
			_sensorData = sensorData;
			TableView.ReloadData ();
		}

		public void SetAvailablePools(List<Tuple<string, bool>> pools)
		{
			// Missing implementation
		}
			
		public void SetSelectedPoolIndex(int index)
		{
			// Missing implementation
		}

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
			var reuseIdentifier = "recentsCell";
			var cell = tableView.DequeueReusableCell (reuseIdentifier);

			cell.TextLabel.Text = string.Format ($"{_sensorData [indexPath.Row].Item1}");
			cell.DetailTextLabel.Text = string.Format ($"{_sensorData [indexPath.Row].Item2}");

			return cell;
		}
	}
}


