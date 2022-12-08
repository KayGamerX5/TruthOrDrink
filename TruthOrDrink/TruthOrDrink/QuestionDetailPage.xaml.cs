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
    public partial class QuestionDetailPage : ContentPage
    {
        Question question;
        public QuestionDetailPage(Question selectedQuestion)
        {
            InitializeComponent();
            question = selectedQuestion;

            IdLabel.Text = question.Id.ToString();
            QuestionBodyEntry.Text = question.QuestionBody;
        }

        private async void EditButton_Clicked(object sender, EventArgs e)
        {
            int updatedRows;
            question.QuestionBody = QuestionBodyEntry.Text;

            using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
            {
                sQLiteConnection.CreateTable<Question>();
                updatedRows = sQLiteConnection.Update(question);
            }

            if (updatedRows > 0)
            {
                _ = DisplayAlert("Succes!", "Succesfully edited question", "Exit");
            }
            else
            {
                _ = DisplayAlert("Oops!", "Something went wrong, try again!", "Exit");
            }

            await Navigation.PopAsync();
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            int deletedRows;
            question.QuestionBody = QuestionBodyEntry.Text;

            using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
            {
                sQLiteConnection.CreateTable<Question>();
                deletedRows = sQLiteConnection.Delete(question);
            }

            if (deletedRows > 0)
            {
                _ = DisplayAlert("Succes", "Question succesfully deleted", "Exit");
            }
            else
            {
                _ = DisplayAlert("Oops!", "Something went wrong, try again!", "Exit");
            }

            await Navigation.PopAsync();
        }
    }
}