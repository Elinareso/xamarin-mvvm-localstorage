using DemoApp.Core.Entity;
using DemoApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemoApp.ViewModels
{
    public class NewItemViewModel : ViewModelBase
    {
        private INavigation _navigation;
        private Item _item;
        private readonly ItemsModel _itemsModel;

        public Item Item
        {
            get => _item;
            set => SetValue(ref _item, value);
        }

        public NewItemViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _itemsModel = new ItemsModel();

            SaveCommand = new Command(async () => await SaveItem());

            Item = new Item
            {
                Text = "New Item",
                Description = "New Item Description"
            };
        }

        private async Task SaveItem()
        {
            await _itemsModel.AddNewItemAsync(Item);
            MessagingCenter.Send(Item, "NewItemAdded");
            await _navigation.PopModalAsync();
        }

        public Command SaveCommand { get; }
    }
}
