using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Coffee.Models
{
    public class Customer
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }

        // Create enum type Bank so that it is less prone to errors 
        public enum Bank { Bnz, Anz, Asb, Kiwibank};
        private Bank _bank;
        public Bank SelectedBank
        {
            get { return _bank; }
            set { _bank = value; }
        }

        public double Balance { get; set; }
    }
}
