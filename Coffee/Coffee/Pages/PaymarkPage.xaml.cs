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
    public partial class PaymarkPage : ContentPage
    {
        string amount = "dasd";
        string bank = "dasd";

        public PaymarkPage(string bankSelected, string topupAmount)
        {
            InitializeComponent();
            bank = bankSelected;
            amount = topupAmount;
        }

        protected override void OnAppearing()
        {
            SimulatingTransfer();
            base.OnAppearing();
        }

        async void ReturnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        void SimulatingTransfer()
        {
            DisplayAlert("Processing...", "Simulating the money transfer of " + amount + " from " + bank + " to your account.", "OK");
        }
    }
}