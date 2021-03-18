using Shop_homework15.Models;
using System;
using System.Collections.Generic;

namespace Shop_homework15.Interfaces
{
    public interface IShopWindowController
    {
        List<ShopWindow> GetShopWindows();
        ShopWindow GetShopWindowByID(Guid guid);
        ShopWindow GetShopWindowByName(string shopWindowName);
        List<ShopWindowProduct> GetShopWindowProducts(Guid ShopWindowID);
        ShopWindow CreateShopWindow(string name, int capacity);
        bool EditShopWindow(Guid guid, string name, int capacity);
        bool DeleteShopWindow(Guid guid);
        bool AddProduct(Guid shopWindowGuid, Guid productGuid, decimal cost, int productQuantity);
        bool RemoveProduct(Guid shopWindowGuid, Guid productGuid);
    }
}
