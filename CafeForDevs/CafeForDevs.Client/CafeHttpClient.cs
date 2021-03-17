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

        public Menu GetMenu()
        {
            var response = _client.GetAsync("http://localhost:32560");

            // Формируем меню из ответа сервера

            return new Menu();
        }

        public void SelectMenuItem(int menuItemId)
        {
            var content = menuItemId;

            var response = _client.PostAsync("http://localhost:32560", content);
        }

        public void GetOrder()
        {
            var response = _client.GetAsync("http://localhost:32560");
        }
    }
}
