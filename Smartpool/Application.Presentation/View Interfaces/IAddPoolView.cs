//========================================================================
// FILENAME :   IAddPoolView.cs
// DESCR.   :   Interface for the add pool views
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Presentation
{
    public interface IAddPoolView : IView
    {
        /// <summary>
        /// Sets the text of the serial number text field
        /// </summary>
        void SetSerialNumberText(string text);

        /// <summary>
        /// Sets the state of the add pool button
        /// </summary>
        void SetAddPoolButtonEnabled(bool enabled);

        /// <summary>
        /// Displays a message or alert on the view
        /// </summary>
        void DisplayAlert(string title, string content);

        /// <summary>
        /// Tells the view that a the pool has been added successfully
        /// </summary>
        void PoolAdded();
    }
}