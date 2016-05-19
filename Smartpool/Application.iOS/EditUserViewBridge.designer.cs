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
	[Register ("EditUserViewBridge")]
	partial class EditUserViewBridge
	{
		[Outlet]
		UIKit.UITextField NewPasswordRepeatedTextField { get; set; }

		[Outlet]
		UIKit.UITextField NewPasswordTextField { get; set; }

		[Outlet]
		UIKit.UITextField OldPasswordTextField { get; set; }

		[Outlet]
		UIKit.UIButton SaveButton { get; set; }

		[Action ("NewPasswordChanged:")]
		partial void NewPasswordChanged (UIKit.UITextField sender);

		[Action ("NewPasswordRepeatedChanged:")]
		partial void NewPasswordRepeatedChanged (UIKit.UITextField sender);

		[Action ("OldPasswordChanged:")]
		partial void OldPasswordChanged (UIKit.UITextField sender);

		[Action ("SaveButtonTouchUpInside:")]
		partial void SaveButtonTouchUpInside (UIKit.UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (NewPasswordRepeatedTextField != null) {
				NewPasswordRepeatedTextField.Dispose ();
				NewPasswordRepeatedTextField = null;
			}
			if (NewPasswordTextField != null) {
				NewPasswordTextField.Dispose ();
				NewPasswordTextField = null;
			}
			if (OldPasswordTextField != null) {
				OldPasswordTextField.Dispose ();
				OldPasswordTextField = null;
			}
			if (SaveButton != null) {
				SaveButton.Dispose ();
				SaveButton = null;
			}
		}
	}
}
