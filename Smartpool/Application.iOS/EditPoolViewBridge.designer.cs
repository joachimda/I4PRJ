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
			if (PoolsBarButtonItem != null) {
				PoolsBarButtonItem.Dispose ();
				PoolsBarButtonItem = null;
			}

			if (NameTextField != null) {
				NameTextField.Dispose ();
				NameTextField = null;
			}

			if (VolumeTextField != null) {
				VolumeTextField.Dispose ();
				VolumeTextField = null;
			}

			if (SerialNumberLabel != null) {
				SerialNumberLabel.Dispose ();
				SerialNumberLabel = null;
			}

			if (SaveButton != null) {
				SaveButton.Dispose ();
				SaveButton = null;
			}

			if (DeleteButton != null) {
				DeleteButton.Dispose ();
				DeleteButton = null;
			}
		}
	}
}
