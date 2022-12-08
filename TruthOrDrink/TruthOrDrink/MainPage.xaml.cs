using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            if (IsUsernameEmpty || IsPasswordEmpty)
            {
                UserNameLabel.Text = "You have to fill in both fields!";
                UserNameLabel.TextColor = Color.Red;
                UserNameLabel.FontSize = 24;
            }
            else
            {
                Navigation.PushAsync(new HomePage());
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
