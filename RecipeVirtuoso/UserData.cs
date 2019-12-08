using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeVirtuoso
{
    class UserData : INotifyPropertyChanged
    {
        #region Members
        private static UserData instance = new UserData();

        private static ObservableCollection<Recipe> userRecipes = new ObservableCollection<Recipe>();
        private static ObservableCollection<Meal> userMeals = new ObservableCollection<Meal>();

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructor
        private UserData() { }
        #endregion

        #region Getters and Setters
        public static UserData Instance
        {
            get { return instance; }
        }

        public static ObservableCollection<Recipe> UserRecipes
        {
            get { return userRecipes; }
            set 
            { 
                userRecipes = value;
                instance.OnPropertyChanged("UserRecipes");
            }
        }

        public static ObservableCollection<Meal> UserMeals
        {
            get { return userMeals; }
            set 
            { 
                userMeals = value;
                instance.OnPropertyChanged("UserMeals");
            }
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

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        #endregion
    }
}
