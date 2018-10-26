using DemoApp.Core;
using DemoApp.Core.Entity;
using DemoApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemoApp.Models
{
    class ItemsModel : ObservableObject
    {
        private ObservableCollection<Item> _items;

        private IDataStore<Item> _dataStore => DependencyService.Get<IDataStore<Item>>() ?? MockDataStore.Instance;

        public ItemsModel()
        {
            Items = new ObservableCollection<Item>();
        }

        public async Task LoadAllItemsAsync()
        {
            Items = new ObservableCollection<Item>(await _dataStore.GetItemsASync());
        }

        public async Task<bool> AddNewItemAsync(Item item)
        {
            return await _dataStore.AddItemAsync(item);
        }

        public ObservableCollection<Item> Items
        {
            get => _items;
            set => SetValue(ref _items, value);
        }

    }
}
