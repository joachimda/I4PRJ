// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Application.iOS
{
	[Register ("StatViewBridge")]
	partial class StatViewBridge
	{
		[Outlet]
		UIKit.UIBarButtonItem PoolsBarButtonItem { get; set; }

		[Action ("PoolsBarButtonItemTouchUpInside:")]
		partial void PoolsBarButtonItemTouchUpInside (UIKit.UIBarButtonItem sender);

		void ReleaseDesignerOutlets ()
		{
			if (PoolsBarButtonItem != null) {
				PoolsBarButtonItem.Dispose ();
				PoolsBarButtonItem = null;
			}
		}
	}
}
