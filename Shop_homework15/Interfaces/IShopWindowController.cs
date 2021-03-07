using Shop_homework15.Models;
using System;

namespace Shop_homework15.Interfaces
{
    interface IShopWindowController
    {
        ShopWindow CreateShopWindow(string name, int capacity);
        bool EditShopWindow(Guid id, string name, int capacity);
        bool DeleteShopWindow(ShopWindow shopWindow);
        bool AddProduct(ShopWindow shopWindow, Product product, decimal cost, int productQuantity);
    }
}
