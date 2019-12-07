using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeVirtuoso
{
    class UserData
    {
        #region Members
        private static UserData instance = new UserData();

        private static List<Recipe> userRecipes = new List<Recipe>();
        private static List<Meal> userMeals = new List<Meal>();
        #endregion

        #region Constructor
        private UserData() { }
        #endregion

        #region Getters and Setters
        public static UserData Instance
        {
            get { return instance; }
        }

        public static List<Recipe> UserRecipes
        {
            get { return userRecipes; }
            set { userRecipes = value; }
        }

        public static List<Meal> UserMeals
        {
            get { return userMeals; }
            set { userMeals = value; }
        }

        #endregion

        #region Methods
        public void AddRecipe(Recipe recipe)
        {
            userRecipes.Add(recipe);
        }

        public void AddMeal(Meal meal)
        {
            userMeals.Add(meal);
        }
        #endregion
    }
}
