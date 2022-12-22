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
    public partial class QuestionDetailPage : ContentPage
    {
        Question question;
        DAL dal = new DAL();
        public QuestionDetailPage(Question selectedQuestion)
        {
            InitializeComponent();
            question = selectedQuestion;

            IdLabel.Text = question.Id.ToString();
            QuestionBodyEntry.Text = question.QuestionBody;
            if(question.Category == 0)
            {
                CategoryLabel.Text = "On the rocks";
            }
            if (question.Category == 1)
            {
                CategoryLabel.Text = "Happy hour";
            }
            if (question.Category == 2)
            {
                CategoryLabel.Text = "Last Call";
            }
            if (question.Category == 3)
            {
                CategoryLabel.Text = "Extra dirty";
            }
        }

        private async void EditButton_Clicked(object sender, EventArgs e)
        {
            question.QuestionBody = QuestionBodyEntry.Text;
            question.Category = CategoryPicker.SelectedIndex;

            dal.UpdateQuestion(question);

            await Navigation.PopAsync();
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            question.QuestionBody = QuestionBodyEntry.Text;
            question.Category = question.Category;

            dal.DeleteQuestion(question);

            await Navigation.PopAsync();
        }

        private void CategoryPicker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}