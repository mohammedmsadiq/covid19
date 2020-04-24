using System;
using System.Collections.Generic;
using System.Linq;
using covid19.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace covid19.Views
{
    public partial class ByCountryPage : ContentPage
    {
        public ByCountryPage()
        {
            InitializeComponent();
            On<iOS>().SetUseSafeArea(true);

        }

        void searchBar_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            var vm = BindingContext as ByCountryPageViewModel;

            searchResults.BeginRefresh();

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                searchResults.ItemsSource = vm.Data;
            else
                searchResults.ItemsSource = vm.Data.Where(i => i.country.ToLower().Contains(e.NewTextValue.ToLower()));

            searchResults.EndRefresh();
        }
    }
}
