using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPKTCore.Core.Impl;

namespace SPKTCore.Core.Impl
{
    public static class Extensions
    {
        public static string Encrypt(this string s, string key)
        {

            return Cryptography.Encrypt(s, key);    
        }

        public static string Decrypt(this string s, string key)
        {
            return Cryptography.Decrypt(s, key);           
        }

        public static string TimestampToString(this System.Data.Linq.Binary binary)
        {
            byte[] binarybytes = binary.ToArray();
            string result = "";
            foreach (byte b in binarybytes)
            {
                result += b.ToString() + "|";
            }
            result = result.Substring(0, result.Length - 1);
            return result;
        }

        public static System.Data.Linq.Binary StringToTimestamp(this string s)
        {
            string[] arr = s.Split('|');
            byte[] bytes = new byte[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                bytes[i] = Convert.ToByte(arr[i]);
            }
            return bytes;
        }
        //public static string Serialize(this MailMessage MailMessage)
        //{
        //    string result = MailMessageService.Serialize(MailMessage);
        //    return result;
        //}

        //public static string SerializeEncrypted(this MailMessage MailMessage)
        //{
        //    string result = MailMessageService.SerializeEncrypted(MailMessage);
        //    return result;
        //}

        //public static MailMessage DeserializeEncrypted(this string SerializedAndEncryptedMailMessage)
        //{
        //    MailMessage result = MailMessageService.DeserializeEncrypted(SerializedAndEncryptedMailMessage);
        //    return result;
        //}

        //public static MailMessage Deserialize(this string SerializedMailMessage)
        //{
        //    MailMessage result = MailMessageService.Deserialize(SerializedMailMessage);
        //    return result;
        //}

        public static string Filter(this string s)
        {
            return ContentFilterService.Filter(s);
        }


        //public static string ToMD5Hash(this string s)
        //{
        //    return Cryptography.CreateMD5Hash(s);
        //}

        ////http://www.experts-exchange.com/Programming/Languages/C_Sharp/Q_22571864.html
        //public static List<Tag> ShuffleList(this List<Tag> listToShuffle)
        //{
        //    Random randomClass = new Random();

        //    for (int k = listToShuffle.Count - 1; k > 1; --k)
        //    {
        //        int randIndx = randomClass.Next(k); //
        //        Tag temp = listToShuffle[k];
        //        listToShuffle[k] = listToShuffle[randIndx]; // move random num to end of list.
        //        listToShuffle[randIndx] = temp;
        //    }
        //    return listToShuffle;
        //}
    }
}
