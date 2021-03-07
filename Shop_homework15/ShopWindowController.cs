using Shop_homework15.Interfaces;
using Shop_homework15.Models;
using System;
using System.Collections.Generic;

namespace Shop_homework15
{
    public class ShopWindowController : IShopWindowController
    {
        //все продукты на витринах
        private List<ShopWindowProduct> _shopWindowProducts;

        //список витрин
        private List<ShopWindow> _shopWindows;

        //список продуктов
        private List<Product> _products;

        public ShopWindowController()
        {
            _shopWindowProducts = new List<ShopWindowProduct>();
            _shopWindows = new List<ShopWindow>();
            _products = new List<Product>();
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
            int occupiedQuantity = GetOccupiedQuantity(shopWindow.ID);

            //2. сумма из п.1  и productQuantity не должна превышать shopWindow.Capacity
            //Вопрос: здесь надо выбрасывать exception и в последствии эту ошибку обработать ( как в методе CreateShopWindow ) ? 
            //или просто пометить что проверка не прошла и вернуть false
            if (occupiedQuantity + productQuantity > shopWindow.Capacity)
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

        /*Занятое место в витрине*/
        private int GetOccupiedQuantity(Guid shopWindowID)
        {
            int totalShopWindowQuantity = 0;
            foreach (var shopWindowProduct in _shopWindowProducts)
            {
                if (shopWindowProduct.ShopWindowID == shopWindowID)
                    totalShopWindowQuantity += shopWindowProduct.ProductQuantity;
            }

            return totalShopWindowQuantity;
        }

        public List<ShopWindow> GetShopWindows()
        {
            return _shopWindows;
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

            //TODO: ещё можно добавить проверку на наличие витрины в списке, только это пока ненужно

            if (isValid == false)
                throw new Exception("Ошибка создания витрины.");

            var newShopWindow = new ShopWindow()
            {
                ID = Guid.NewGuid(),
                Name = name,
                Capacity = capacity,
                CreateDate = DateTime.Now
            };

            _shopWindows.Add(newShopWindow);

            return newShopWindow;
        }

        /*
         Удалить витрину. Если товары расположены на витрине, то программа не позволять это сделать и сообщать ошибку.
        */
        public bool DeleteShopWindow(ShopWindow shopWindow)
        {
            //Если найден товар на витрине то не разрешать удалять
            foreach (var shopWindowProduct in _shopWindowProducts)
            {
                if (shopWindowProduct.ShopWindowID == shopWindow.ID)
                    return false;
            }

            //удалить из списка витрин 
            //TODO: или пометить удалённым?
            _shopWindows.Remove(shopWindow);

            return true;
        }

        public ShopWindow GetShopWindowByName(string shopWindowName)
        {
            ShopWindow findedShopWindow = null;
            foreach (var shopWindow in _shopWindows)
            {
                if (shopWindow.Name == shopWindowName)
                {
                    findedShopWindow = shopWindow;
                    break;
                }
            }

            return findedShopWindow;
        }

        /*
         Отредактировать витрину. 
         При смене объема, если товары уже расположены на витрине
         и их суммарный объем больше нового значения объема витрины, 
         программа не позволять это сделать и сообщать ошибку.
        */
        public bool EditShopWindow(Guid id, string name, int capacity)
        {
            bool isValid = true;
            // Проверка на не пустую строку name
            if (string.IsNullOrWhiteSpace(name))
                isValid = false;

            // Проверка на capacity > 0
            isValid = isValid && capacity > 0;

            // Проверка суммарного объема витрины
            int occupiedQuantity = GetOccupiedQuantity(id);
            isValid = isValid && occupiedQuantity < capacity;

            if (isValid == false)
                return false;

            //найти витрину и отредактировать её имя и объем
            foreach (var shopWindow in _shopWindows)
            {
                if ( shopWindow.ID == id )
                {
                    shopWindow.Name = name;
                    shopWindow.Capacity = capacity;
                    //Только первая найденная витрина
                    break; 
                }
            }

            return true;
        }
    }
}
