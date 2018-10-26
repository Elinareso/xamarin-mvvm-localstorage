using DemoApp.Core.Entity;
using DemoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Core.Services
{
    class MockDataStore : IDataStore<Item>
    {
        private readonly List<Item> _items;
        private readonly static Lazy<MockDataStore> instance = new Lazy<MockDataStore>(() => new MockDataStore());
        
        private MockDataStore()
        {
            _items = new List<Item>();

            for (int i = 0; i < 5; i++)
            {
                _items.Add(new Item
                {
                    Id = i.ToString(),
                    Text = $"{i}-Text",
                    Description = $"{i}-Description"
                });
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            _items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            var item = _items.Where(I => I.Id.Equals(id)).FirstOrDefault();

            return await Task.FromResult(item);
        }

        public async Task<IEnumerable<Item>> GetItemsASync()
        {
            return await Task.FromResult(_items);
        }

        public static MockDataStore Instance => instance.Value;
    }
}
