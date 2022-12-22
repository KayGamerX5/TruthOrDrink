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
    public partial class RegisterPage : ContentPage
    {
        DAL dal = new DAL();
        DateTime birthday = new DateTime();
        public RegisterPage()
        {
            InitializeComponent();
        }

        public void BirthdayDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            birthday = BirthdayDatePicker.Date;
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            var userName = UserNameEntry.Text;
            var password = PasswordEntry.Text;
            var name = NameEntry.Text;
            var email = EmailEntry.Text;
            var Birthday = birthday;
            User user = new User();
            
            user.UserName = userName;
            user.Password = password;
            user.Name = name;
            user.Email = email;
            user.Birthday = Birthday;

            bool CheckboxIsChecked = ConfirmationCheckBox.IsChecked;
            if(CheckboxIsChecked == true)
            {
                dal.CreateUser(user);
                await DisplayAlert("Success", "Your account has been created", "Exit");
            }
            else
            {
                _ = DisplayAlert("Alert!", "You must tick the checkbox to continue", "Exit");
            }

            await Navigation.PopAsync();
        }
    }
}