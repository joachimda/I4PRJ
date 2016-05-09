//========================================================================
// FILENAME :   ITabBarController.cs
// DESCR.   :   Interface for tab bar controllers
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Presentation
{
    public interface ITabBarController
    {
		/// <summary>
		/// The active view controller index of list of view controllers in the tab bar controller
		/// </summary>
        int TopViewControllerIndex { get; set; }
    }
}
