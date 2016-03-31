using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartpool.Application.Presentation
{
    public enum LoginViewButton : int
    {
        LoginButton = 0,
        SignUpButton = 1,
        ForgotButton = 2
    }

    public interface ILoginViewController
    {
        void ButtonPressed(LoginViewButton button);
        void DidChangeEmailText(string text);
        void DidChangePasswordText(string text);
    }
}
