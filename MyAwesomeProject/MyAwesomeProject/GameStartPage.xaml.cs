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
    public partial class GameStartPage : ContentPage
    {
        public GameStartPage()
        {
            InitializeComponent();
        }

        private void StartGameButton_OnClicked(object sender, EventArgs e)
        {
            Preferences.Set("Player1Name",player1NameEntry.Text);
            Preferences.Set("Player2Name", player2NameEntry.Text);

            Preferences.Set("Player1Score", 0);
            Preferences.Set("Player2Score", 0);

            Preferences.Set("CurrentPlayerTurn","Player1");

            Preferences.Set("CurrentRound",1);

            Navigation.PushAsync(new GamePlayPage());
        }
    }
}