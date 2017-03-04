using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuxyLib.Models.Client.SessionChange
{
    public class Extra
    {
        public bool IsLive { get; internal set; }

        public Extra(JToken json)
        {
            bool isIsLive;
            IsLive = bool.TryParse(json.SelectToken("islive").ToString(), out isIsLive) && isIsLive;
        }
    }
}
