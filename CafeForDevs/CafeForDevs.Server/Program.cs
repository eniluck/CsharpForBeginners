using System;
using System.Net;

namespace CafeForDevs.Server
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var httpListener = new HttpListener();
            httpListener.Prefixes.Add("http://localhost:65465");

            var application = new ServerApplication(httpListener);
            application.Start();
        }
    }
}
