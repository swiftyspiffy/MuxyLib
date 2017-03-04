using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuxyLib.Events.Client
{
    public class OnFollowArgs : EventArgs
    {
        public DateTime Date { get; internal set; }
        public string Message { get; internal set; }
        public string Channel { get; internal set; }
        public string UserMessage { get; internal set; }
        public Models.Client.Viewer Viewer { get; internal set; }
        public Models.Client.Follow.Extra Extra { get; internal set; }
    }
}
