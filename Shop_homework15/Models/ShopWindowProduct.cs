using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_homework15.Models
{
    /// <summary>
    /// Товар на витрине
    /// </summary>
    public class ShopWindowProduct
    {
        //Идентификатор(порядковый номер, чтобы однозначно идентифицировать товар на витрине)
        public Guid ID { get; set; }

        //Идентификатор витрины(порядковый номер, чтобы однозначно идентифицировать витрину)
        public Guid ShopWindowID { get; set; }

        //Идентификатор товара(порядковый номер, чтобы однозначно идентифицировать товар)
        public Guid ProductID { get; set; }

        //Кол-во товара - в целом можно и сразу считать объем, если посчитаешь это удобным
        public int ProductQuantity { get; set; }

        // и сразу считать объем
        public int OverallVolume { get; set; }

        // Стоимость товара ( за еденицу товара )
        public decimal ProductCost { get; set; }
    }
}
