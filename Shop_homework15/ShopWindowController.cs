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
         При этом если товар не помещается, программа не позволяет это сделать и сообщит ошибку
        */
        public bool AddProduct(ShopWindow shopWindow, Product product, decimal cost, int productQuantity)
        {
            // Проверка productQuantity > 0 
            bool isValid = productQuantity > 0;

            // Проверка стоимость товара cost > 0
            isValid = isValid && cost > 0;

            #region Проверка. Помещается ли товар на витрину
            //1. нужно найти общую сумму находящихся на витрине продуктов
            // ShopWindowProduct.ProductQuantity по shopWindow.ID
            int totalShopWindowQuantity = 0;
            foreach (var shopWindowProduct in _shopWindowProducts)
            {
                if (shopWindowProduct.ShopWindowID == shopWindow.ID)
                    totalShopWindowQuantity += shopWindowProduct.ProductQuantity;
            }

            //2. сумма из п.1  и productQuantity не должна превышать shopWindow.Capacity
            //Вопрос: здесь надо выбрасывать exception и в последствии эту ошибку обработать? 
            //или просто пометить что проверка не прошла и вернуть false
            if (totalShopWindowQuantity + productQuantity > shopWindow.Capacity)
                isValid = false;

            #endregion

            if (isValid == false)
                return false;


            ShopWindowProduct newShopWindowProduct = new ShopWindowProduct()
            {
                ID = Guid.NewGuid(),
                ProductID = product.ID,
                ShopWindowID = shopWindow.ID,
                ProductCost = cost,
                ProductQuantity = productQuantity
            };

            _shopWindowProducts.Add(newShopWindowProduct);

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
