using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Coffee.Models;

namespace Coffee.Data
{
    public class Database
    {
        SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Customer>().Wait();
            _database.CloseAsync();
            //adohfasokl
        }

        public void DeleteAllData()
        {
            _database.QueryAsync<Customer>("DELETE FROM Customer");
        }

        public Task<int> SaveCustomer(Customer customer)
        {
            if (customer.ID != 0)
            {
                return _database.UpdateAsync(customer);
            }
            else
            {
                return _database.InsertAsync(customer);
            }
        }

        public Task<Customer> GetCustomer(int id)
        {
            return _database.Table<Customer>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<Customer> CheckCredentials(string username, string password)
        {
            return _database.Table<Customer>()
                .Where(i => i.UserName == username && i.Password == password)
                .FirstOrDefaultAsync();
        }

        public Task<Customer> UserNameExists(string username)
        {
            return _database.Table<Customer>().Where(i => i.UserName == username).FirstOrDefaultAsync();
        }

    }
}
