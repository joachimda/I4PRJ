﻿//========================================================================
// FILENAME :   HistoryViewBridge.cs
// DESCR.   :   Bridge between history view controller and iOS history view
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
	public partial class HistoryViewBridge : UITableViewController, IHistoryView
	{
		private IHistoryViewController _specializedController => Controller as IHistoryViewController;
		private List<Tuple<SensorTypes, List<double>>> _historicData;


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

			TableView.TableFooterView = new UIView ();

			// Let the controller know that the view has finished loading.
			Controller.ViewDidLoad();
		}

		// IStatView Interface Implementation

		public IViewController Controller { get; set; }

		public void DisplayHistoricData(List<Tuple<SensorTypes, List<double>>> historicData)
		{
			_historicData = historicData;
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
			return _historicData.Count;
		}


		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var reuseIdentifier = "historyCell";
			var cell = tableView.DequeueReusableCell (reuseIdentifier);

			cell.TextLabel.Text = string.Format ($"{_historicData [indexPath.Row].Item1}");

			string valueString = "";
			foreach (var value in _historicData [indexPath.Row].Item2)
				valueString += string.Format($"{value}, ");
			if (valueString.Length > 2)
				valueString = valueString.Substring (0, valueString.Length - 2);
			
			cell.DetailTextLabel.Text = valueString;

			return cell;
		}
	}
}


