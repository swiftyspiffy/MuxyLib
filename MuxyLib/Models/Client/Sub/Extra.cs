using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuxyLib.Models.Client.Sub
{
    public class Extra
    {
        public int Amount { get; protected set; }
        public string Service { get; protected set; }
        public string ServiceId { get; protected set; }

        public Extra(JToken json)
        {
            if (json.SelectToken("amount") != null)
                Amount = int.Parse(json.SelectToken("amount").ToString());
            Service = json.SelectToken("service")?.ToString();
            ServiceId = json.SelectToken("service_id")?.ToString();
        }
    }
}
