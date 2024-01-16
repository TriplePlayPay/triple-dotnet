using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triple.Tokens
{
    public class PaymentMethodToken
    {
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; } 
        public string DigitalSignature { get; set; }
        public string Identifier { get; set; }
        public string CardType { get; set; }
        public string LastFourDigits { get; set; }
    }
}
