using System;
using System.Collections.Generic;
using System.Text;
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
            _database.GetConnection().Close();

        }
    }
}
