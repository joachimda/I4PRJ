//========================================================================
// FILENAME :   IStatViewController.cs
// DESCR.   :   Ínterface for the view controller presenting stats
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Presentation
{
	/// <summary>
	/// Enumeration of possible buttons on the Stat View
	/// </summary>
	public enum StatViewButton : int
	{
	}
	
	public interface IStatViewController : ITabbedViewController
	{
		/// <summary>
		/// Called by the Stat View when a button is pressed
		/// </summary>
		void ButtonPressed(StatViewButton button);
	}
}