﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_homework15.Models
{
    /// <summary>
    /// Витрина:
    /// </summary>
    public class ShopWindow
    {
        // Идентификатор (порядковый номер, чтобы однозначно идентифицировать витрину)
        public int ID { get; set; }

        // Название 
        public string Name { get; set; }

        // Объем
        public int Capacity { get; set; }

        // Дата создания
        public DateTime CreateDate { get; set; }

        // Дата удаления
        public DateTime DeleteDate { get; set; }
    }
}
