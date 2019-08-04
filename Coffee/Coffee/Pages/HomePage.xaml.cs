using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Coffee.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        async void OnOrderCoffeeButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Order Coffee");
            await Navigation.PushAsync(new CoffeeSelectPage());
        }

        async void OnTopUpButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Top Up");
            //await Navigation.PushAsync(new OrderCoffeePage());
        }

        async void OnAccountDetailsButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Account Details");
            //await Navigation.PushAsync(new OrderCoffeePage());
        }
    }
}