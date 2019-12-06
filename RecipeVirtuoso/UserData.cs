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
        private static UserData instance;

        private static List<Recipe> userRecipes = new List<Recipe>();
        private static List<Meal> userMeals = new List<Meal>();
        #endregion

        private UserData() { }

        public static UserData Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserData();

                return instance;
            }
        }

        public static List<Recipe> UserRecipes
        {
            get { return userRecipes; }
        }

        public static List<Meal> UserMeals
        {
            get { return userMeals; }
        }
    }
}
