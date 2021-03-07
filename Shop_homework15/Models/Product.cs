using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_homework15.Models
{
    /// <summary>
    /// Товар:
    /// </summary>
    public class Product
    {
        //Идентификатор (порядковый номер, чтобы однозначно идентифицировать товар)
        public int ID { get; set; }

        //Название
        public string Name { get; set; }

        //Занимаемый объем
        public int Size{ get; set; }
    }
}
