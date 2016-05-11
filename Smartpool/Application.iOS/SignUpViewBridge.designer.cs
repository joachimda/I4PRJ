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
	[Register ("SignUpViewBridge")]
	partial class SignUpViewBridge
	{
		[Outlet]
		UIKit.UITextField emailTextField { get; set; }

		[Outlet]
		UIKit.UITextField nameTextField { get; set; }

		[Outlet]
		UIKit.UITextField passwordTextFieldOne { get; set; }

		[Outlet]
		UIKit.UITextField passwordTextFieldTwo { get; set; }

		[Outlet]
		UIKit.UIButton signUpButton { get; set; }

		[Action ("cancelButtonTouchUpInside:")]
		partial void cancelButtonTouchUpInside (Foundation.NSObject sender);

		[Action ("emailEditingChanged:")]
		partial void emailEditingChanged (UIKit.UITextField sender);

		[Action ("emailTextFieldValueChanged:")]
		partial void emailTextFieldValueChanged (Foundation.NSObject sender);

		[Action ("nameEditingChanged:")]
		partial void nameEditingChanged (UIKit.UITextField sender);

		[Action ("nameTextFieldValueChanged:")]
		partial void nameTextFieldValueChanged (Foundation.NSObject sender);

		[Action ("passwordOneEditingChanged:")]
		partial void passwordOneEditingChanged (UIKit.UITextField sender);

		[Action ("passwordTextFieldOneValueChanged:")]
		partial void passwordTextFieldOneValueChanged (Foundation.NSObject sender);

		[Action ("passwordTextFieldTwoValueChanged:")]
		partial void passwordTextFieldTwoValueChanged (Foundation.NSObject sender);

		[Action ("passwordTwoEditingChanged:")]
		partial void passwordTwoEditingChanged (UIKit.UITextField sender);

		[Action ("signUpButtonTouchUpInside:")]
		partial void signUpButtonTouchUpInside (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (emailTextField != null) {
				emailTextField.Dispose ();
				emailTextField = null;
			}

			if (nameTextField != null) {
				nameTextField.Dispose ();
				nameTextField = null;
			}

			if (passwordTextFieldOne != null) {
				passwordTextFieldOne.Dispose ();
				passwordTextFieldOne = null;
			}

			if (passwordTextFieldTwo != null) {
				passwordTextFieldTwo.Dispose ();
				passwordTextFieldTwo = null;
			}

			if (signUpButton != null) {
				signUpButton.Dispose ();
				signUpButton = null;
			}
		}
	}
}
