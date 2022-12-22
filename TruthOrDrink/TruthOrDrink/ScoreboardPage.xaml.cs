using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruthOrDrink.DataAccess;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruthOrDrink
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScoreboardPage : ContentPage
    {
        DAL dal = new DAL();
        public ScoreboardPage()
        {
            InitializeComponent();

            int playerCount = dal.CountPlayers();

            var player1 = dal.GetPlayer(0);
            var player2 = dal.GetPlayer(1);

            PlayerOneNameLabel.Text = player1.Name;
            PlayerOneTruthsLabel.Text = "Truths told: " + player1.Score.ToString();
            PlayerOneDrinksLabel.Text = "Drinks taken: " + player1.TimesDrink.ToString();

            PlayerTwoNameLabel.Text = player2.Name;
            PlayerTwoTruthsLabel.Text = "Truths told: " + player2.Score.ToString();
            PlayerTwoDrinksLabel.Text = "Drinks taken: " + player2.TimesDrink.ToString();

            if(playerCount >= 3)
            {
                var player3 = dal.GetPlayer(2);

                PlayerThreeNameLabel.Text = player3.Name;
                PlayerThreeTruthsLabel.Text = "Truths told: " + player3.Score.ToString();
                PlayerThreeDrinksLabel.Text = "Drinks taken: " + player3.TimesDrink.ToString();
            }

            if(playerCount == 4)
            {
                var player4 = dal.GetPlayer(3);

                PlayerFourNameLabel.Text = player4.Name;
                PlayerFourTruthsLabel.Text = "Truths told: " + player4.Score.ToString();
                PlayerFourDrinksLabel.Text = "Drinks taken: " + player4.TimesDrink.ToString();
            }
        }

        private void ExitButton_Clicked(object sender, EventArgs e)
        {
            dal.EndGame();
            Navigation.PushAsync(new HomePage());
        }
    }
}