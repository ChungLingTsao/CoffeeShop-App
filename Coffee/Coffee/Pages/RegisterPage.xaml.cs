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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Sign Up");
            var customer = (Customer)BindingContext;
            Console.WriteLine(customer.UserName);
            var checkCustomer = await App.Database.UserNameExists(customer.UserName);
            if (checkCustomer != null)
            {
                await DisplayAlert("Error", "Username already exists", "OK");
            }
            else
            {
                await DisplayAlert("Complete", "User has been created", "OK");
                await App.Database.SaveCustomer(customer);
                await Navigation.PopAsync();
            }          
        }
    }
}