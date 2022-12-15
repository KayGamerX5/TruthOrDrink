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
    public partial class ForgotPasswordPage : ContentPage
    {
        public ForgotPasswordPage()
        {
            InitializeComponent();
        }

        private void GetPasswordButton_Clicked(object sender, EventArgs e)
        {
            var userName = ForgotPasswordUserNameEntry.Text;

            User user = new User();

            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<User>();
                user = connection.Table<User>().Where(x => x.UserName == userName).FirstOrDefault();
            }
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