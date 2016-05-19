using System;
using Smartpool.Application.Presentation;
using UIKit;

namespace Application.iOS
{
	public partial class EditPoolViewBridge : UIViewController, IEditPoolView
	{
		private IEditPoolViewController _specializedController => Controller as IEditPoolViewController;

		public EditPoolViewBridge (IntPtr handle) : base (handle)
		{
			Controller = new IEditPoolViewController(this, iOSClientFactory.DefaultClient());
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

		/// <summary>
		/// Sets the list of available pools (tuples with name and notification status)
		/// </summary>
		public void SetAvailablePools(List<Tuple<string, bool>> pools)
		{
			// Missing implementation
		}

		/// <summary>
		/// Sets the currently selected pool index
		/// </summary>
		public void SetSelectedPoolIndex(int index)
		{
			// Missing implementation
		}

		// IEditPoolView

		/// <summary>
		/// Sets the text of the name text field
		/// </summary>
		public void SetNameText(string text)
		{
			// Missing implementation
		}

		/// <summary>
		/// Sets the text of the volume text field
		/// </summary>
		public void SetVolumeText(string text)
		{
			// Missing implementation
		}

		/// <summary>
		/// Sets the text of the serial number label
		/// </summary>
		public void SetSerialNumberText(string text)
		{
			// Missing implementation
		}

		/// <summary>
		/// Clears the text of all the dimension text fields
		/// </summary>
		public void ClearDimensionText()
		{
			// Missing implementation
		}

		/// <summary>
		/// Sets the state of the save button (save updated info)
		/// </summary>
		public void SetSaveButtonEnabled(bool enabled)
		{
			// Missing implementation
		}

		/// <summary>
		/// Sets the state of the delete button (delete pool)
		/// </summary>
		public void SetDeleteButtonEnabled(bool enabled)
		{
			// Missing implementation
		}

		/// <summary>
		/// Tells the view that a the changes have been saved successfully
		/// </summary>
		public void PoolUpdated()
		{
			// Missing implementation
		}
	}
}


