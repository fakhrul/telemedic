using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleMedic.Library
{
    public class JoinRequestEventArgs : EventArgs
    {
        public string MeetingId { get; set; }
    }
}
