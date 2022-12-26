using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TruthOrDrink.Model;

namespace TruthOrDrink.Logic
{
    public class CocktailLogic
    {
        public async static Task<List<Cocktail>> GetCocktailsByName(string name)
        {
            List<Cocktail> cocktails = new List<Cocktail>();

            var url = Cocktail.GenerateURLCocktailName(name);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
            }

            return cocktails;
        }

        public async static Task<List<Drink>> GetRandomCocktail()
        {
            List<Drink> cocktails = new List<Drink>();
            var url = Cocktail.GenerateURLRandom();
            using(HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                var RandomCocktailResponse = JsonConvert.DeserializeObject<RandomCocktailResponse>(json);
                cocktails = RandomCocktailResponse.drinks as List<Drink>;
            }

            return cocktails;
        }
    }
}
