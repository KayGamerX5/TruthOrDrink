using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruthOrDrink.DataAccess;
using TruthOrDrink.Model;
using Xamarin.Forms;

namespace TruthOrDrink
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            bool IsUsernameEmpty = string.IsNullOrEmpty(UserName.Text);
            bool IsPasswordEmpty = string.IsNullOrEmpty(Password.Text);

            var userName = UserName.Text;
            User user = new User();

            var password = Password.Text;

            using(SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<User>();
                user = connection.Table<User>().Where(x => x.UserName == userName).FirstOrDefault();

            }

            if (IsUsernameEmpty || IsPasswordEmpty)
            {
                UserNameLabel.Text = "You have to fill in both fields!";
                UserNameLabel.TextColor = Color.Red;
                UserNameLabel.FontSize = 24;
            }
            else
            {
                if (password == user.Password)
                {
                    Navigation.PushAsync(new HomePage());
                }
                else
                {
                    UserNameLabel.Text = "Password and username dont match!";
                    UserNameLabel.TextColor = Color.Red;
                    UserNameLabel.FontSize = 24;
                }
            }
        }

        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }

        private void ForgotPasswordButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ForgotPasswordPage());
        }
    }
}
