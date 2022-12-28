using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruthOrDrink.DataAccess;
using TruthOrDrink.Model;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruthOrDrink
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        DAL dal = new DAL();
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
            var user = dal.GetUser(ConnectedUser);

            bool CheckboxIsChecked = EditUserConfirmCheckbox.IsChecked;
            if (CheckboxIsChecked == true)
            {
                user.UserName = EditUserNameEntry.Text;
                user.Password = EditPasswordEntry.Text;
                user.Name = EditRealNameEntry.Text;
                user.Email = EditEmailEntry.Text;
                user.Birthday = birthday;


                dal.UpdateUser(user);
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
       

        private async void ImagePickerButton_Clicked(object sender, EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Take a photo"
            });

            var stream = await result.OpenReadAsync();

            ResultImage.Source = ImageSource.FromStream(() => stream);
        }

        private async void ImageTakerButton_Clicked(object sender, EventArgs e)
        {
            var result = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
            {
                Title = "Take a photo"
            });

            var stream = await result.OpenReadAsync();

            ResultImage.Source = ImageSource.FromStream(() => stream);
        }
    }
}