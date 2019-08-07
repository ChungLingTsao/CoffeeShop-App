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
            _database.CreateTableAsync<Order>().Wait();
            _database.CreateTableAsync<CoffeeData>().Wait();
        }

        public Task<List<Customer>> DeleteAllData()
        {
            _database.QueryAsync<CoffeeData>("DELETE FROM CoffeeData");
            _database.QueryAsync<Order>("DELETE FROM Order");
            return _database.QueryAsync<Customer>("DELETE FROM Customer");          
        }

        public Task<List<Order>> GetOrderList(Customer customer)
        {
            return _database.Table<Order>()
                            .Where(i => i.CustomerID == customer.ID)
                            .ToListAsync();
        }
        public Task<List<CoffeeData>> GetCoffeeList(Order order)
        {
            return _database.Table<CoffeeData>()
                            //.Where(i => i.OrderID == order.ID)
                            .ToListAsync();
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

        public Task<int> SaveOrder(Order order)
        {
            if (order.ID != 0)
            {
                return _database.UpdateAsync(order);
            }
            else
            {
                return _database.InsertAsync(order);
            }
        }

        public Task<Order> GetOrder(int id)
        {
            return _database.Table<Order>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveCoffee(CoffeeData coffee)
        {
            if (coffee.ID != 0)
            {
                return _database.UpdateAsync(coffee);
            }
            else
            {
                return _database.InsertAsync(coffee);
            }
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
