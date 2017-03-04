using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuxyLib.Models.Client.Hosted
{
    public class Extra
    {
        public int Amount { get; internal set; }

        public Extra(JToken json)
        {
            if (json.SelectToken("amount") != null)
                Amount = int.Parse(json.SelectToken("amount").ToString());
        }
    }
}
