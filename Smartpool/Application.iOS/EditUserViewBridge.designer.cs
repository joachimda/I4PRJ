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
	[Register ("EditUserViewBridge")]
	partial class EditUserViewBridge
	{
		[Action ("NewPasswordChanged:")]
		partial void NewPasswordChanged (UIKit.UITextField sender);

		[Action ("NewPasswordRepeatedChanged:")]
		partial void NewPasswordRepeatedChanged (UIKit.UITextField sender);

		[Action ("OldPasswordChanged:")]
		partial void OldPasswordChanged (UIKit.UITextField sender);

		[Action ("SaveButtonTouchUpInside:")]
		partial void SaveButtonTouchUpInside (UIKit.UIButton sender);
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}