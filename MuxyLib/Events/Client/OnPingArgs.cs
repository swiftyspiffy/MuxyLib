using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuxyLib.Events.Client
{
    public class OnPingArgs : EventArgs
    {
        public string UUID { get; internal set; }
    }
}
