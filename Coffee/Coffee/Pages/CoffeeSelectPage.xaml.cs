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
    public partial class CoffeeSelectPage : ContentPage
    {

        public static string[] order = new string[8];
        public static List<CoffeeData> coffeeList = new List<CoffeeData>();
        public static Order neworder;

        public CoffeeSelectPage()
        {
            InitializeComponent();
            neworder = new Order();
        }

        private void AddCoffee(object sender, EventArgs e)
        {
            
            DisplayAlert("Coffee Added", "Don't forget to click Place Order when done", "OK");
            //await Navigation.PushAsync(new RetailList());
        }



        private void ButtonEspressoAdd(object sender, EventArgs e)
        {
            var type = "Espresso";
            var button = (Button)sender;
            var size = button.Text;
            int cost = 5;
            size = GetNiceSize(size);
            CoffeeAdd(type, size, cost);
        }


        private void ButtonLongBlackAdd(object sender, EventArgs e)
        {
            var type = "Long Black";
            var button = (Button)sender;
            var size = button.Text;
            int cost = 6;
            size = GetNiceSize(size);
            CoffeeAdd(type, size, cost);
        }


        private void ButtonCappuccinoAdd(object sender, EventArgs e)
        {
            var type = "Cappuccino";
            var button = (Button)sender;
            var size = button.Text;
            int cost = 7;
            size = GetNiceSize(size);
            CoffeeAdd(type, size, cost);
        }


        private void ButtonLatteAdd(object sender, EventArgs e)
        {
            var type = "Latte";
            var button = (Button)sender;
            var size = button.Text;
            int cost = 5;
            size = GetNiceSize(size);
            CoffeeAdd(type, size, cost);
        }


        private void ButtonFlatWhiteAdd(object sender, EventArgs e)
        {
            var type = "Flat White";
            var button = (Button)sender;
            var size = button.Text;
            int cost = 4;
            size = GetNiceSize(size);
            CoffeeAdd(type, size, cost);
        }

        private string GetNiceSize(string s)
        {
            var size = "";

            if (s == "S")
            {
                size = "Small ";
            }
            else if (s == "M")
            {
                size = "Medium ";
            }
            else if (s == "L")
            {
                size = "Large ";
            }
            return size;
        }


        private async void CoffeeAdd(string type, string size, int cost)
        {
            await App.Database.SaveOrder(neworder);
            var newcoffee = new CoffeeData
            {
                OrderID = neworder.ID,
                CoffeeName = type,
                Size = size,
                Cost = cost
            };
            coffeeList.Add(newcoffee);
            var text = size + type + " added to your order";
            await DisplayAlert(text, "Place Order when done adding items", "OK");

            //await Navigation.PushAsync(new RetailList());
        }

        private async void ButtonPlaceOrder(object sender, EventArgs e)
        {      
            foreach (var coffee in coffeeList)
            {
                neworder.TotalCost += coffee.Cost;
                await App.Database.SaveCoffee(coffee);
            }
            var customer = (Customer)BindingContext;
            neworder.CustomerID = customer.ID;
            neworder.orderTime = DateTime.Now;
            await App.Database.SaveOrder(neworder);
            await Navigation.PushAsync(new CoffeeConfirmPage());
            //await Navigation.PushAsync(new RetailList());
        }
    }

}