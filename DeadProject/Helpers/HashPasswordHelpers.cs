using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Web;
using System.Web.Helpers;

namespace DeadProject.Helpers
{
    public static class HashPasswordHelpers
    {
        public static void CreateAccount(string username, string password)
        {
            var hashedPassword = Crypto.HashPassword(password);
        }

        public static bool ValidateCredentials(string username, string password)
        {
            var hashedPassword = GetPasswordFromDatabase(username);
            var doesPasswordMatch = Crypto.VerifyHashedPassword(hashedPassword, password);
            return doesPasswordMatch;
        }
    }
}