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
	}
}


