using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleMedic.Library
{
    public class UserExtra
    {
        public string UserName { get; set; }
        public string DeviceId { get; set; }
        public DeviceType DeviceType { get; set; }

        public override string ToString()
        {
            return string.Format("{0}@#|#@{1}@#|#@{2}", UserName, DeviceId, DeviceType);
        }
    }

    public enum DeviceType
    {
        Ambulance,
        AmbulanceCamera1,
        AmbulanceCamera2,
        Hospital
    }
}
