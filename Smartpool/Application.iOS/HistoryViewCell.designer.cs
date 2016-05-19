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
	[Register ("HistoryViewCell")]
	partial class HistoryViewCell
	{
		[Outlet]
		UIKit.UIImageView borderImage { get; set; }

		[Outlet]
		UIKit.UIView graphView { get; set; }

		[Outlet]
		UIKit.UILabel maxLabel { get; set; }

		[Outlet]
		UIKit.UILabel minLabel { get; set; }

		[Outlet]
		UIKit.UILabel typeLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (borderImage != null) {
				borderImage.Dispose ();
				borderImage = null;
			}

			if (graphView != null) {
				graphView.Dispose ();
				graphView = null;
			}

			if (typeLabel != null) {
				typeLabel.Dispose ();
				typeLabel = null;
			}

			if (minLabel != null) {
				minLabel.Dispose ();
				minLabel = null;
			}

			if (maxLabel != null) {
				maxLabel.Dispose ();
				maxLabel = null;
			}
		}
	}
}
