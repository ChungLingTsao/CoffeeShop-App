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
    public partial class DoughnutSelectPage : ContentPage
    {
        //   // FOR TESTING
//        public static List<DoughnutData> doughnutList;
        public static string doughnutListText;

        public static Order neworder;
        public static Boolean canOrder = true;  

        public DoughnutSelectPage()
        {
            InitializeComponent();
            neworder = new Order();
//            doughnutList = new List<DoughnutData>();
          doughnutListText = "Order List:";
            Console.WriteLine("new page test");
        }

        private void AddDoughnutCoffee(object sender, EventArgs e)
        {
            DisplayAlert("Doughnut Added", "Don't forget to click Place Order when done", "OK");
            
        }

        private void ButtonPlainAdd(object sender, EventArgs e)
        {
            var type = "Plain";
            int cost = 5;
            if (canPurchase(cost)) DoughnutAdd(type, cost);
        }

        private void ButtonChocolateAdd(object sender, EventArgs e)
        {

            var type = "Chocolate";
            int cost = 6;
            if (canPurchase(cost)) DoughnutAdd(type, cost);
        }

        private void ButtonStrawberryAdd(object sender, EventArgs e)
        {
            var type = "Strawberry";
            int cost = 7;
            if (canPurchase(cost)) DoughnutAdd(type, cost);
        }

       


        public Boolean canPurchase(int cost)
        {
            var customer = (Customer)BindingContext;
            if (customer.Balance < cost)
            {
                DisplayAlert("Error", "You need to add funds to you balance", "OK");
                return false;
            }
            customer.Balance -= cost;
            return true;       
        }

        private async void DoughnutAdd(string type, int cost)
        {
            canOrder = true;
            //await App.Database.SaveOrder(neworder);
            //var newcoffee = new CoffeeData
            //{
            //    OrderID = neworder.ID,
            //    CoffeeName = type,
            //    Size = size,
            //    Cost = cost
            //};
            //doughnutList.Add(newDoughnut);
            var text = type + " doughnut added to your order";

            doughnutListText += String.Format("{1}{0}", type, Environment.NewLine);
            OrderList.Text = doughnutListText;

            await DisplayAlert(text, "Place Order when done adding items", "OK");
        }

        private void checkSpecials(Customer customer)
        {
            if(customer.SpecialCount >= 10)
            {
                customer.SpecialEnabled = true;
                customer.SpecialCount -= 10;
            }
            else
            {
                customer.SpecialEnabled = false;
            }
        }

        private async void ButtonPlaceOrder(object sender, EventArgs e)
        {


           // await Navigation.PushAsync(new DoughnutConfirmPage( customer));

            //if (canOrder)
            //{
            //    canOrder = false;
            //    foreach (var doughnut in doughnutList)
            //    {
            //        neworder.TotalCost += doughnut.Cost;
            //        await App.Database.SaveDoughnut(doughnut);
            //    }
            //    var customer = (Customer)BindingContext;
            //    customer.SpecialCount += doughnutList.Count;
            //    checkSpecials(customer);
            //    neworder.CustomerID = customer.ID;
            //    neworder.orderTime = DateTime.Now;
            //    await App.Database.SaveCustomer(customer);
            //    await App.Database.SaveOrder(neworder);
            //    await Navigation.PushAsync(new DoughnutConfirmPage(doughnutList, customer));
            //}
            //else
            //{
            //    await DisplayAlert("Error", "Please add a doughnut to your order", "OK");
            //}

        }
    }

}