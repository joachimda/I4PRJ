using System;

using Foundation;
using UIKit;

namespace Application.iOS
{
	public partial class StatViewCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("StatViewCell");
		public static readonly UINib Nib;

		static StatViewCell ()
		{
			Nib = UINib.FromName ("StatViewCell", NSBundle.MainBundle);
		}

		public StatViewCell (IntPtr handle) : base (handle)
		{
		}

		public UIImageView BorderImage {
			get {
				return borderImage;
			}
		}
		public UILabel DataLabel {
			get {
				return dataLabel;
			}
		}

		public UILabel NameLabel {
			get {
				return nameLabel;
			}
		}

	}
}