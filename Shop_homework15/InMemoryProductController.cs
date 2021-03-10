using Shop_homework15.Interfaces;
using Shop_homework15.Models;
using System;
using System.Collections.Generic;

namespace Shop_homework15
{
    class InMemoryProductController : IProductController
    {
        private List<Product> _products;

        public InMemoryProductController()
        {
            _products = new List<Product>();
        }

        /// <summary>
        /// Создать продукт.
        /// </summary>
        /// <param name="name">Имя нового продукта.</param>
        /// <param name="size">Размер нового продукта.</param>
        /// <returns>Созданный продукт.</returns>
        public Product CreateProduct(string name, int size)
        {
            bool isValid = true;

            if (String.IsNullOrEmpty(name) == true)
                isValid = false;

            if (size <= 0)
                isValid = false;

            //TODO: Правильно ли возвращать null ?
            if (isValid == false)
                return null;

            Product newProduct = new Product()
            {
                ID = Guid.NewGuid(),
                Name = name,
                Size = size
            };

            _products.Add(newProduct);

            return newProduct;
        }

        /// <summary>
        /// Найти продукт по названию.
        /// </summary>
        /// <param name="name">Имя продукта.</param>
        /// <returns>Найденный продукт или null.</returns>
        public Product FindProductByName(string name)
        {
            foreach (var product in _products)
            {
                if (product.Name == name)
                    return product;
            }

            return null;
        }

        /// <summary>
        /// Найти продукт по ID
        /// </summary>
        /// <param name="guid">ID продукта.</param>
        /// <returns>Найденный продукт или null.</returns>
        public Product GetProductByID(Guid guid)
        {
            foreach (var product in _products)
            {
                if (product.ID == guid)
                    return product;
            }

            return null;
        }

        /// <summary>
        /// Удалить продукт по ID.
        /// </summary>
        /// <param name="guid">ID продукта.</param>
        /// <returns>Результат удаления (удачно/неудачно).</returns>
        public bool DeleteProduct(Guid guid)
        {
            Product productToDelete = GetProductByID(guid);

            if (productToDelete == null)
                return false;

            _products.Remove(productToDelete);

            return true;
        }

        /// <summary>
        /// Редактировать продукт.
        /// </summary>
        /// <param name="guid">ID продукта.</param>
        /// <param name="name">Новое имя продукта.</param>
        /// <param name="size">Новый размер продукта.</param>
        /// <returns>Результат редатирования (удачно/неудачно).</returns>
        public bool EditProduct(Guid guid, string name, int size)
        {
            Product productToChange = GetProductByID(guid);

            if (productToChange == null)
                return false;

            productToChange.Name = name;
            productToChange.Size = size;

            return true;
        }

        /// <summary>
        /// Получить список созданных продуктов.
        /// </summary>
        /// <returns>Список продуктов.</returns>
        public List<Product> GetProducts()
        {
            return _products;
        }
    }
}
