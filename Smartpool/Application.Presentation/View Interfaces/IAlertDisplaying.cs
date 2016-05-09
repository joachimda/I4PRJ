//========================================================================
// FILENAME :   IAlertDisplaying.cs
// DESCR.   :   Interface for displayers of alerts
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Presentation
{
    public interface IAlertDisplaying
    {
        /// <summary>
        /// Displays a message or alert on the view
        /// </summary>
        void DisplayAlert(string title, string content);
    }
}
