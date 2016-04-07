//========================================================================
// FILENAME :   IView.cs
// DESCR.   :   Interface for views
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Presentation.Temp
{
    public interface IView
    {
		/// <summary>
		/// The view's controller, assign this during construction of the view
		/// </summary>
        IViewController Controller { get; set; }
    }
}