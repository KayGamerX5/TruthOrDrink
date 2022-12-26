using System;
using System.Collections.Generic;
using System.Text;

namespace TruthOrDrink.Model
{
    public class Cocktail
    {
        public static string GenerateURLCocktailName(string name)
        {
            return string.Format(Constants.COCKTAIL_BY_NAME, name);
        }

        public static string GenerateURLLetter(string name)
        {
            return string.Format(Constants.COCKTAIL_BY_LETTER, name);
        }

        public static string GenerateURLRandom()
        {
            return Constants.COCKTAIL_AT_RANDOM;
        }

        public static string GenerateURLDetailId(string name)
        {
            return string.Format(Constants.COCKTAIL_DEATILS_BY_ID, name);
        }

        public static string GenerateURLIngredientName(string name)
        {
            return string.Format(Constants.INGREDIENT_BY_NAME, name);
        }

        public static string GenerateURLIngredientId(string name)
        {
            return string.Format(Constants.INGREDIENT_BY_ID, name);
        }
    }
}
