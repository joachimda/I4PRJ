//========================================================================
// FILENAME :   EditUserViewBridge.cs
// DESCR.   :   Bridge between edit user view controller and iOS view
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version, missing IBOutlets
//========================================================================


using System;
using Smartpool.Application.Presentation;
using UIKit;

namespace Application.iOS
{
	public partial class EditUserViewBridge : UIViewController, IEditUserView
	{
		private IEditUserViewController _specializedController => Controller as IEditUserViewController;

		public EditUserViewBridge (IntPtr handle) : base (handle)
		{
			Controller = new EditUserViewController(this, new iOSClientMessenger());
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			// Let the controller know that the view has finished loading.
			Controller.ViewDidLoad();
		}

		// IView

		public IViewController Controller { get; set; }

		// IAlertDisplaying

		public void DisplayAlert(string title, string content)
		{
			// Missing implementation
		}

		// IEditUserView

		public void ClearAllText()
		{
			// Missing implementation
		}
			
		public void SetSaveButtonEnabled(bool enabled)
		{
			// Missing implementation
		}
			
		public void SetNewPasswordValid(bool valid)
		{
			// Missing implementation
		}
			
		public void UpdateSuccessful()
		{
			// Missing implementation
		}

		// Actions

		partial void NewPasswordChanged (UIKit.UITextField sender)
		{
			_specializedController.DidChangeNewPasswordText(sender.Text, 0);
		}

		partial void NewPasswordRepeatedChanged (UIKit.UITextField sender)
		{
			_specializedController.DidChangeNewPasswordText(sender.Text, 1);
		}

		partial void OldPasswordChanged (UIKit.UITextField sender)
		{
			_specializedController.DidChangeOldPasswordText(sender.Text);
		}

		partial void SaveButtonTouchUpInside (UIKit.UIButton sender)
		{
			_specializedController.SaveButtonPressed();
		}
	}
}


