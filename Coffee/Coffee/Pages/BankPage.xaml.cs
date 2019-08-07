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
        //SQLiteConnection conn = new SQLiteConnection("Database.db3");
        public Customer temp;

        string bankSelected;
        string pickerSelected;
        float balance = 5.00f;
        double topupAmount = 0.00f;
        Boolean topupSelected = false;

        public BankPage()
        {
            InitializeComponent();
            ResetBankButtonsOpacity();
            picker.SelectedIndexChanged += this.PickerSelectedIndexChanged;

            //List<int> amounts = new List<int>();
            //amounts.Add(5);
            //amounts.Add(10);
            //amounts.Add(20);
            //amounts.Add(50);
        }

        void ANZButtonClicked(object sender, EventArgs e)
        {
            ResetBankButtonsOpacity();
            SetSelectedBank("ANZ", ANZ);

            //ANZ.Opacity = 1;
            //bankSelected = "ANZ";

            //label.Text = $"{bankSelected} selected";

        }
        void ASBButtonClicked(object sender, EventArgs e)
        {
            ResetBankButtonsOpacity();
            SetSelectedBank("ASB", ASB);

          //  label.Text = $"{bankSelected} selected";
        }

        void BNZButtonClicked(object sender, EventArgs e)
        {
            ResetBankButtonsOpacity();
            SetSelectedBank("BNZ", BNZ);

          //  label.Text = $"{bankSelected} selected";
        }
        void KiwibankButtonClicked(object sender, EventArgs e)
        {
            ResetBankButtonsOpacity();
            SetSelectedBank("Kiwibank", Kiwibank);

         //   label.Text = $"{bankSelected} selected";
        }
        async void PaymarkButtonClicked(object sender, EventArgs e)
        {
            //MAKE SURE YOU FIX TOPUPAMOUNT SET
            
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
                //String pickerSelected = picker.SelectedItem.ToString(); // Retrieves selected item of picker
                //await DisplayAlert("TEST", topupAmount.ToString() + bankSelected + topupSelected.ToString(), "TEST");
                //topupAmount = Convert.ToDouble(pickerSelected.Remove(0, 1)); // Converts the selected picker item to a float by removing the '$' sign
                await Navigation.PushAsync(new PaymarkPage(bankSelected, pickerSelected));
               
            }
            //if (topupAmount == 0.00f && topupSelected == false)
            //{
            //    try
            //    {
            //        String pickerSelected = picker.SelectedItem.ToString();
            //        topupAmount = Convert.ToDouble(pickerSelected.Remove(0, 1)); // Converts the selected picker item to a float by removing the '$' sign
            //        topupSelected = true;

            //    }
            //    catch { DisplayAlert("Warning", "Please select a top-up amount!", "OK"); }
            //}

            //else
            //{
            //    Navigation.PushAsync(new PaymarkPage(bankSelected, topupAmount));
            //}
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
            pickerSelected = picker.SelectedItem.ToString();
            topupAmount = Convert.ToDouble(pickerSelected.Remove(0, 1)); // Converts the selected picker item to a float by removing the '$' sign
            topupSelected = true;
        }
    }
}