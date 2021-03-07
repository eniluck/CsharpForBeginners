using Shop_homework15.Interfaces;
using Shop_homework15.Models;
using System;

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
