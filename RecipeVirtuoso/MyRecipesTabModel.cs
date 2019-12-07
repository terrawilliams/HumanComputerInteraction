using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeVirtuoso
{
    class MyRecipesTabModel : INotifyPropertyChanged
    {
        #region Members
        private List<Recipe> recipes;
        private Recipe selectedRecipe;

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Getters and Setters
        public List<Recipe> Recipes
        {
            get { return recipes; }
        }

        public Recipe SelectedRecipe
        {
            set 
            { 
                selectedRecipe = value;
                OnPropertyChanged("SelectedRecipe");
            }
        }
        #endregion

        #region Constructor

        #endregion

        #region Methods
        public void AddRecipe()
        {

        }

        public void AddIngredient()
        {

        }

        public void AddRecipeTask()
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
