using Shop_homework15.Models;

namespace Shop_homework15.Interfaces
{
    interface IShopWindowController
    {
        ShopWindow CreateShopWindow(string name, int capacity);
        ShopWindow EditShopWindow(int id, string name, int capacity);
        bool DeleteShopWindow(ShopWindow shopWindow);
        bool AddProduct(ShopWindow shopWindow, Product product, decimal cost, int productQuantity);
    }
}
