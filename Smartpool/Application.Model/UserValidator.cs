//========================================================================
// FILENAME :   UserValidator.cs
// DESCR.   :   User validation model
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

using System;

// ReSharper disable once CheckNamespace

namespace Smartpool.Application.Model
{
    public class UserValidator
    {
        public string Name { get; set; } = "";
        public string[] Passwords { get; set; } = { "", "" };
        public string Email { get; set; } = "";
        public bool PasswordIsValid { get; set; } = false;
        public bool IsValid { get; set; } = false;
    }
}