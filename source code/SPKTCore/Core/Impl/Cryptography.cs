using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPKTCore.Core.Impl
{
    public class Cryptography
    {

        public static string Encrypt(string p, string key)
        {
            return p + key;
        }

        public static string Decrypt(string s, string key)
        {
            return s.Substring(0, s.Length - key.Length);
        }
    }
}
