using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruthOrDrink.Logic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruthOrDrink
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApiPage : ContentPage
    {
        public ApiPage()
        {
            InitializeComponent();
        }

        private async void RandomCocktailButton_Clicked(object sender, EventArgs e)
        {
            var cocktails = await CocktailLogic.GetRandomCocktail();
            CocktailListView.ItemsSource = cocktails;
        }

        private void BrowserButton_Clicked(object sender, EventArgs e)
        {
            Browser.OpenAsync("https://foodfornet.com/alcoholic-drinks-drinking-games/", BrowserLaunchMode.SystemPreferred);
        }
    }
}