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
        public PaymarkPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            DisplayAlert("Bank Transfer", "This page only simulates the money transfer", "OK");
            base.OnAppearing();
        }

        private void ReturnButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BankPage());
        }
    }
}