using CafeForDevs.Models;
using CafeForDevs.Server.Application;
using System.Linq;
using System.Net;

namespace CafeForDevs.Server.Handlers
{
    public class OrderHandler : Handler, IHandler
    {
        private Order _order;

        public OrderHandler()
        {
            _order = new Order();
        }

        public string Path => "/order";

        public void Handle(HttpListenerContext context)
        {
            switch (context.Request.HttpMethod)
            {
                case "POST":
                    var request = GetRequestBody<MenuItemRequestModel>(context);
                    SelectMenuItem(request.MenuItemId, request.Quantity);
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    break;

                case "GET":
                    var order = GetOrder();
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    SetResponse(order, context);
                    break;
            }

            context.Response.Close();
        }

        internal void SelectMenuItem(int menuItemId, int quantity)
        {
            var menuItem = Menu.Get(menuItemId);
            _order.AddPositions(menuItem, quantity);
        }

        private Order GetOrder()
        {
            var order = new OrderModel();

            order.Positions = _order.GetPostions()
                .Select(x => new OrderPositionModel
                {
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity
                })
                .ToArray();

            return _order;
        }
    }
}
