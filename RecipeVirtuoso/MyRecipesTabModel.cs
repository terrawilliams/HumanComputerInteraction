using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeVirtuoso
{
    public class MyRecipesTabModel : INotifyPropertyChanged
    {
        #region Members
        private ObservableCollection<Recipe> recipes = new ObservableCollection<Recipe>();
        private Recipe selectedRecipe;
        private Recipe currentRecipe;

        private bool addingRecipe;
        private bool addingIngredient;
        private bool addingTask;

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Getters and Setters
        public ObservableCollection<Recipe> Recipes
        {
            get { return recipes; }
        }

        public Recipe SelectedRecipe
        {
            set 
            { 
                selectedRecipe = value;
                OnPropertyChanged("SelectedRecipe");

                foreach(Recipe recipe in Recipes)
                {
                    if (recipe.Name == selectedRecipe.Name)
                        currentRecipe = recipe;
                }

                OnPropertyChanged("CurrentRecipe");
            }
        }

        public Recipe CurrentRecipe
        {
            get { return currentRecipe; }
        }

        public bool AddingIngredient
        {
            get { return addingIngredient; }
            set { addingIngredient = true; }
        }

        public bool AddingTask
        {
            get { return addingTask; }
            set { addingTask = true; }
        }
        #endregion

        #region Constructor
        public MyRecipesTabModel()
        {
            addingIngredient = false;
            addingTask = false;
        }
        #endregion

        #region Methods
        public void AddRecipe()
        {

        }

        public void AddIngredient(string ingredient)
        {
            foreach (Recipe recipe in recipes)
            {
                if (recipe.Name == currentRecipe.Name)
                {
                    recipe.addIngredient(ingredient);
                    currentRecipe = recipe;
                    OnPropertyChanged("CurrentRecipe");
                }
            }
        }

        public void StopAddingIngredient()
        {
            addingIngredient = false;
            OnPropertyChanged("AddingIngredient");
        }

        public void StartAddingRecipeTask()
        {
            
        }

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        #endregion
    }
}
