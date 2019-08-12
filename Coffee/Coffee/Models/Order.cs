using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Coffee.Models;

namespace Coffee.Models
{
    public class Order
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int TotalCost { get; set; }
        public DateTime orderTime { get; set; }

    }
}
