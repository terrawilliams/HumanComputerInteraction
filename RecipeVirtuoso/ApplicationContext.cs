using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeVirtuoso
{
    class ApplicationContext
    {
        public static List<Meal> myMeals = new List<Meal>();
        public static List<Recipe> myRecipes = new List<Recipe>();

        //Note to self:
        //to hook things up, call ApplicationContext.meals, and the variable should be properly shared! 
    }
}
