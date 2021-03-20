using System.Collections.Generic;

namespace CafeForDevs.Server.Application
{
    internal class Order
    {
        private List<OrderPosition> _positions;

        internal void AddPositions(MenuItem menuItem, int quantity)
        {
            var position = new OrderPosition
            {
                Name = menuItem.Name,
                Price = menuItem.Price,
                Quantity = quantity
            };

            _positions.Add(position);
        }

        internal OrderPosition[] GetPostions()
        {
            return _positions.ToArray();
        }
    }
}
