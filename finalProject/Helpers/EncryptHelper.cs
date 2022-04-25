using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace finalProject.Helpers
{
    public static class EncryptHelper
    {
        public static string Encode(string str)
        {
            SHA256 code = SHA256Managed.Create();

            ASCIIEncoding encodig = new ASCIIEncoding();

            byte[] stream = null;

            StringBuilder stringBuilder = new StringBuilder();

            stream = code.ComputeHash(encodig.GetBytes(str));

            for (int i = 0; i < stream.Length; i++) stringBuilder.AppendFormat("{0:x2}", stream[i]);
            return stringBuilder.ToString();
        }
    }
}