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
    public partial class QuestionPage : ContentPage
    {
        public QuestionPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
            {
                sQLiteConnection.CreateTable<Question>();
                var questions = sQLiteConnection.Table<Question>().ToList();
                QuestionListView.ItemsSource = questions;
            }
        }

        private void AddQuestionButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddQuestionPage());
        }

        private void EditQuestionButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditQuestionPage());
        }

        private void DeleteQuestionButton_Clicked(object sender, EventArgs e)
        {

        }

        private void QuestionListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedQuestion = QuestionListView.SelectedItem as Question;
            if (selectedQuestion != null)
            {
                Navigation.PushAsync(new QuestionDetailPage(selectedQuestion));
            }
        }
    }
}