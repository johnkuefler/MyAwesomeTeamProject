using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Plugin.SimpleAudioPlayer;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyAwesomeProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePlayPage : ContentPage
    {
        private string player1SettingName = "Player1Name";
        private string player2SettingName = "Player2Name";

        public GamePlayPage()
        {
            InitializeComponent();

            currentPlayerLabel.Text = Preferences.Get(player1SettingName, "");

            diceRollLabel.Text = "Roll dice to start";

            currentRoundLabel.Text = Preferences.Get("CurrentRound", 1).ToString();

            player1ScoreLabel.Text = Preferences.Get("Player1Score", 0).ToString();
            player2ScoreLabel.Text = Preferences.Get("Player2Score", 0).ToString();

            player1Label.Text = Preferences.Get(player1SettingName, "");
            player2Label.Text = Preferences.Get(player2SettingName, "");
        }

        private Random rand = new Random();

        private void Button_OnClicked(object sender, EventArgs e)
        {
            int diceRoll = rand.Next(1, 6);

            diceRollLabel.Text = diceRoll.ToString();

            string currentPlayer = Preferences.Get("CurrentPlayerTurn","Player1");

            if (currentPlayer == "Player1")
            {
                int player1Score = Preferences.Get("Player1Score", 0);
                player1Score += diceRoll;

                Preferences.Set("Player1Score", player1Score);
                player1ScoreLabel.Text = player1Score.ToString();

                Preferences.Set("CurrentPlayerTurn","Player2");

                currentPlayerLabel.Text = Preferences.Get(player2SettingName, "");

            }
            else
            {
                int player2Score = Preferences.Get("Player2Score", 0);
                player2Score += diceRoll;

                Preferences.Set("Player2Score", player2Score);
                player2ScoreLabel.Text = player2Score.ToString();

                Preferences.Set("CurrentPlayerTurn", "Player1");

                currentPlayerLabel.Text = Preferences.Get(player1SettingName, "");
            }

            int currentRound = Preferences.Get("CurrentRound", 1);

            currentRound++;

            Preferences.Set("CurrentRound", currentRound);

            currentRoundLabel.Text = currentRound.ToString();

            if (currentRound > 6)
            {
                int player1Score = Preferences.Get("Player1Score", 0);
                int player2Score = Preferences.Get("Player2Score", 0);

                if (player1Score > player2Score)
                {
                    resultLabel.Text = Preferences.Get(player1SettingName, "") + " wins";
                } 
                else if (player2Score > player1Score)
                {
                    resultLabel.Text = Preferences.Get(player2SettingName, "") + " wins";
                }
                else
                {
                    resultLabel.Text = "It was a tie!";
                }

                diceRollButton.IsVisible = false;

                // https://github.com/adrianstevens/Xamarin-Plugins/tree/master/SimpleAudioPlayer

                ISimpleAudioPlayer player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
                player.Load(GetStreamFromFile("tada.wav"));
                player.Play();
            }
            else
            {
                ISimpleAudioPlayer player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
                player.Load(GetStreamFromFile("dice.wav"));
                player.Play();
            }
        }


        Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("MyAwesomeProject." + filename);
            return stream;
        }
    }
}