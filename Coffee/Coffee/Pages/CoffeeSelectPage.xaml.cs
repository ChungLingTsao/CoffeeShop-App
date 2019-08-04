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
    public partial class CoffeeSelectPage : ContentPage
    {

        public static string[] order = new string[8];



        public CoffeeSelectPage()
        {
            InitializeComponent();
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
            size = GetNiceSize(size);
            CoffeeAdd(type, size);
        }


        private void ButtonLongBlackAdd(object sender, EventArgs e)
        {
            var type = "Long Black";
            var button = (Button)sender;
            var size = button.Text;
            size = GetNiceSize(size);
            CoffeeAdd(type, size);
        }


        private void ButtonCappuccinoAdd(object sender, EventArgs e)
        {
            var type = "Cappuccino";
            var button = (Button)sender;
            var size = button.Text;
            size = GetNiceSize(size);
            CoffeeAdd(type, size);
        }


        private void ButtonLatteAdd(object sender, EventArgs e)
        {
            var type = "Latte";
            var button = (Button)sender;
            var size = button.Text;
            size = GetNiceSize(size);
            CoffeeAdd(type, size);
        }


        private void ButtonFlatWhiteAdd(object sender, EventArgs e)
        {
            var type = "Flat White";
            var button = (Button)sender;
            var size = button.Text;
            size = GetNiceSize(size);
            CoffeeAdd(type, size);
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


        private void CoffeeAdd(string type, string size)
        {
            var text = size + type + " added to your order";

            DisplayAlert(text, "Place Order when done adding items", "OK");
            //await Navigation.PushAsync(new RetailList());
        }




        private async void ButtonPlaceOrder(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CoffeeConfirmPage());
            //await Navigation.PushAsync(new RetailList());
        }
    }

}