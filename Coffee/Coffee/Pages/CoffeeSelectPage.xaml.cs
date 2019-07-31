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
        public CoffeeSelectPage()
        {
            InitializeComponent();
        }

        private void AddCoffee(object sender, EventArgs e)
        {
            
            DisplayAlert("Coffee Added", "Don't forget to click Place Order when done", "OK");
            //await Navigation.PushAsync(new RetailList());
        }
        private void ButtonTest(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var text = button.Text;
            testLabel.Text = text;
            DisplayAlert("asdf", "Don't forget to click Place Order when done", "OK");
            //await Navigation.PushAsync(new RetailList());
        }
    }

}