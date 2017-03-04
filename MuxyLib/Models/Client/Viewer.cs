using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuxyLib.Models.Client
{
    public class Viewer
    {
        public string Id { get; protected set; }
        public string Name { get; protected set; }

        public Viewer(JToken json)
        {
            Id = json.SelectToken("id")?.ToString();
            Name = json.SelectToken("name")?.ToString();
        }
    }
}
