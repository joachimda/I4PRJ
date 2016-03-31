using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartpool.Application.Presentation
{
    public interface ILoginView
    {
        void SetEmailText(string text);
        void SetPasswordText(string text);
        void SetLoginButtonEnabled(bool enabled);
        void DisplayAlert(string title, string content);
    }
}
