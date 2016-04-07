//========================================================================
// FILENAME :   ITabbedViewController.cs
// DESCR.   :   Ínterface for view controllers nested in a tab bar controller
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Presentation
{
    public interface ITabbedViewController : IViewController
    {
        /// <summary>
        /// The ViewController's TabBarController
        /// </summary>
        ITabBarController TabBarController { get; set; }
    }
}
