using DemoApp.Core.Entity;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp.Core.Services
{
    class LocalDatabaseConnection
    {
        public LocalDatabaseConnection(string dbPath)
        {
            Database = new SQLiteAsyncConnection(dbPath);
            Database.CreateTableAsync<Item>().Wait();
        }

        public SQLiteAsyncConnection Database { get; }
    }
}
