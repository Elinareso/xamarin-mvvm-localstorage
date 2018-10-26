using DemoApp.Core.Entity;
using DemoApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace DemoApp.ViewModels
{
    public class ItemDetailsViewModel : ViewModelBase
    {
        private Item _item;

        public ItemDetailsViewModel()
        {
            Title = "Item Details";

            MessagingCenter.Subscribe<Item>(this, "Item", (item) =>
            {
                Item = item;
            });
        }

        public Item Item
        {
            get => _item;
            set => SetValue(ref _item, value);
        }
    }
}
