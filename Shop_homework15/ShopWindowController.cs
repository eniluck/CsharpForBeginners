using Shop_homework15.Interfaces;
using Shop_homework15.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_homework15
{
    class ShopWindowController : IShopWindowController
    {
        //все витрины и продукты
        List<ShopWindowProduct> _shopWindowProducts;

        public ShopWindowController()
        {
            _shopWindowProducts = new List<ShopWindowProduct>();
        }

        /*
         В каждую созданную витрину можно добавить товар. 
         При этом если товар не помещается, программа не позволять это сделать и сообщит ошибку
        */
        public bool AddProduct(ShopWindow shopWindow, Product product, decimal cost, int productQuantity)
        {
            //TODO: Проверка. Помещается ли товар

            ShopWindowProduct shopWindowProduct = new ShopWindowProduct()
            {
                ID = Guid.NewGuid(),
                ProductID = product.ID,
                ShopWindowID = shopWindow.ID,
                ProductCost = cost,
                ProductQuantity = productQuantity
            };

            _shopWindowProducts.Add(shopWindowProduct);

            return true;
        }

        public ShopWindowController CreateShopWindow(string name, int capacity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteShopWindow(ShopWindowController shopWindow)
        {
            throw new NotImplementedException();
        }

        public bool DeleteShopWindow(ShopWindow shopWindow)
        {
            throw new NotImplementedException();
        }

        public ShopWindowController EditShopWindow(int id, string name, int capacity)
        {
            throw new NotImplementedException();
        }
    }
}
