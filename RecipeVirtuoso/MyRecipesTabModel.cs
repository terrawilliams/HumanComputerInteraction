using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeVirtuoso
{
    public class MyRecipesTabModel : INotifyPropertyChanged
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
            set
            {
                recipes = value;
                OnPropertyChanged("Recipes");
            }
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

        public MyRecipesTabModel()
        {
            Recipes = new List<Recipe>();
            Recipes.Add(new Recipe("test"));
        }
        #endregion

        #region Methods
        public void AddRecipe(string text)
        {
            var tmp = Recipes;
            Recipes = new List<Recipe>();
            tmp.ForEach(Recipes.Add);
            Recipes.Add(new Recipe(text));
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
