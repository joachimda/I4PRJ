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
		}
	}
}
