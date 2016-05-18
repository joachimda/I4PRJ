// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Application.iOS
{
	[Register ("StatViewCell")]
	partial class StatViewCell
	{
		[Outlet]
		UIKit.UIImageView borderImage { get; set; }

		[Outlet]
		UIKit.UILabel dataLabel { get; set; }

		[Outlet]
		UIKit.UILabel nameLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (borderImage != null) {
				borderImage.Dispose ();
				borderImage = null;
			}
			if (dataLabel != null) {
				dataLabel.Dispose ();
				dataLabel = null;
			}
			if (nameLabel != null) {
				nameLabel.Dispose ();
				nameLabel = null;
			}
		}
	}
}
