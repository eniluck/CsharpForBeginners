using System;

namespace CafeForDevs.Server
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var application = new ServerApplication();
            application.Start();
        }
    }
}
