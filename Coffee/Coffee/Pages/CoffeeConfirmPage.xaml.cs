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
	public partial class CoffeeConfirmPage : ContentPage
	{
		public CoffeeConfirmPage ()
		{
			InitializeComponent ();
		}

        async void ReturnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}