//========================================================================
// FILENAME :   SignUpViewBridge.cs
// DESCR.   :   Bridge between sign up view controller and iOS sign up view
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

using Smartpool.Application.Presentation;
using Smartpool.Connection.Model;
using System;
using UIKit;

namespace Application.iOS
{
	public partial class SignUpViewBridge : UIViewController, ISignUpView
	{
		public SignUpViewBridge (IntPtr handle) : base (handle)
		{
			// Initialize view controller.
			Controller = new SignUpViewController(this);
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			// Let the controller know that the view has finished loading.
			Controller.ViewDidLoad();
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		// IView Interface Implementation

		public IViewController Controller { get; set; }

		// ISignUpView Interface Implementation

		public void SetNameText(string text)
		{
			nameTextField.Text = text;
		}
			
		public void SetEmailText(string text)
		{
			emailTextField.Text = text;
		}
			
		public void SetPasswordText(string text)
		{
			passwordTextFieldOne.Text = text;
			passwordTextFieldTwo.Text = text;
		}
			
		public void SetPasswordValid(bool valid)
		{
			if (valid) {
				passwordTextFieldTwo.TextColor = UIColor.White;
			} else {
				passwordTextFieldTwo.TextColor = UIColor.Red;
			}
		}
			
		public void SetButtonEnabled(bool enabled)
		{
			signUpButton.Enabled = enabled;
			signUpButton.Alpha = enabled ? (nfloat) 1.0 : (nfloat) 0.2;
		}
			
		public void DisplayAlert(string title, string content)
		{
			// Implementation missing
		}
			
		public void SignUpAccepted()
		{
			// Implementation missing
		}

		// Actions

		partial void cancelButtonTouchUpInside (Foundation.NSObject sender)
		{
			// return to previous view
		}

		partial void emailTextFieldValueChanged (Foundation.NSObject sender)
		{
			var textField = sender as UITextField;
			var controller = Controller as ISignUpViewController;
			if (textField.Text != null) controller?.DidChangeEmailText(textField.Text);
		}
			
		partial void nameTextFieldValueChanged (Foundation.NSObject sender)
		{
			var textField = sender as UITextField;
			var controller = Controller as ISignUpViewController;
			if (textField.Text != null) controller?.DidChangeNameText(textField.Text);
		}
			
		partial void passwordTextFieldOneValueChanged (Foundation.NSObject sender)
		{
			var textField = sender as UITextField;
			var controller = Controller as ISignUpViewController;
			if (textField.Text != null) controller?.DidChangePasswordText(textField.Text, 0);
		}
			
		partial void passwordTextFieldTwoValueChanged (Foundation.NSObject sender)
		{
			var textField = sender as UITextField;
			var controller = Controller as ISignUpViewController;
			if (textField.Text != null) controller?.DidChangePasswordText(textField.Text, 0);
		}
			
		partial void signUpButtonTouchUpInside (Foundation.NSObject sender)
		{
			var controller = Controller as ISignUpViewController;
			controller?.ButtonPressed();
		}
	}
}