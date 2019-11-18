using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyAwesomeProject
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            myPicker.ItemsSource = new List<string> {"Item1", "Item2", "Item3"};
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            string selectedItem = myPicker.SelectedItem as string;

            Preferences.Set("SelectedItem", selectedItem);

            bool switchIsToggled = mySwitch.IsToggled;

            DisplayAlert("Hi", selectedItem + " " + switchIsToggled, "OK");
        }

        private void Button_OnClicked2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PreferencesPage());
        }

        private void Button_OnClicked3(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SearchPage());
        }

        private void Button_OnClicked4(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GameStartPage());
        }
    }
}
