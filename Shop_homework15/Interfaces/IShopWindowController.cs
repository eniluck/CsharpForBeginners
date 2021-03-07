using Shop_homework15.Models;
using System;
using System.Collections.Generic;

namespace Shop_homework15.Interfaces
{
    public interface IShopWindowController
    {
        ShopWindow CreateShopWindow(string name, int capacity);
        bool EditShopWindow(Guid id, string name, int capacity);
        bool DeleteShopWindow(ShopWindow shopWindow);
        bool AddProduct(ShopWindow shopWindow, Product product, decimal cost, int productQuantity);

        List<ShopWindow> GetShopWindows();
        ShopWindow GetShopWindowByName(string shopWindowName);
    }
}
