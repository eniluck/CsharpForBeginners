using CafeForDevs.Models;
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
            var response = _client.GetAsync("menu");

            // Формируем меню из ответа сервера

            return new Menu();
        }

        public void SelectMenuItem(int menuItemId)
        {
            var content = menuItemId;

            var response = _client.PostAsync("order", content);
        }

        public Order GetOrder()
        {
            var response = _client.GetAsync("order");

            // Формируем меню из ответа сервера

            return new Order();
        }
    }
}
