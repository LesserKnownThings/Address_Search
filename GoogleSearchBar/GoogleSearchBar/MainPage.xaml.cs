using GoogleSearchBar.Scripts.GoogleAPIActions;
using GoogleSearchBar.Scripts.Misc;
using System;
using System.Linq;
using Xamarin.Forms;

namespace GoogleSearchBar
{
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// Google API key needed for the search
        /// https://developers.google.com/places/web-service/get-api-key
        /// </summary>
        public const string GOOGLE_API_KEY = "Your API key";
        /// <summary>
        /// Session token used by google for billing
        /// https://developers.google.com/places/web-service/session-tokens
        /// </summary>
        public string token = string.Empty;

        public MainPage()
        {
            InitializeComponent();

            from_searchbar.TextChanged += FromSB_TextChanged;
            result_list.ItemSelected += Results_ItemSelected;
        }

        /// <summary>
        /// This function displays the address when you click on an item in the address list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Results_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            StructuredFormating results = (StructuredFormating)e.SelectedItem;

            if(results != null)
            {

                await DisplayAlert("Info", $"The address you selected is: {results.MainText}, {results.SecondaryText}", "Okay");

                from_searchbar.Text = string.Empty;
                result_list.IsVisible = false;

            }
        }

        /// <summary>
        /// This function looks for an address every time you enter a character and the length of the string is bigger than 2
        /// Not that if you're not using a session token you will be charged by google for each character you enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void FromSB_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (string.IsNullOrEmpty(e.NewTextValue))
                return;

            //It's usually better to run the search after you have at least 2 characters
            if(e.NewTextValue.Count() >= 2)
            {
                activity.IsVisible = true;
                activity.IsRunning = true;
                result_list.IsVisible = false;

                /*WITH REQUIRED PARAMETERS*/
                /*
                GoogleCallParameters parameters = new GoogleCallParameters
                    (
                    e.NewTextValue,
                    GOOGLE_API_KEY
                    );
                */
                /***********************************************************/


                /*WITH ADDITIONAL PARAMETERS*/
                
                //A token needs to be set for each searching session
                if(string.IsNullOrEmpty(token))
                token = Guid.NewGuid().ToString();

                var components = "country:ca|country:us";
                string language = "en";

                GoogleCallParameters parameters = new GoogleCallParameters
                    (
                    e.NewTextValue,
                    GOOGLE_API_KEY,
                    token,
                    language,
                    components
                    );
                
                /*************************************************************/


                var result = await AutocompleteSearch.GetAddressLis(parameters);

                result_list.ItemsSource = result.FormatedAddress;

                activity.IsRunning = false;
                activity.IsVisible = false;
                result_list.IsVisible = true;

            }else if (e.NewTextValue.Count() == 0)
            {
                activity.IsVisible = false;
                result_list.IsVisible = false;
            }

        }


    }
}
