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


                PlayerOneNameLabel.Text = connection.Table<Player>().ElementAt(0).Name;
                PlayerTwoNameLabel.Text = connection.Table<Player>().ElementAt(1).Name;
                if (players >= 3)
                {
                    PlayerThreeNameLabel.Text = connection.Table<Player>().ElementAt(2).Name;
                    PlayerThreeNameLabel.IsVisible = true;
                }
                if (players == 4)
                {
                    PlayerFourNameLabel.Text = connection.Table<Player>().ElementAt(3).Name;
                    PlayerFourNameLabel.IsVisible = true;
                }
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
    }
}