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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Login");
            //await Navigation.PushAsync(new HomePage());
        }

        async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Register");
        }
    }
}