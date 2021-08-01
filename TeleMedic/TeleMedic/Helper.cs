using DeviceId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleMedic
{
    public class Helper
    {
        public static string GetDeviceId()
        {
            string deviceId = new DeviceIdBuilder()
.AddMachineName()
.AddMacAddress()
.AddProcessorId()
.AddMotherboardSerialNumber()
.ToString();
            return deviceId;
        }
    }
}
