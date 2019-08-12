using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Coffee.Models;

namespace Coffee.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var customer = (Customer)BindingContext;
            BalanceText.Text = String.Format("${0}", customer.Balance);
        }

        async void OnOrderCoffeeButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Order Coffee");
            await Navigation.PushAsync(new CoffeeSelectPage
            {
                BindingContext = this.BindingContext
            });
        }

        async void OnTopUpButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Top Up");
            await Navigation.PushAsync(new BankPage
            {
                BindingContext = this.BindingContext
            });
        }

        async void OnAccountDetailsButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Account Details");
            await Navigation.PushAsync(new DetailsPage
            {
                BindingContext = this.BindingContext
            });
        }
    }
}