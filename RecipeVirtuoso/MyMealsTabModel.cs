using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeVirtuoso
{
    class MyMealsTabModel : INotifyPropertyChanged
    {
        #region Members
        private ObservableCollection<Meal> meals = new ObservableCollection<Meal>();
        private Meal selectedMeal;
        private Meal currentMeal;

        private ObservableCollection<string> possibleRecipes = new ObservableCollection<string>();

        private bool addingMeal;
        private bool addingRecipe;

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Getters and Setters
        public ObservableCollection<Meal> Meals
        {
            get { return meals; }
        }

        public Meal SelectedMeal
        {
            set
            {
                selectedMeal = value;
                OnPropertyChanged("SelectedMeal");

                foreach (Meal meal in meals)
                {
                    if (meal.Name == selectedMeal.Name)
                        currentMeal = meal;
                }

                OnPropertyChanged("CurrentMeal");
            }
        }

        public Meal CurrentMeal
        {
            get { return currentMeal; }
        }

        public ObservableCollection<string> PossibleRecipes
        {
            get
            {
                return possibleRecipes;
            }
        }

        public bool AddingMeal
        {
            get { return addingMeal; }
            set { addingMeal = true; }
        }

        public bool AddingRecipe
        {
            get { return addingRecipe; }
            set { addingRecipe = true; }
        }
        #endregion

        #region Constructor
        public MyMealsTabModel()
        {
            addingMeal = false;
            addingRecipe = false;
        }
        #endregion

        #region Methods
        public void StartAddingMeal()
        {
            addingMeal = true;
            OnPropertyChanged("AddingMeal");
        }

        public void AddMeal(string mealName)
        {
            meals.Add(new Meal(mealName));
            OnPropertyChanged("Meals");
        }

        public void StopAddingMeal()
        {
            addingMeal = false;
            OnPropertyChanged("AddingMeal");

            UserData.UserMeals = meals;
        }

        public void StartAddingRecipe()
        {
            possibleRecipes.Clear();

            foreach(Recipe recipe in UserData.UserRecipes)
            {
                possibleRecipes.Add(recipe.Name);
            }
            OnPropertyChanged("PossibleRecipes");

            if (currentMeal != null)
            {
                addingRecipe = true;
                OnPropertyChanged("AddingRecipe");
            }
        }

        public void AddRecipe(Recipe newRecipe)
        {
            currentMeal.addRecipe(newRecipe);
        }

        public void StopAddingRecipe()
        {
            addingRecipe = false;
            OnPropertyChanged("AddingRecipe");

            UserData.UserMeals = meals;
        }

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        #endregion
    }
}
