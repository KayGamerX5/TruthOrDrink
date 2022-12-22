using SQLite;
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
    public partial class GamePage : ContentPage
    {
        DAL dal = new DAL();
        int players;
        Player player1;
        Player player2;
        Player player3;
        Player player4;

        int currentPlayer = 0;
        public GamePage()
        {
            InitializeComponent();
        }

        public GamePage(int players)
        {
            this.players = players;
            InitializeComponent();

            CurrentPlayerLabel.Text = "This turn: " + dal.GetPlayer(currentPlayer).Name;

            QuestionLabel.Text = dal.RandomQuestion().QuestionBody;
            QuestionLabel.FontSize = 24;
        }

        private void ExitButton_Clicked(object sender, EventArgs e)
        {
            dal.EndGame();

            Navigation.PushAsync(new HomePage());
        }

        private void TruthButton_Clicked(object sender, EventArgs e)
        {
            
            int PlayerCount = dal.CountPlayers();
            int adjustedCount = PlayerCount - 1;
           
            if (currentPlayer < adjustedCount)
            {
                dal.TruthPicked(currentPlayer);

                currentPlayer++;
                CurrentPlayerLabel.Text = "This turn: " + dal.GetPlayer(currentPlayer).Name;
            }


            else
            {
                currentPlayer = 0;
                CurrentPlayerLabel.Text = "This turn: " + dal.GetPlayer(0).Name;

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
                CurrentPlayerLabel.Text = "This turn: " + dal.GetPlayer(currentPlayer).Name;
            }


            else
            {
                currentPlayer = 0;
                CurrentPlayerLabel.Text = "This turn: " + dal.GetPlayer(currentPlayer).Name;
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