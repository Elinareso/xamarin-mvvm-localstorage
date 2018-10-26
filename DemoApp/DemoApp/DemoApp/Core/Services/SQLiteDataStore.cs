using DemoApp.Core.Entity;
using DemoApp.Core.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

// Commented out this line to use the MockDataStore
[assembly: Dependency(typeof(SQLiteDataStore))]
namespace DemoApp.Core.Services
{
    class SQLiteDataStore : IDataStore<Item>
    {
        private readonly LocalDatabaseConnection _localDatabaseConnection;

        public SQLiteDataStore()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DemoAppDatabase.db3");
            _localDatabaseConnection = new LocalDatabaseConnection(dbPath);
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            await _localDatabaseConnection.Database.InsertAsync(item);

            return await Task.FromResult(true);
        }

        public Task<Item> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Item>> GetItemsASync()
        {
            var items = _localDatabaseConnection.Database.Table<Item>().ToListAsync();

            return await Task.FromResult(items.Result);
        }
    }
}
