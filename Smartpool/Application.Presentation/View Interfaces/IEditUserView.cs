//========================================================================
// FILENAME :   IEditUserView.cs
// DESCR.   :   Interface for the edit user views
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Presentation
{
    public interface IEditUserView : IView, IAlertDisplaying
    {
        /// <summary>
        /// Clears the text of all text fields
        /// </summary>
        void ClearAllText();

        /// <summary>
        /// Sets the state of the save button (save password)
        /// </summary>
        void SetSaveButtonEnabled(bool enabled);

        /// <summary>
        /// Sets the state of password indicator of the new password
        /// </summary>
        void SetNewPasswordValid(bool valid);

        /// <summary>
        /// Tells the view that the new password has been saved successfully
        /// </summary>
        void UpdateSuccessful();
    }
}