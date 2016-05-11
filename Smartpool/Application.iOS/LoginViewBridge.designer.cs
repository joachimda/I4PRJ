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
	[Register ("LoginViewBridge")]
	partial class LoginViewBridge
	{
		[Outlet]
		UIKit.UITextField emailTextField { get; set; }

		[Outlet]
		UIKit.UIButton loginButton { get; set; }

		[Outlet]
		UIKit.UITextField passwordTextField { get; set; }

		[Action ("emailEditingChanged:")]
		partial void emailEditingChanged (UIKit.UITextField sender);

		[Action ("emailValueChanged:")]
		partial void emailValueChanged (Foundation.NSObject sender);

		[Action ("forgotButtonTouchUpInside:")]
		partial void forgotButtonTouchUpInside (Foundation.NSObject sender);

		[Action ("loginButtonTouchUpInside:")]
		partial void loginButtonTouchUpInside (Foundation.NSObject sender);

		[Action ("passwordEditingChanged:")]
		partial void passwordEditingChanged (UIKit.UITextField sender);

		[Action ("passwordValueChanged:")]
		partial void passwordValueChanged (Foundation.NSObject sender);

		[Action ("signupButtonTouchUpInside:")]
		partial void signupButtonTouchUpInside (Foundation.NSObject sender);
		
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
