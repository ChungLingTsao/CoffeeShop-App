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
	public partial class CoffeeConfirmPage : ContentPage
	{
        public static string coffeeListText = "";
        public CoffeeConfirmPage (List<CoffeeData> _coffeeList, Customer customer)
		{
			InitializeComponent ();
            coffeeListText = "";
            foreach (var coffee in _coffeeList)
            {
                coffeeListText += String.Format("{0} {1}{2}", coffee.CoffeeName, coffee.Size, Environment.NewLine);
            }
            Console.WriteLine(coffeeListText);
            DisplayCoffee.Text = coffeeListText;

            if (customer.SpecialEnabled)
            {
                DisplaySpecial.IsVisible = true;
                customer.SpecialEnabled = false;
            }
            else
            {
                DisplaySpecial.IsVisible = false;
            }
        }

        async void ReturnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}