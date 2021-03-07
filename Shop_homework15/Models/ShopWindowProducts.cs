using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_homework15.Models
{
    /// <summary>
    /// Товары на витрине:
    /// </summary>
    public class ShopWindowProducts
    {
        //Идентификатор(порядковый номер, чтобы однозначно идентифицировать товар на витрине)
        public int ID { get; set; }
        //Идентификатор витрины(порядковый номер, чтобы однозначно идентифицировать витрину)
        public int ShopWindowID { get; set; }
        //Идентификатор товара(порядковый номер, чтобы однозначно идентифицировать товар)
        public int ProductID { get; set; }
        //Кол-во товара - в целом можно и сразу считать объем, если посчитаешь это удобным
        public int ProductQuantity { get; set; }
        // и сразу считать объем
        public int OverallVolume { get; set; }
        // Стоимость товара
        public decimal MyProperty { get; set; }
    }
}
