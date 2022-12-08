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
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            User user = new User();

            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<User>();
                user = connection.Table<User>().FirstOrDefault();
            }

            UserNameLabel.Text = "Username: " + user.UserName;
            PasswordLabel.Text = "Password: " + user.Password;
            NameLabel.Text = "Real Name: " + user.Name;
            EmailLabel.Text = "Email: " + user.Email;
            BirthdayLabel.Text = "Birthday: " + user.Birthday.ToString();


        }
    }
}