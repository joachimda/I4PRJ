//========================================================================
// FILENAME :   IEditPoolView.cs
// DESCR.   :   Interface for the add pool views
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

// ReSharper disable once CheckNamespace

using System;
using System.Collections.Generic;

namespace Smartpool.Application.Presentation
{
    public interface IEditPoolView : IView
    {
        /// <summary>
        /// Clears the text of the volume text field
        /// </summary>
        void ClearVolumeText();

        /// <summary>
        /// Clears the text of all the dimension text fields
        /// </summary>
        void ClearDimensionText();

        /// <summary>
        /// Sets the state of the save button (save updated info)
        /// </summary>
        void SetSaveButtonEnabled(bool enabled);

        /// <summary>
        /// Sets the list of available pools (tuples with name and notification status)
        /// </summary>
        void SetAvailablePools(List<Tuple<string, bool>> pools);

        /// <summary>
        /// Displays a message or alert on the view
        /// </summary>
        void DisplayAlert(string title, string content);

        /// <summary>
        /// Tells the view that a the changes have been saved successfully
        /// </summary>
        void PoolUpdated();
    }
}