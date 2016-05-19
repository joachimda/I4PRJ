using System;

using Foundation;
using UIKit;

namespace Application.iOS
{
	public partial class HistoryViewCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("HistoryViewCell");
		public static readonly UINib Nib;

		static HistoryViewCell ()
		{
			Nib = UINib.FromName ("HistoryViewCell", NSBundle.MainBundle);
		}

		public HistoryViewCell (IntPtr handle) : base (handle)
		{
		}
	}
}
