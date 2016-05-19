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
	[Register ("EditPoolViewBridge")]
	partial class EditPoolViewBridge
	{
		[Outlet]
		UIKit.UIButton DeleteButton { get; set; }

		[Outlet]
		UIKit.UITextField NameTextField { get; set; }

		[Outlet]
		UIKit.UIBarButtonItem PoolsBarButtonItem { get; set; }

		[Outlet]
		UIKit.UIButton SaveButton { get; set; }

		[Outlet]
		UIKit.UILabel SerialNumberLabel { get; set; }

		[Outlet]
		UIKit.UITextField VolumeTextField { get; set; }

		[Action ("DeleteButtonTouchUpInside:")]
		partial void DeleteButtonTouchUpInside (UIKit.UIButton sender);

		[Action ("NameChanged:")]
		partial void NameChanged (UIKit.UITextField sender);

		[Action ("PoolsBarButtonItemTouchUpInside:")]
		partial void PoolsBarButtonItemTouchUpInside (UIKit.UIBarButtonItem sender);

		[Action ("SaveButtonTouchUpInside:")]
		partial void SaveButtonTouchUpInside (UIKit.UIButton sender);

		[Action ("VolumeChanged:")]
		partial void VolumeChanged (UIKit.UITextField sender);

		void ReleaseDesignerOutlets ()
		{
			if (DeleteButton != null) {
				DeleteButton.Dispose ();
				DeleteButton = null;
			}
			if (NameTextField != null) {
				NameTextField.Dispose ();
				NameTextField = null;
			}
			if (PoolsBarButtonItem != null) {
				PoolsBarButtonItem.Dispose ();
				PoolsBarButtonItem = null;
			}
			if (SaveButton != null) {
				SaveButton.Dispose ();
				SaveButton = null;
			}
			if (SerialNumberLabel != null) {
				SerialNumberLabel.Dispose ();
				SerialNumberLabel = null;
			}
			if (VolumeTextField != null) {
				VolumeTextField.Dispose ();
				VolumeTextField = null;
			}
		}
	}
}
