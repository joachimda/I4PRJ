//========================================================================
// FILENAME :   AddPoolViewBridge.cs
// DESCR.   :   Bridge between add pool view controller and iOS view
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

using System;
using Smartpool.Application.Presentation;
using UIKit;

namespace Application.iOS
{
	public partial class AddPoolViewBridge : UIViewController, IAddPoolView
	{
		private IAddPoolViewController _specializedController => Controller as IAddPoolViewController;

		public AddPoolViewBridge (IntPtr handle) : base (handle)
		{
			Controller = new AddPoolViewController(this, iOSClientFactory.DefaultClient());
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

		// IAddPoolView

		public void SetSerialNumberText(string text)
		{
			SerialNumberTextField.Text = text;
		}
			
		public void ClearVolumeText()
		{
			VolumeTextField.Text = "";
		}
			
		public void ClearDimensionText()
		{
			// Not applicable for iOS
		}

		public void SetAddPoolButtonEnabled(bool enabled)
		{
			SaveButton.Enabled = enabled;
			SaveButton.Alpha = enabled ? (nfloat) 1.0 : (nfloat) 0.2;
		}
			
		public void PoolAdded()
		{
			// return to previous view
			NavigationController?.PopViewController(true);
		}

		// Actions

		partial void NameChanged (UIKit.UITextField sender)
		{
			_specializedController.DidChangeText(AddPoolTextField.PoolName, sender.Text);
		}

		partial void SaveButtonTouchUpInside (UIKit.UIButton sender)
		{
			_specializedController.AddPoolButtonPressed();
		}

		partial void SerialNumberChanged (UIKit.UITextField sender)
		{
			_specializedController.DidChangeText(AddPoolTextField.SerialNumber, sender.Text);
		}

		partial void VolumeChanged (UIKit.UITextField sender)
		{
			_specializedController.DidChangeText(AddPoolTextField.Volume, sender.Text);
		}

	}
}


