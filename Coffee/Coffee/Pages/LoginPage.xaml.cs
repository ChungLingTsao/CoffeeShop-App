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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            //var _customer = (Customer)BindingContext;
            Console.WriteLine(LoginUserNameEntry.Text + " " + LoginPasswordEntry.Text);
            var customer = await App.Database.CheckCredentials(LoginUserNameEntry.Text, LoginPasswordEntry.Text);
            if (customer != null)
            {
                Console.WriteLine(customer.UserName, customer.ID);
                await Navigation.PushAsync(new HomePage
                {
                    BindingContext = customer as Customer
                });
            }
            else
            {
                Console.WriteLine("Invalid Username or Password");
                await DisplayAlert("Error", "Invalid Username or Password", "OK");
            }
        }

        async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Register");
            await Navigation.PushAsync(new RegisterPage
            {
                BindingContext = new Customer()
            });
        }
    }
}