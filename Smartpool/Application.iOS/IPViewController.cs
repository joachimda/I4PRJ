using System;
using Foundation;
using UIKit;

namespace Application.iOS
{
	public partial class IPViewController : UIViewController
	{
		public IPViewController (IntPtr handle) : base (handle)
		{
		}

		partial void IPChanged (UIKit.UITextField sender)
		{
			iOSClientFactory.ServerIP = sender.Text;
		}

		public override void TouchesBegan (NSSet touches, UIEvent evt)
		{
			base.TouchesBegan (touches, evt);
			View.EndEditing (true);
		}
	}
}