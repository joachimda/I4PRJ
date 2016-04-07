//========================================================================
// FILENAME :   ITabbedView.cs
// DESCR.   :   Interface for views in a tab bar environment
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Presentation
{
	public interface ITabbedView : IView
	{
		/// <summary>
		/// Presents the view, i.e. open()
		/// </summary>
		void Load();

		/// <summary>
		/// Hides or closes the view, i.e. close()
		/// </summary>
		void Unload();
	}
}