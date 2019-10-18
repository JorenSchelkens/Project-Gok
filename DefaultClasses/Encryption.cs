using System;
using System.Security.Cryptography;
using System.Text;

namespace DefaultClasses
{
    public class Encryption
    {
        public static string EncryptString(string text)
        {
            byte[] b = Encoding.ASCII.GetBytes(text);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }

    }
}
