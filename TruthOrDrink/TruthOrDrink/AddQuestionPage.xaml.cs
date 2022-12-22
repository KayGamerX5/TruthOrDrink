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
    public partial class AddQuestionPage : ContentPage
    {
        DAL dal = new DAL();
        public AddQuestionPage()
        {
            InitializeComponent();
        }

        

        private void CategoryPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private async void SaveQuestionButton_Clicked(object sender, EventArgs e)
        {
            Question question = new Question();
            question.QuestionBody = QuestionEntry.Text;
            question.Category = CategoryPicker.SelectedIndex;
            dal.CreateQuestion(question);

            await Navigation.PopAsync();
        }
    }
}