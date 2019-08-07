using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Coffee.Models
{
    public class CoffeeData
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int OrderID { get; set; }
        public string CoffeeName { get; set; }
        public int Cost { get; set; }
        public string Size { get; set; }
        public bool SoyMilk { get; set; }
        public bool Sugar { get; set; }
    }
}
