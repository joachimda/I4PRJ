//========================================================================
// FILENAME :   ILoginView.cs
// DESCR.   :   Interface for login views
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Presentation
{
    public interface ILoginView : IView
    {
        void SetEmailText(string text);
        void SetPasswordText(string text);
        void SetLoginButtonEnabled(bool enabled);
        void DisplayAlert(string title, string content);
    }
}