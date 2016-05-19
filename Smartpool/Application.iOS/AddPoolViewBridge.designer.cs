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
	[Register ("AddPoolViewBridge")]
	partial class AddPoolViewBridge
	{
		[Outlet]
		UIKit.UITextField NameTextField { get; set; }

		[Outlet]
		UIKit.UIButton SaveButton { get; set; }

		[Outlet]
		UIKit.UITextField SerialNumberTextField { get; set; }

		[Outlet]
		UIKit.UITextField VolumeTextField { get; set; }

		[Action ("NameChanged:")]
		partial void NameChanged (UIKit.UITextField sender);

		[Action ("SaveButtonTouchUpInside:")]
		partial void SaveButtonTouchUpInside (UIKit.UIButton sender);

		[Action ("SerialNumberChanged:")]
		partial void SerialNumberChanged (UIKit.UITextField sender);

		[Action ("VolumeChanged:")]
		partial void VolumeChanged (UIKit.UITextField sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (NameTextField != null) {
				NameTextField.Dispose ();
				NameTextField = null;
			}

			if (VolumeTextField != null) {
				VolumeTextField.Dispose ();
				VolumeTextField = null;
			}

			if (SerialNumberTextField != null) {
				SerialNumberTextField.Dispose ();
				SerialNumberTextField = null;
			}

			if (SaveButton != null) {
				SaveButton.Dispose ();
				SaveButton = null;
			}
		}
	}
}
