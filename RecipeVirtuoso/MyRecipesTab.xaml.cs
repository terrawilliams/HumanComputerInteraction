using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RecipeVirtuoso;

namespace RecipeVirtuoso
{
    /// <summary>
    /// Interaction logic for MyRecipesTab.xaml
    /// </summary>
    public partial class MyRecipesTab : UserControl
    {
        public static MyRecipesTabModel myRecipesTabModel = new MyRecipesTabModel();
        public MyRecipesTab()
        {
            InitializeComponent();
            this.DataContext = myRecipesTabModel;
        }

        //add a recipe
        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            myRecipesTabModel.StartAddingRecipe();
        }

        private void PopUpAddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            myRecipesTabModel.AddRecipe(RecipeName.Text);
            myRecipesTabModel.StopAddingRecipe();
            RecipeName.Text = string.Empty;
        }

        private void RecipeCancelButton_Click(object sender, RoutedEventArgs e)
        {
            myRecipesTabModel.StopAddingRecipe();
        }

        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            myRecipesTabModel.StartAddingIngredient();
        }

        private void AddInstructionButton_Click(object sender, RoutedEventArgs e)
        {
            myRecipesTabModel.StartAddingRecipeTask();
        }

        private void IngredientPopUpAddButton_Click(object sender, RoutedEventArgs e)
        {
            myRecipesTabModel.AddIngredient(IngredientDescription.Text);
            myRecipesTabModel.StopAddingIngredient();
            IngredientDescription.Text = string.Empty;
        }

        private void IngredientCancelButton_Click(object sender, RoutedEventArgs e)
        {
            myRecipesTabModel.StopAddingIngredient();
        }
    }
}
