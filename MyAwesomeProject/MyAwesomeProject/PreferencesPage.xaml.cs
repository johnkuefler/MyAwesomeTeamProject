using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyAwesomeProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreferencesPage : ContentPage
    {
        public PreferencesPage()
        {
            InitializeComponent();

            preferencesLabel.Text = Preferences.Get("SelectedItem","");
        }
    }
}