using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruthOrDrink
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartGamePage : ContentPage
    {
        public StartGamePage()
        {
            InitializeComponent();
        }

        private void StartGameButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}