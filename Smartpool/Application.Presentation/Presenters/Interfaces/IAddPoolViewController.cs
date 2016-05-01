//========================================================================
// FILENAME :   IAddPoolViewController.cs
// DESCR.   :   Interface for the add pool presenters
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Presentation
{
    /// <summary>
	/// Enumeration of possible buttons on the Login View
	/// </summary>
    public enum AddPoolTextField
    {
        PoolName,
        Volume,
        Width,
        Length,
        Depth,
        SerialNumber
    }

    public interface IAddPoolViewController : IViewController
    {
        /// <summary>
        /// Called by the Add Pool View when the add button is pressed
        /// </summary>
        void AddPoolButtonPressed();

        /// <summary>
        /// Called by the Add Pool View when a text field has changed
        /// </summary>
        void DidChangeText(AddPoolTextField textField, string text);
    }
}
