//========================================================================
// FILENAME :  IEditPoolViewController.cs
// DESCR.   :   Interface for the edit pool presenters
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Presentation
{
    /// <summary>
	/// Enumeration of possible input text fields on the Add Pool View
	/// </summary>
    public enum EditPoolTextField
    {
        PoolName,
        Volume,
        Width,
        Length,
        Depth
    }

    public interface IEditPoolViewController : IViewController
    {
        /// <summary>
        /// Called by the Edit Pool View when the save button is pressed
        /// </summary>
        void SaveButtonPressed();

        /// <summary>
        /// Called by the Edit Pool View when the delete button is pressed
        /// </summary>
        void DeleteButtonPressed();

        /// <summary>
        /// Called by the Edit Pool View when a text field has changed
        /// </summary>
        void DidChangeText(EditPoolTextField textField, string text);

        /// <summary>
        /// Called by the Edit Pool View when the user has selected a pool
        /// </summary>
        void DidSelectPool(string name);
    }
}
