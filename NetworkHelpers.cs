using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ADHDone.NetworkHelpers
{
    public static class NetworkHelpers
    {
        public static bool PingHost(string nameOrAddress)
        {
            try
            {
                using (Ping pinger = new Ping())
                {
                    PingReply reply = pinger.Send(nameOrAddress);
                    return reply.Status == IPStatus.Success;
                }
            }
            catch (PingException ex)
            {
                return false;
            }
        }

        public static bool CheckIfSiteIsReachable(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.AllowAutoRedirect = false; // find out if this site is up and don't follow a redirector
            request.Method = "HEAD";
            try
            {
                var response = request.GetResponse();
                return true;
            }
            catch (WebException wex)
            {
                //set flag if there was a timeout or some other issues
                return false;
            }
        }
    }
}
