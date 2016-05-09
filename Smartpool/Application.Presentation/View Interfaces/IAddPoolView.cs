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
    public interface IAddPoolView : IView, IAlertDisplaying
    {
        /// <summary>
        /// Sets the text of the serial number text field
        /// </summary>
        void SetSerialNumberText(string text);

        /// <summary>
        /// Clears the text of the volume text field
        /// </summary>
        void ClearVolumeText();

        /// <summary>
        /// Clears the text of all the dimension text fields
        /// </summary>
        void ClearDimensionText();

        /// <summary>
        /// Sets the state of the add pool button
        /// </summary>
        void SetAddPoolButtonEnabled(bool enabled);

        /// <summary>
        /// Tells the view that a the pool has been added successfully
        /// </summary>
        void PoolAdded();
    }
}