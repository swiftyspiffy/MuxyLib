using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuxyLib.Models.Client.Follow
{
    public class Extra
    {
        public bool Notificaiton { get; protected set; }
        public string Username { get; protected set; }

        public Extra(JToken json)
        {
            bool isNotification;
            if(json.SelectToken("notification") != null)
                Notificaiton = bool.TryParse(json.SelectToken("notification").ToString(), out isNotification) && isNotification;
            Username = json.SelectToken("username")?.ToString();
        }
    }
}
