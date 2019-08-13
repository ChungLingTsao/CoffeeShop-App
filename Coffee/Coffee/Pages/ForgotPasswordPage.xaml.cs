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
    public partial class ForgotPasswordPage : ContentPage
    {
        public ForgotPasswordPage()
        {
            InitializeComponent();
        }

        async void OnResetPasswordButtonClicked(object sender, EventArgs e)
        {
            var customer = await App.Database.ChangePasswordFromEmail(EmailEntry.Text);
            if (customer == null)
            {
                await DisplayAlert("Error", "Email does not exist", "OK");
            }
            else
            {
                if(PasswordEntry.Text != "")
                {
                    customer.Password = PasswordEntry.Text;
                    await DisplayAlert("Complete", "Password has been changed", "OK");
                    await App.Database.SaveCustomer(customer);
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "Please enter a password", "OK");
                }
                
            }

        }
    }
}