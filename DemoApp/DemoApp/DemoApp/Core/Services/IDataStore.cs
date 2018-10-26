using DemoApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Core.Services
{
    interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsASync();
    }
}
