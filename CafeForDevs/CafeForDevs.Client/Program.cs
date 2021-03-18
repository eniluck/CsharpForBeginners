using System;
using System.Net.Http;

namespace CafeForDevs.Client
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var httpClient = new HttpClient();
            var baseCafeUri = new Uri("http://localhost:65465");
            var cafeHttpClient = new CafeHttpClient(httpClient, baseCafeUri);

            var application = new ClientApplication(cafeHttpClient);
            application.Start();
        }
    }
}
