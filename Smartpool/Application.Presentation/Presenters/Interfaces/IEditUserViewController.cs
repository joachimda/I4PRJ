//========================================================================
// FILENAME :   IEditUserViewController.cs
// DESCR.   :   Interface for edit user view presenters
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Presentation
{
    public interface IEditUserViewController : IViewController
    {
        /// <summary>
        /// Called by the view when the save button is pressed
        /// </summary>
        void SaveButtonPressed();

        /// <summary>
        /// Called by the Edit User View when the old password text field changed
        /// </summary>
        void DidChangeOldPasswordText(string text);

        /// <summary>
        /// Called by the Edit User View when either of the new password text fields changed
        /// </summary>
        void DidChangeNewPasswordText(string text, int fieldNumber);
    }
}
