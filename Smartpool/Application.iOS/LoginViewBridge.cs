//========================================================================
// FILENAME :   LoginViewBridge.cs
// DESCR.   :   Bridge between login view controller and iOS login view
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version, missing DisplayAlert implementation
//========================================================================

using Smartpool.Application.Presentation;
using Smartpool.Connection.Model;
using System;
using UIKit;

namespace Application.iOS
{
	public partial class LoginViewBridge : UIViewController, ILoginView
	{
		private ILoginViewController _specializedController => Controller as ILoginViewController;

		public LoginViewBridge (IntPtr handle) : base (handle)
		{
			// Initialize view controller.
			Controller = new LoginViewController(this);
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

		// Actions

		partial void loginButtonTouchUpInside (Foundation.NSObject sender)
		{
			_specializedController.ButtonPressed(LoginViewButton.LoginButton);
		}

		partial void signupButtonTouchUpInside (Foundation.NSObject sender)
		{
			_specializedController.ButtonPressed(LoginViewButton.SignUpButton);
		}

		partial void forgotButtonTouchUpInside (Foundation.NSObject sender)
		{
			_specializedController.ButtonPressed(LoginViewButton.ForgotButton);
		}

		partial void emailValueChanged (Foundation.NSObject sender)
		{
			var textField = sender as UITextField;
			if (textField.Text != null) _specializedController.DidChangeEmailText(textField.Text);
		}

		partial void passwordValueChanged (Foundation.NSObject sender)
		{
			var textField = sender as UITextField;
			if (textField.Text != null) _specializedController.DidChangePasswordText(textField.Text);
		}

		// IView Interface Implementation

		public IViewController Controller { get; set; }

		// ILoginView Interface Implementation

		public void LoginAccepted()
		{
			// present tab bar controller
			var storyBoard = UIStoryboard.FromName ("Main", null);
			var tabBarController = storyBoard.InstantiateViewController ("tabBarController") as UITabBarController;
			this.PresentViewController (tabBarController, animated: true, completionHandler: null);
		}

		public void SetEmailText(string text)
		{
			emailTextField.Text = text;
		}

		public void SetPasswordText(string text)
		{
			passwordTextField.Text = text;
		}

		public void SetLoginButtonEnabled(bool enabled)
		{
			loginButton.Enabled = enabled;
			loginButton.Alpha = enabled ? (nfloat) 1.0 : (nfloat) 0.2;
		}

		public void DisplayAlert(string title, string content)
		{
			// This is only a temporary implementation and should be replaced.
		}
	}
}