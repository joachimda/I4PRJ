//========================================================================
// FILENAME :   IViewController.cs
// DESCR.   :   Ínterface for view controllers
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Presentation
{
    public interface IViewController
    {
        /// <summary>
        /// Called when the ViewController's View has finished loading
        /// </summary>
        void ViewDidLoad();
    }
}