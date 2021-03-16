using System;
using System.Net.Http;

namespace CafeForDevs.Client
{
    public class CafeHttpClient : ICafeHttpClient
    {
        private readonly HttpClient _client;

        public CafeHttpClient(HttpClient client, Uri baseUri)
        {
            _client = client;
            _client.BaseAddress = baseUri;
        }

        public void GetMenu()
        {
            var response = _client.GetAsync("http://localhost:32560");
        }

        public void SelectMenuItem()
        {
            var response = _client.PostAsync("http://localhost:32560");
        }

        public void GetOrder()
        {
            var response = _client.GetAsync("http://localhost:32560");
        }
    }
}
