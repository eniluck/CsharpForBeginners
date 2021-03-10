using Shop_homework15.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_homework15.Interfaces
{
    interface IProductController
    {
        List<Product> GetProducts();
        Product CreateProduct(string name, int size);
        bool EditProduct(Guid guid, string name, int size);
        bool DeleteProduct(Guid guid);
    }
}
