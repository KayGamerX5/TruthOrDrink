using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TruthOrDrink.DataAccess;
using TruthOrDrink.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruthOrDrink
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePage : ContentPage
    {
        DAL dal = new DAL();
        int players;
        List<Player> Players = new List<Player>();

        

        int currentPlayer = 0;
        public GamePage()
        {
            InitializeComponent();
            
        }

        public GamePage(int players)
        {
            this.players = players;
            InitializeComponent();
            Players = dal.GetPlayers();
            CurrentPlayerLabel.Text = "This turn: " + Players[currentPlayer].Name;

            QuestionLabel.Text = dal.RandomQuestion().QuestionBody;
            QuestionLabel.FontSize = 24;
        }

        private void ExitButton_Clicked(object sender, EventArgs e)
        {
            int PlayerCount = dal.CountPlayers();
            dal.SetUserInactive(Players[0].Name);
            dal.SetUserInactive(Players[1].Name);
            if(PlayerCount >= 3)
            {
                dal.SetUserInactive(Players[2].Name);
            }
            if(PlayerCount == 4)
            {
                dal.SetUserInactive(Players[3].Name);
            }

            Navigation.PushAsync(new HomePage());
        }

        private void TruthButton_Clicked(object sender, EventArgs e)
        {
            int PlayerCount = dal.CountPlayers();

            if (currentPlayer < PlayerCount)
            {
                dal.TruthPicked(currentPlayer);

                currentPlayer++;
                int checkInt = currentPlayer;
                if (checkInt == PlayerCount)
                {
                    CurrentPlayerLabel.Text = "This turn: " + Players[0].Name;
                }
                else
                {
                    CurrentPlayerLabel.Text = "This turn: " + Players[currentPlayer].Name;
                }
            }


            else
            {
                currentPlayer = 0;
                CurrentPlayerLabel.Text = "This turn: " + Players[currentPlayer].Name;

                dal.TruthPicked(currentPlayer);
                currentPlayer++;
            }

            QuestionLabel.Text = dal.RandomQuestion().QuestionBody;

        }

        private void DrinkButton_Clicked(object sender, EventArgs e)
        {
            int PlayerCount = dal.CountPlayers();
            if (currentPlayer < PlayerCount)
            {
                dal.DrinkPicked(currentPlayer);

                currentPlayer++;
                int checkInt = currentPlayer;
                if (checkInt == PlayerCount)
                {
                    CurrentPlayerLabel.Text = "This turn: " + Players[0].Name;
                }
                else
                {
                    CurrentPlayerLabel.Text = "This turn: " + Players[currentPlayer].Name;
                }
            }


            else
            {
                currentPlayer = 0;
                CurrentPlayerLabel.Text = "This turn: " + Players[currentPlayer].Name;
                dal.DrinkPicked(currentPlayer);

                currentPlayer++;
            }

            QuestionLabel.Text = dal.RandomQuestion().QuestionBody;

        }

        private void EndGameButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ScoreboardPage());
        }
    }
    
}