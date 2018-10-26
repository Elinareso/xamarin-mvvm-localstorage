using DemoApp.Core.Entity;
using DemoApp.Models;
using DemoApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemoApp.ViewModels
{
    public class ItemListViewModel : ViewModelBase
    {
        private INavigation _navigation;
        private readonly ItemsModel _itemsModel;

        public ItemListViewModel() : this(null) { }

        public ItemListViewModel(INavigation navigation)
        {
            Title = "Item List";

            _navigation = navigation;
            _itemsModel = new ItemsModel();

            _itemsModel.PropertyChanged += (object sender, PropertyChangedEventArgs propertyArgs) =>
             {
                 OnPropertyChanged(propertyArgs.PropertyName);
             };

            AddItemCommand = new Command<Type>(ExecuteAddItemCommand);
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            LoadItemsCommand.Execute(null);

            MessagingCenter.Subscribe<Item>(this, "NewItemAdded", (item) =>
            {
                IsBusy = true;
                Task.Run(async () =>
                {
                    Thread.Sleep(1000);
                    await _itemsModel.LoadAllItemsAsync();

                    IsBusy = false;
                });
            });
        }

        private async void ExecuteAddItemCommand(Type pageType)
        {
            var instancePage = (Page)Activator.CreateInstance(pageType);
            await _navigation?.PushModalAsync(instancePage);
        }

        private async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy) return;

            IsBusy = true;

            try
            {
                await _itemsModel.LoadAllItemsAsync();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Command AddItemCommand { get; }

        public Command LoadItemsCommand { get; }

        public ObservableCollection<Item> Items => _itemsModel.Items;

    }
}
