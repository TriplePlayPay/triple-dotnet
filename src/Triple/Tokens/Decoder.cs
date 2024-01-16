using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triple.Tokens
{
    public static class Decoder
    {
        public static string DecodeTokenString(string input)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(input);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static PaymentMethodToken DecodeTokenEntity(string input)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(input);
            string tokenString = Encoding.UTF8.GetString(base64EncodedBytes);

            string[] components = tokenString.Split('-');

            PaymentMethodToken paymentMethodToken = new PaymentMethodToken()
            {
                Identifier = components[0],
                CardType = components[1],
                LastFourDigits = components[2],
                ExpirationMonth = components[3],
                ExpirationYear = components[4],
                DigitalSignature = components[5],
            };

            return paymentMethodToken;
        }
    }
}
