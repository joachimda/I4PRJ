//========================================================================
// FILENAME :   EditPoolViewBridge.cs
// DESCR.   :   Bridge between edit pool view controller and iOS view
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version, missing pool selection
//========================================================================

using System;
using System.Collections.Generic;
using Smartpool.Application.Presentation;
using UIKit;

namespace Application.iOS
{
	public partial class EditPoolViewBridge : UIViewController, IEditPoolView
	{
		private IEditPoolViewController _specializedController => Controller as IEditPoolViewController;

		public EditPoolViewBridge (IntPtr handle) : base (handle)
		{
			Controller = new EditPoolViewController(this, iOSClientFactory.DefaultClient());
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

		// IPoolDisplaying

		private List<Tuple<string, bool>> _pools = new List<Tuple<string, bool>> ();

		public void SetAvailablePools(List<Tuple<string, bool>> pools)
		{
			_pools = pools;
		}

		public void SetSelectedPoolIndex(int index)
		{
			PoolsBarButtonItem.Title = _pools [index].Item1;
		}

		// IEditPoolView

		public void SetNameText(string text)
		{
			NameTextField.Text = text;
		}
			
		public void SetVolumeText(string text)
		{
			VolumeTextField.Text = text;
		}
			
		public void SetSerialNumberText(string text)
		{
			SerialNumberLabel.Text = text;
		}
			
		public void ClearDimensionText()
		{
			// Not applicable for iOS
		}
			
		public void SetSaveButtonEnabled(bool enabled)
		{
			SaveButton.Enabled = enabled;
			SaveButton.Alpha = enabled ? (nfloat) 1.0 : (nfloat) 0.2;
		}
			
		public void SetDeleteButtonEnabled(bool enabled)
		{
			DeleteButton.Enabled = enabled;
			DeleteButton.Alpha = enabled ? (nfloat) 1.0 : (nfloat) 0.2;
		}
			
		public void PoolUpdated()
		{
			// return to previous view
			NavigationController?.PopViewController(true);
		}

		// Actions

		partial void DeleteButtonTouchUpInside (UIKit.UIButton sender)
		{
			_specializedController.DeleteButtonPressed();
		}
			
		partial void NameChanged (UIKit.UITextField sender)
		{
			_specializedController.DidChangeText(EditPoolTextField.PoolName, sender.Text);
		}
			
		partial void PoolsBarButtonItemTouchUpInside (UIKit.UIBarButtonItem sender)
		{
			// Missing implementation
		}
			
		partial void SaveButtonTouchUpInside (UIKit.UIButton sender)
		{
			_specializedController.SaveButtonPressed();
		}
			
		partial void VolumeChanged (UIKit.UITextField sender)
		{
			_specializedController.DidChangeText(EditPoolTextField.Volume, sender.Text);
		}
	}
}


