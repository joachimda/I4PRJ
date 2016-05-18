//========================================================================
// FILENAME :   LoginViewBridge.cs
// DESCR.   :   Bridge between login view controller and iOS login view
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version, missing DisplayAlert implementation
// 1.1	LP		Redesigned view and now uses proper client
//========================================================================

using Smartpool.Application.Presentation;
using Smartpool.Connection.Model;
using System;
using Foundation;
using UIKit;
using System.Drawing;

namespace Application.iOS
{
	public partial class LoginViewBridge : UIViewController, ILoginView
	{
		private ILoginViewController _specializedController => Controller as ILoginViewController;

		public LoginViewBridge (IntPtr handle) : base (handle)
		{
			// Initialize view controller.
			Controller = new LoginViewController(this, iOSClientFactory.DefaultClient());
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			// Let the controller know that the view has finished loading.
			Controller.ViewDidLoad();
		}

		public override void TouchesBegan (NSSet touches, UIEvent evt)
		{
			base.TouchesBegan (touches, evt);
			View.EndEditing (true);
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
			
		partial void emailEditingChanged (UIKit.UITextField sender)
		{
			_specializedController.DidChangeEmailText(sender.Text);
		}

		partial void passwordEditingChanged (UIKit.UITextField sender)
		{
			_specializedController.DidChangePasswordText(sender.Text);
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