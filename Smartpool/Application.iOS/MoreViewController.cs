using System;

using UIKit;

namespace Application.iOS
{
	public partial class MoreViewController : UITableViewController
	{
		public MoreViewController (IntPtr handle) : base (handle)
		{
		}

		partial void LogOutTouchUpInside (UIKit.UIButton sender)
		{
			// present tab bar controller
			var storyBoard = UIStoryboard.FromName ("Main", null);
			var loginView = storyBoard.InstantiateViewController ("rootView") as UINavigationController;
			this.PresentViewController (loginView, animated: true, completionHandler: null);
		}
	}
}