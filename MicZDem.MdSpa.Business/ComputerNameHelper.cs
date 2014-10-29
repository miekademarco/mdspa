using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MicZDem.MdSpa.Business
{
    public class ComputerNameHelper
    {

        public static string DetermineComputerName(string ip)
        {
            IPAddress myIP = IPAddress.Parse(ip);
            IPHostEntry GetIPHost = Dns.GetHostEntry(myIP);
            List<string> compName = GetIPHost.HostName.Split('.').ToList();
            return compName.First();
        }
    }
}
