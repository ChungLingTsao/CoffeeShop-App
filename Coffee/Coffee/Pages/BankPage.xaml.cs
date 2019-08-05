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
    public partial class BankPage : ContentPage
    {
        string bankSelected;
        

        public BankPage()
        {
            InitializeComponent();

            List<int> amounts = new List<int>();
            amounts.Add(5);
            amounts.Add(10);
            amounts.Add(20);
            amounts.Add(50);
        }

        void tapImage_Tapped(object sender, EventArgs e)
        {
            // handle the tap    
            DisplayAlert("Alert", "This is an image button", "OK");
        }

        void ANZButtonClicked(object sender, EventArgs e)
        {
            bankSelected = "ANZ";
            label.Text = $"{bankSelected} selected";

        }
        void ASBButtonClicked(object sender, EventArgs e)
        {
            bankSelected = "ASB";
            label.Text = $"{bankSelected} selected";
        }

        void BNZButtonClicked(object sender, EventArgs e)
        {
            bankSelected = "BNZ";
            label.Text = $"{bankSelected} selected";
        }
        void KiwibankButtonClicked(object sender, EventArgs e)
        {
            bankSelected = "Kiwibank";
            label.Text = $"{bankSelected} selected";
        }
        void PaymarkButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PaymarkPage());
        }
    }
}