using DemoApp.Core.Entity;
using DemoApp.Models;
using DemoApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemoApp.Views
{
    public partial class ItemListPage : ContentPage
    {
        public ItemListPage()
        {
            InitializeComponent();

            BindingContext = new ItemListViewModel(this.Navigation);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (!(args.SelectedItem is Item item))
                return;

            await Navigation.PushAsync(new ItemDetailsPage());

            MessagingCenter.Send(item, "Item");

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }
    }
}
