//========================================================================
// FILENAME :   UserValidator.cs
// DESCR.   :   Model for validating user info, useful for when users must
//              be edited or created. Store the user info temporarily here
//              and call a suitable "Valid" method to check if input is
//              valid for a given context.
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
        public bool IsValidForSignup => PasswordIsValid && Name.Length > 0 && Email.Length > 0;
        public bool IsValidForLogin => Email.Length > 0 && Passwords[0].Length > 0;
    }
}