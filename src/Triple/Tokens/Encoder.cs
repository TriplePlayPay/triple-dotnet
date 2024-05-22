using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triple.Tokens
{
    public class Encoder
    {
        public static string EncodeTokenString(string input)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}
