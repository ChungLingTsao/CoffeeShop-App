using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Coffee.Models;
using SQLite;

namespace Coffee.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BankPage : ContentPage
    {
        
        string bankSelected;
        string pickerSelected;
        double topupAmount = 0.00f;
        Boolean topupSelected = false;

        //public Customer temp;
        //float balance = 5.00f;

        public BankPage()
        {
            InitializeComponent();
            ResetBankButtonsOpacity();
            picker.SelectedIndexChanged += this.PickerSelectedIndexChanged;
        }

        void ANZButtonClicked(object sender, EventArgs e)
        {
            ResetBankButtonsOpacity();
            SetSelectedBank("ANZ", ANZ);
        }
        void ASBButtonClicked(object sender, EventArgs e)
        {
            ResetBankButtonsOpacity();
            SetSelectedBank("ASB", ASB);
        }

        void BNZButtonClicked(object sender, EventArgs e)
        {
            ResetBankButtonsOpacity();
            SetSelectedBank("BNZ", BNZ);
        }

        void KiwibankButtonClicked(object sender, EventArgs e)
        {
            ResetBankButtonsOpacity();
            SetSelectedBank("Kiwibank", Kiwibank);
        }

        async void PaymarkButtonClicked(object sender, EventArgs e)
        {
            if (bankSelected == null)
            {
                await DisplayAlert("Warning", "Please select a bank provider!", "OK");
            }

            else if (topupSelected == false)
            {
                await DisplayAlert("Warning", "Please select a top-up amount!", "OK");
            }
        
            else
            {
                await Navigation.PushAsync(new PaymarkPage(bankSelected, pickerSelected));
            }
        }

        void ResetBankButtonsOpacity()
        {
            ANZ.Opacity = 0.25;
            ASB.Opacity = 0.25;
            BNZ.Opacity = 0.25;
            Kiwibank.Opacity = 0.25;
        }

        void SetSelectedBank(String stringBank, ImageButton currentBank)
        {
            if (bankSelected == stringBank)
            {
                bankSelected = null;
            }
            else
            {
                bankSelected = stringBank;
                currentBank.Opacity = 1;
            }
        }

        void PickerSelectedIndexChanged(object sender, EventArgs e)
        {
            //Method call every time when picker selection changed.
            pickerSelected = picker.SelectedItem.ToString(); // Retrieves selected item of picker
            topupAmount = Convert.ToDouble(pickerSelected.Remove(0, 1)); // Converts the selected picker item to a float by removing the '$' sign
            topupSelected = true;
        }
    }
}