using Shop_homework15.Interfaces;

namespace Shop_homework15
{
    class Program
    {
        static void Main(string[] args)
        {
            IProductController productController = new InMemoryProductController();
            IShopWindowController shopWindowController = new InMemoryShopWindowController(productController);
            Application application = new Application(shopWindowController, productController);
            application.Start();
        }
    }
}
