using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruthOrDrink.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruthOrDrink
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePage : ContentPage
    {
        private int players;
        string PlayerOneName = string.Empty;
        string PlayerTwoName = string.Empty;
        string PlayerThreeName = string.Empty;
        string PlayerFourName = string.Empty;

        int currentPlayer = 1;
        public GamePage()
        {
            InitializeComponent();
        }

        public GamePage(int players)
        {
            this.players = players;
            InitializeComponent();
            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<Player>();
                PlayerOneName = connection.Table<Player>().ElementAt(0).Name;
                PlayerTwoName = connection.Table<Player>().ElementAt(1).Name;
                if (players >= 3)
                {
                    PlayerThreeName = connection.Table<Player>().ElementAt(2).Name;
                }
                if (players == 4)
                {
                    PlayerFourName = connection.Table<Player>().ElementAt(3).Name;
                }
            }
            CurrentPlayerLabel.Text = "This turn: " + PlayerOneName;

            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<Question>();
                Random rnd = new Random();
                var questions = connection.Table<Question>().ToList();
                int index = rnd.Next(questions.Count);
                QuestionLabel.Text = questions.ElementAt(index).QuestionBody;
                QuestionLabel.FontSize = 24;
            }
        }

        private void ExitButton_Clicked(object sender, EventArgs e)
        {
            using(SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<Player>();
                connection.DeleteAll<Player>();
            }

            Navigation.PushAsync(new HomePage());
        }

        private void TruthButton_Clicked(object sender, EventArgs e)
        {
            
            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<Player>();
                var players = connection.Table<Player>().ToList();
                
                int PlayerCount = players.Count;
                if(currentPlayer < PlayerCount) 
                {
                    CurrentPlayerLabel.Text = "This turn: " + connection.Table<Player>().ElementAt(currentPlayer).Name;
                    var player = connection.Table<Player>().ElementAtOrDefault(currentPlayer);
                    player.Name = player.Name;
                    player.Score = player.Score + 1;
                    player.TimesDrink = player.TimesDrink;
                    connection.Update(player);

                    currentPlayer++;
                }
                
                else 
                { 
                    currentPlayer = 0;
                    CurrentPlayerLabel.Text = "This turn: " + connection.Table<Player>().ElementAt(currentPlayer).Name;
                    var player = connection.Table<Player>().ElementAtOrDefault(currentPlayer);
                    player.Name = player.Name;
                    player.Score = player.Score + 1;
                    player.TimesDrink = player.TimesDrink;
                    connection.Update(player);

                    currentPlayer++;
                }
            }
            
        }

        private void DrinkButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<Player>();
                var players = connection.Table<Player>().ToList();

                int PlayerCount = players.Count;
                if (currentPlayer < PlayerCount)
                {
                    CurrentPlayerLabel.Text = "This turn: " + connection.Table<Player>().ElementAt(currentPlayer).Name;
                    var player = connection.Table<Player>().ElementAtOrDefault(currentPlayer);
                    player.Name = player.Name;
                    player.Score = player.Score;
                    player.TimesDrink = player.TimesDrink + 1;
                    connection.Update(player);

                    currentPlayer++;
                }

                else
                {
                    currentPlayer = 0;
                    CurrentPlayerLabel.Text = "This turn: " + connection.Table<Player>().ElementAt(currentPlayer).Name;
                    var player = connection.Table<Player>().ElementAtOrDefault(currentPlayer);
                    player.Name = player.Name;
                    player.Score = player.Score;
                    player.TimesDrink = player.TimesDrink + 1;
                    connection.Update(player);

                    currentPlayer++;
                }
            }

        }
    }
    
}