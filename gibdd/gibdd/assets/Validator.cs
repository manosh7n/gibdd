using System;
using System.Text.RegularExpressions;
namespace gibdd
{
    public static class Validator
    {
        public static bool nameValidator(string name)
        {
            try
            {
                return Regex.IsMatch(name, @"^[а-я]+(?:\W[а-я]+)+$", RegexOptions.IgnoreCase);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool emailValidator(string email)
        {
            try {
                var pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";    
                var regex = new Regex(pattern, RegexOptions.IgnoreCase);    
                return regex.IsMatch(email);
            }
            catch {
                return false;
            }
        }
    }
}