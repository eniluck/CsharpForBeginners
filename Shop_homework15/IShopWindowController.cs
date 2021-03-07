using Shop_homework15.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_homework15
{
    interface IShopWindowController
    {
        ShopWindowController CreateShopWindow(string name, int capacity);
        ShopWindowController EditShopWindow(int id, string name, int capacity);
        bool DeleteShopWindow(ShopWindow shopWindow);
        bool AddProduct(ShopWindow shopWindow, Product product, decimal cost, int productQuantity);
    }
}
