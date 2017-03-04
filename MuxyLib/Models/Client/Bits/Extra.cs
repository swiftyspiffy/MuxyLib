using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuxyLib.Models.Client.Bits
{
    public class Extra
    {
        public int Amount { get; protected set; }
        public string AmountParts { get; protected set; }
        public string Cumulative { get; protected set; }
        public string Emotes { get; protected set; }
        public string MsgId { get; protected set; }
        public string TypeParts { get; protected set; }

        public Extra(JToken json)
        {
            if (json.SelectToken("amount") != null)
                Amount = int.Parse(json.SelectToken("amount").ToString());
            AmountParts = json.SelectToken("amount_parts")?.ToString();
            Cumulative = json.SelectToken("cumulative")?.ToString();
            Emotes = json.SelectToken("emotes")?.ToString();
            MsgId = json.SelectToken("msg_id")?.ToString();
            TypeParts = json.SelectToken("type_parts")?.ToString();
        }
    }
}
