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
    public partial class StartGamePage : ContentPage
    {
        public int players = 2;

        public StartGamePage()
        {
            InitializeComponent();
        }

        private void AddPlayer3Button_Clicked(object sender, EventArgs e)
        {
            AddPlayer4Button.IsVisible = true;
            AddPlayer3Button.IsVisible = false;

            PlayerThreeNameEntry.IsVisible = true;

        }

        private void AddPlayer4Button_Clicked(object sender, EventArgs e)
        {
            AddPlayer4Button.IsVisible = false;

            PlayerFourNameEntry.IsVisible = true;
        }

        private void StartGameButton_Clicked(object sender, EventArgs e)
        {

            

            bool Player1IsEmpty = string.IsNullOrEmpty(PlayerOneNameEntry.Text);
            bool Player2IsEmpty = string.IsNullOrEmpty(PlayerTwoNameEntry.Text);

            if(Player1IsEmpty || Player2IsEmpty)
            {
                DisplayAlert("Alert!", "You need to enter at least player 1 and player 2 to play", "Exit");
            }

            else
            {
                Player player1 = new Player();
                Player player2 = new Player();

                player1.Name = PlayerOneNameEntry.Text;
                player1.Score = 0;
                player1.TimesDrink = 0;

                player2.Name = PlayerTwoNameEntry.Text;
                player2.Score = 0;
                player2.TimesDrink = 0;

                using(SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
                {
                    connection.CreateTable<Player>();
                    int insert1 = connection.Insert(player1);
                    int insert2 = connection.Insert(player2);

                    int insertedrows = insert1 + insert2;

                    if(insertedrows < 2)
                    {
                        DisplayAlert("Oops!", "Something went wrong, try again", "Exit");
                    }
                }
                if (PlayerThreeNameEntry.Text != null)
                {
                    players++;
                    Player player3 = new Player();
                    player3.Name = PlayerThreeNameEntry.Text;
                    player3.Score = 0;
                    player3.TimesDrink = 0;

                    using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
                    {
                        connection.CreateTable<Player>();
                        int insert1 = connection.Insert(player3);

                        if (insert1 < 1)
                        {
                            DisplayAlert("Oops!", "Something went wrong, try again", "Exit");
                        }
                    }
                }

                if (PlayerFourNameEntry.Text != null)
                {
                    players++;
                    Player player4 = new Player();
                    player4.Name = PlayerFourNameEntry.Text;
                    player4.Score = 0;
                    player4.TimesDrink = 0;

                    using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
                    {
                        connection.CreateTable<Player>();
                        int insert1 = connection.Insert(player4);

                        if (insert1 < 1)
                        {
                            DisplayAlert("Oops!", "Something went wrong, try again", "Exit");
                        }
                    }
                }

                Navigation.PushAsync(new GamePage(players));
            }
        }
    }
}