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
        public const int MinimumCharacters = 8;

        public string Name { get; set; } = "";
        public string[] Passwords { get; set; } = { "", "" };
        public string Email { get; set; } = "";

        public bool PasswordIsValid => Passwords[0].Length >= MinimumCharacters && Passwords[0] == Passwords[1];
        public bool IsValid => PasswordIsValid && Name.Length > 0 && Email.Length > 0;
    }
}