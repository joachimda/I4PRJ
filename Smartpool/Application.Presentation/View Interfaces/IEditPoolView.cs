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
    public interface IEditPoolView : IView, IPoolDisplaying, IAlertDisplaying
    {
        /// <summary>
        /// Sets the text of the name text field
        /// </summary>
        void SetNameText(string text);

        /// <summary>
        /// Sets the text of the volume text field
        /// </summary>
        void SetVolumeText(string text);

        /// <summary>
        /// Clears the text of all the dimension text fields
        /// </summary>
        void ClearDimensionText();

        /// <summary>
        /// Sets the state of the save button (save updated info)
        /// </summary>
        void SetSaveButtonEnabled(bool enabled);

        /// <summary>
        /// Sets the state of the delete button (delete pool)
        /// </summary>
        void SetDeleteButtonEnabled(bool enabled);

        /// <summary>
        /// Tells the view that a the changes have been saved successfully
        /// </summary>
        void PoolUpdated();
    }
}