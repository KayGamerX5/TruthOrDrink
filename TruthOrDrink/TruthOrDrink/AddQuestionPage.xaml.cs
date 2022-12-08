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
    public partial class AddQuestionPage : ContentPage
    {
        public AddQuestionPage()
        {
            InitializeComponent();
        }

        private async void SaveQuestionButton_Clicked(object sender, EventArgs e)
        {
            Question question = new Question();
            question.QuestionBody = QuestionEntry.Text;
            
            SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
            sQLiteConnection.CreateTable<Question>();
            int insertedRows = sQLiteConnection.Insert(question);
            sQLiteConnection.Close();

            if(insertedRows > 0)
            {
                _ = DisplayAlert("Succes!", "The question has been added to the database", "Exit");
            }
            else
            {
                _ = DisplayAlert("Oops!", "Something went wrong, try again later", "Exit");
            }

            await Navigation.PopAsync();
        }
    }
}