//========================================================================
// FILENAME :   ITabbedViewController.cs
// DESCR.   :   Ínterface for view controllers nested in a tab bar controller
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
// 1.1	LP		LoadView and UnloadView added
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

		/// <summary>
		/// Called by the TabBarController to let the ViewController know it's View should be presented
		/// </summary>
		void LoadView();

		/// <summary>
		/// Called by the TabBarController to let the ViewController know it's View should end presentation
		/// </summary>
		void UnloadView();
    }
}
