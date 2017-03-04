using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuxyLib.Models.Client.Donation
{
    public class Extra
    {
        public double Amount { get; protected set; }
        public string CurrencyCode { get; protected set; }
        public string CurrencyConversion { get; protected set; }
        public string TransactionSource { get; protected set; }

        public Extra(JToken json)
        {
            if (json.SelectToken("amount") != null)
                Amount = double.Parse(json.SelectToken("amount").ToString());
            CurrencyCode = json.SelectToken("currency_code")?.ToString();
            CurrencyConversion = json.SelectToken("currency_conversion")?.ToString();
            TransactionSource = json.SelectToken("transaction_source")?.ToString();
        }
    }
}
