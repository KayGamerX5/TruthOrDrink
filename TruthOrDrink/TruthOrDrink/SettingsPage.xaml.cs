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
    public partial class SettingsPage : ContentPage
    {
        DateTime birthday = new DateTime();
        public SettingsPage()
        {
            InitializeComponent();
        }
        public string ConnectedUser { get; }
        public SettingsPage(string connectedUser)
        {
            InitializeComponent();

            ConnectedUser = connectedUser;

            DAL dal = new DAL();
            var user = dal.GetUser(ConnectedUser);
           

            UserNameLabel.Text = "Username: " + user.UserName;
            PasswordLabel.Text = "Password: " + user.Password;
            NameLabel.Text = "Real Name: " + user.Name;
            EmailLabel.Text = "Email: " + user.Email;
            BirthdayLabel.Text = "Birthday: " + user.Birthday.ToString();
        }

        private void EditUserButton_Clicked(object sender, EventArgs e)
        {
            EditUserNameEntry.IsVisible = true;
            EditRealNameEntry.IsVisible = true;
            EditPasswordEntry.IsVisible = true;
            EditEmailEntry.IsVisible = true;
            DatePickerLabel.IsVisible = true;
            EditBirthdayDatePicker.IsVisible = true;
            CheckboxLabel.IsVisible = true;
            EditUserConfirmCheckbox.IsVisible = true;
            EditUserSaveButton.IsVisible = true;
        }

        private void EditBirthdayDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            birthday = EditBirthdayDatePicker.Date;
        }

        private void EditUserSaveButton_Clicked(object sender, EventArgs e)
        {
            User user = new User();

            using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
            {
                connection.CreateTable<User>();
                user = connection.Table<User>().Where(x => x.UserName == ConnectedUser).FirstOrDefault();
            }

            bool CheckboxIsChecked = EditUserConfirmCheckbox.IsChecked;
            if (CheckboxIsChecked == true)
            {
                user.UserName = EditUserNameEntry.Text;
                user.Password = EditPasswordEntry.Text;
                user.Name = EditRealNameEntry.Text;
                user.Email = EditEmailEntry.Text;
                user.Birthday = birthday;
                

                int updatedRows;

                using (SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation))
                {
                    connection.CreateTable<User>();
                    updatedRows = connection.Update(user);
                    if (updatedRows > 0)
                    {
                        DisplayAlert("Succes!", "Succesfully edited account details", "Exit");
                        Navigation.PushAsync(new MainPage());
                    }
                    else
                    {
                        DisplayAlert("Oops!", "Something went wrong, try again!", "Exit");
                    }
                }
            }


            else
            {
                DisplayAlert("Oops!", "You have to check the checkbox to confirm the edit", "Exit");
            }

        }

        private void LogoutButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}