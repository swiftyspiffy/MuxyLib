using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuxyLib.Events.Client
{
    public class OnClientErrorArgs : EventArgs
    {
        public string MuxyOverlayUrl { get; internal set; }
        public Exception Exception { get; internal set; }
    }
}
