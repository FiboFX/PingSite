using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace PingSite.Core.Tools
{
    public static class PingTool
    {
        public static bool CheckPingStatus(string hostAddress)
        {
            Ping ping = new Ping();
            try
            {
                PingReply reply = ping.Send(hostAddress);
                return reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                return false;
            }
        }
    }
}
