using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruthOrDrink.DataAccess;
using TruthOrDrink.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruthOrDrink
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScoreboardPage : ContentPage
    {
        DAL dal = new DAL();
        List<Player> Players = new List<Player>();
        public ScoreboardPage()
        {
            InitializeComponent();

            Players = dal.GetPlayers();

            int playerCount = dal.CountPlayers();

            PlayerOneNameLabel.Text = Players[0].Name;
            PlayerOneTruthsLabel.Text = "Truths told: " + Players[0].Score.ToString();
            PlayerOneDrinksLabel.Text = "Drinks taken: " + Players[0].TimesDrink.ToString();

            PlayerTwoNameLabel.Text = Players[1].Name;
            PlayerTwoTruthsLabel.Text = "Truths told: " + Players[1].Score.ToString();
            PlayerTwoDrinksLabel.Text = "Drinks taken: " + Players[1].TimesDrink.ToString();

            if(playerCount >= 3)
            {
                PlayerThreeNameLabel.Text = Players[2].Name;
                PlayerThreeTruthsLabel.Text = "Truths told: " + Players[2].Score.ToString();
                PlayerThreeDrinksLabel.Text = "Drinks taken: " + Players[2].TimesDrink.ToString();
            }

            if(playerCount == 4)
            {
                PlayerFourNameLabel.Text = Players[3].Name;
                PlayerFourTruthsLabel.Text = "Truths told: " + Players[3].Score.ToString();
                PlayerFourDrinksLabel.Text = "Drinks taken: " + Players[3].TimesDrink.ToString();
            }
        }

        private void ExitButton_Clicked(object sender, EventArgs e)
        {
            int playerCount = dal.CountPlayers();
            dal.SetUserInactive(Players[0].Name);
            dal.SetUserInactive(Players[1].Name);
            if (playerCount >= 3)
            {
                dal.SetUserInactive(Players[2].Name);
            }
            if (playerCount == 4)
            {
                dal.SetUserInactive(Players[3].Name);
            }
            Navigation.PushAsync(new HomePage());
        }
    }
}