// WARNING
//
// This file has been generated automatically by Xamarin Studio Community to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

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
