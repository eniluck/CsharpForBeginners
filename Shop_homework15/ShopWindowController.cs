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
            //Вопрос: здесь надо выбрасывать exception и в последствии эту ошибку обработать ( как в методе CreateShopWindow ) ? 
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

        /*
         Создать новую витрину с названием и объемом. Объем - сколько товаров может поместиться, у каждого товара свой объем.
         */
        public ShopWindow CreateShopWindow(string name, int capacity)
        {
            bool isValid = true;
            //Проверка на не пустую строку name
            if (string.IsNullOrWhiteSpace(name))
                isValid = false;

            //Проверка на capacity > 0
            isValid = isValid && capacity > 0;

            if (isValid == false)
                throw new Exception("Ошибка создания витрины.");

            return new ShopWindow()
            {
                ID = Guid.NewGuid(),
                Name = name,
                Capacity = capacity,
                CreateDate = DateTime.Now
            };
        }

        public bool DeleteShopWindow(ShopWindowController shopWindow)
        {
            throw new NotImplementedException();
        }

        public bool DeleteShopWindow(ShopWindow shopWindow)
        {
            throw new NotImplementedException();
        }

        public ShopWindow EditShopWindow(int id, string name, int capacity)
        {
            throw new NotImplementedException();
        }
    }
}
