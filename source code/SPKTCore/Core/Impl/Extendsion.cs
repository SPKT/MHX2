using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPKTCore.Core.Impl
{
    public static class Extendsion
    {
        public static string Encrypt(this string s, string key)
        {

            return Cryptography.Encrypt(s, key);    
        }

        public static string Decrypt(this string s, string key)
        {
            return Cryptography.Decrypt(s, key);           
        }
    }
}
