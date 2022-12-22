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
    public partial class ForgotPasswordPage : ContentPage
    {
        DAL dal = new DAL();
        public ForgotPasswordPage()
        {
            InitializeComponent();
        }

        private void GetPasswordButton_Clicked(object sender, EventArgs e)
        {
            var userName = ForgotPasswordUserNameEntry.Text;

            var user = dal.GetUser(userName);
            if (user != null)
            {
                _ = DisplayAlert("Success!", "An email has been sent to " + user.Email, "Exit");
            }
            else
            {
                _ = DisplayAlert("Oops", "That username doesnt match any existing users", "Exit");
            }
        }
    }
}