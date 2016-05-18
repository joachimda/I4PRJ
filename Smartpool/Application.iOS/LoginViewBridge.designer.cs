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
	[Register ("LoginViewBridge")]
	partial class LoginViewBridge
	{
		[Outlet]
		UIKit.UITextField emailTextField { get; set; }

		[Outlet]
		UIKit.UIButton loginButton { get; set; }

		[Outlet]
		UIKit.UITextField passwordTextField { get; set; }

		[Action ("loginButtonTouchUpInside:")]
		partial void loginButtonTouchUpInside (Foundation.NSObject sender);

		[Action ("signupButtonTouchUpInside:")]
		partial void signupButtonTouchUpInside (Foundation.NSObject sender);

		[Action ("forgotButtonTouchUpInside:")]
		partial void forgotButtonTouchUpInside (Foundation.NSObject sender);

		[Action ("emailEditingChanged:")]
		partial void emailEditingChanged (UIKit.UITextField sender);

		[Action ("passwordEditingChanged:")]
		partial void passwordEditingChanged (UIKit.UITextField sender);

		[Action ("emailValueChanged:")]
		partial void emailValueChanged (Foundation.NSObject sender);

		[Action ("passwordValueChanged:")]
		partial void passwordValueChanged (Foundation.NSObject sender);

		void ReleaseDesignerOutlets ()
		{
			if (emailTextField != null) {
				emailTextField.Dispose ();
				emailTextField = null;
			}
			if (loginButton != null) {
				loginButton.Dispose ();
				loginButton = null;
			}
			if (passwordTextField != null) {
				passwordTextField.Dispose ();
				passwordTextField = null;
			}
		}
	}
}
