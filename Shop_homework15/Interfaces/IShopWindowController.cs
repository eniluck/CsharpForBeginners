using Shop_homework15.Models;

namespace Shop_homework15.Interfaces
{
    interface IShopWindowController
    {
        ShopWindowController CreateShopWindow(string name, int capacity);
        ShopWindowController EditShopWindow(int id, string name, int capacity);
        bool DeleteShopWindow(ShopWindow shopWindow);
        bool AddProduct(ShopWindow shopWindow, Product product, decimal cost, int productQuantity);
    }
}
