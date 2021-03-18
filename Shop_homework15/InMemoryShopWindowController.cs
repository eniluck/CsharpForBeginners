using Shop_homework15.Interfaces;
using Shop_homework15.Models;
using System;
using System.Collections.Generic;

namespace Shop_homework15
{
    public class InMemoryShopWindowController : IShopWindowController
    {
        private List<ShopWindowProduct> _shopWindowProducts;
        private List<ShopWindow> _shopWindows;
        private readonly IProductController _productController;

        public InMemoryShopWindowController(IProductController productController)
        {
            _shopWindowProducts = new List<ShopWindowProduct>();
            _shopWindows = new List<ShopWindow>();
            _productController = productController;
        }

        /// <summary>
        /// Получить список созданных витрин.
        /// </summary>
        /// <returns>Список витрин.</returns>
        public List<ShopWindow> GetShopWindows()
        {
            return _shopWindows;
        }

        /// <summary>
        /// Получить витрину по имени.
        /// </summary>
        /// <param name="shopWindowName">Имя витрины.</param>
        /// <returns>Найденная витрина или null</returns>
        public ShopWindow GetShopWindowByName(string shopWindowName)
        {
            foreach (var shopWindow in _shopWindows)
            {
                if (shopWindow.Name == shopWindowName)
                {
                    return shopWindow;
                }
            }

            return null;
        }

        /// <summary>
        /// Получить список продуктов на витрине.
        /// </summary>
        /// <param name="ShopWindowID">ID витрины.</param>
        /// <returns>Список продуктов на витрине.</returns>
        public List<ShopWindowProduct> GetShopWindowProducts(Guid ShopWindowID)
        {
            List<ShopWindowProduct> shopWindowProductsFiltered = new List<ShopWindowProduct>();
            foreach (var shopWindowProduct in _shopWindowProducts)
            {
                if (shopWindowProduct.ShopWindowID == ShopWindowID)
                    shopWindowProductsFiltered.Add(shopWindowProduct);
            }

            return shopWindowProductsFiltered;
        }

        /// <summary>
        /// Получить витрину по ID.
        /// </summary>
        /// <param name="guid">ID витрины.</param>
        /// <returns>Найденная витрина или null</returns>
        public ShopWindow GetShopWindowByID(Guid guid)
        {
            foreach (var shopWindow in _shopWindows)
            {
                if (shopWindow.ID == guid)
                {
                    return shopWindow;
                }
            }

            return null;
        }

        /// <summary>
        /// Создать новую витрину.
        /// </summary>
        /// <param name="name">Имя новой витрины.</param>
        /// <param name="capacity">Объем новой витрины.</param>
        /// <returns>Созданная витрина или null.</returns>
        public ShopWindow CreateShopWindow(string name, int capacity)
        {
            bool isValid = isValidShopWindowParameters(name, capacity);

            //Проверка на наличие витрины. Если такого имени не существует.
            isValid = isValid && GetShopWindowByName(name) == null;

            if (isValid == false)
                return null;

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

        /// <summary>
        /// Проверка параметров для витрины.
        /// </summary>
        /// <param name="name">Имя витрины.</param>
        /// <param name="capacity">Объем витрины.</param>
        /// <returns>Результат проверки (правильные/неправильные).</returns>
        private bool isValidShopWindowParameters(string name, int capacity)
        {
            bool isValid = true;
            // Проверка на не пустую строку name
            if (string.IsNullOrWhiteSpace(name))
                isValid = false;

            // Проверка на capacity > 0
            isValid = isValid && capacity > 0;

            return isValid;
        }

        /// <summary>
        /// Редактировать витрину.
        /// </summary>
        /// <param name="Guid">ID витрины для редактирования.</param>
        /// <param name="name">Новое имя витрины.</param>
        /// <param name="capacity">Новый размер витрины.</param>
        /// <returns>Результат редатирования (удачно/неудачно).</returns>
        public bool EditShopWindow(Guid Guid, string name, int capacity)
        {
            bool isValid = isValidShopWindowParameters(name, capacity);

            // Проверка суммарного объема витрины
            int occupiedQuantity = GetShopWindowOccupiedQuantity(Guid);
            isValid = isValid && occupiedQuantity < capacity;

            if (isValid == false)
                return false;

            ShopWindow shopWindowToChange = GetShopWindowByID(Guid);

            if (shopWindowToChange == null)
                return false;

            shopWindowToChange.Name = name;
            shopWindowToChange.Capacity = capacity;

            return true;
        }

        /// <summary>
        /// Удалить витрину.
        /// </summary>
        /// <param name="guid">ID витрины.</param>
        /// <returns>Результат удаления (удачно/неудачно).</returns>
        public bool DeleteShopWindow(Guid guid)
        {
            ShopWindow shopWindowToDelete = GetShopWindowByID(guid);

            if (shopWindowToDelete == null)
                return false;

            _shopWindows.Remove(shopWindowToDelete);

            return true;
        }

        /// <summary>
        /// Добавить продукт на витрину.
        /// </summary>
        /// <param name="shopWindowGuid">ID витрины для размещения.</param>
        /// <param name="productGuid">ID продукта для добавления.</param>
        /// <param name="cost">Стоимость товара на витрине.</param>
        /// <param name="productQuantity">Количество товаров для размещения.</param>
        /// <returns>Результат добавления товара на витрину.</returns>
        public bool AddProduct(Guid shopWindowGuid, Guid productGuid, decimal cost, int productQuantity)
        {
            bool isValid = productQuantity > 0;

            isValid = isValid && cost > 0;

            if (isValid == false)
                return false;

            ShopWindow shopWindowToAccomodate = GetShopWindowByID(shopWindowGuid);
            if (shopWindowToAccomodate == null)
                return false;

            Product productToAdd = _productController.GetProductByID(productGuid);
            if (productToAdd == null)
                return false;

            int occupiedQuantity = GetShopWindowOccupiedQuantity(shopWindowGuid);

            if (occupiedQuantity + productQuantity > shopWindowToAccomodate.Capacity)
                return false;

            ShopWindowProduct newShopWindowProduct = new ShopWindowProduct()
            {
                ID = Guid.NewGuid(),
                ProductID = productToAdd.ID,
                ShopWindowID = shopWindowToAccomodate.ID,
                ProductCost = cost,
                ProductQuantity = productQuantity
            };

            _shopWindowProducts.Add(newShopWindowProduct);

            return true;
        }

        /// <summary>
        /// Найти размер занятого места на витрине.
        /// </summary>
        /// <param name="shopWindowID">ID витрины.</param>
        /// <returns>Размер занятого места.</returns>
        private int GetShopWindowOccupiedQuantity(Guid shopWindowID)
        {
            int totalShopWindowQuantity = 0;
            foreach (var shopWindowProduct in _shopWindowProducts)
            {
                if (shopWindowProduct.ShopWindowID == shopWindowID)
                    totalShopWindowQuantity += shopWindowProduct.ProductQuantity;
            }

            return totalShopWindowQuantity;
        }

        /// <summary>
        /// Убрать продукт с витрины.
        /// </summary>
        /// <param name="shopWindowGuid">ID Витрины.</param>
        /// <param name="productGuid">ID продукта.</param>
        /// <returns>Результат операции (убрбан/неубран).</returns>
        public bool RemoveProduct(Guid shopWindowGuid, Guid productGuid)
        {
            ShopWindowProduct shopWindowProductToRemove = null;

            foreach (var shopWindowProduct in _shopWindowProducts)
            {
                if (shopWindowProduct.ShopWindowID == shopWindowGuid
                    && shopWindowProduct.ProductID == productGuid)
                    shopWindowProductToRemove = shopWindowProduct;
            }

            if (shopWindowProductToRemove == null)
                return false;

            _shopWindowProducts.Remove(shopWindowProductToRemove);

            return true;
        }
    }
}
