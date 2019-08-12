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
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage()
        {
            InitializeComponent();
        }

        async void OnBalanceButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Balance");
            await Navigation.PushAsync(new BalancePage
            {
                BindingContext = this.BindingContext
            });
        }

        async void OnTransactionsButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Transactions");
            await Navigation.PushAsync(new TransactionPage
            {
                BindingContext = this.BindingContext
            });
        }
    }
}