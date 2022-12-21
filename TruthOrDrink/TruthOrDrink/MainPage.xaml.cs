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

        public string ConnectedUser = string.Empty;
        public MainPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {

            DAL dal = new DAL();
            bool IsUsernameEmpty = string.IsNullOrEmpty(UserName.Text);
            bool IsPasswordEmpty = string.IsNullOrEmpty(Password.Text);

            var userName = UserName.Text;
            var user = dal.GetUser(userName);
            ConnectedUser = UserName.Text;

            var password = Password.Text;

            if (IsUsernameEmpty || IsPasswordEmpty)
            {
                UserNameLabel.Text = "You have to fill in both fields!";
                UserNameLabel.TextColor = Color.Red;
                UserNameLabel.FontSize = 24;
            }
            else
            {
                if (user != null)
                {
                    if (password == user.Password)
                    {
                        Navigation.PushAsync(new HomePage(ConnectedUser));
                    }
                    else
                    {
                        UserNameLabel.Text = "Password and username dont match an existing account!";
                        UserNameLabel.TextColor = Color.Red;
                        UserNameLabel.FontSize = 24;
                    }
                }
                else
                {
                    UserNameLabel.Text = "This account does not match any existing accounts";
                    UserNameLabel.TextColor = Color.Red;
                    UserNameLabel.FontSize=24;
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
