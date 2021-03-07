using Shop_homework15.Interfaces;

namespace Shop_homework15
{
    class Program
    {
        static void Main(string[] args)
        {
            IShopWindowController shopWindowController = new ShopWindowController();
            Application application = new Application(shopWindowController);
            application.Start();
        }
    }
}
