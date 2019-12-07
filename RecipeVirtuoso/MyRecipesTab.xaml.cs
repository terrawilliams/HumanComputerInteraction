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

        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            AddRecipePopup.IsOpen = true;
        }

//        public void AddRecipe()
//        {
//            myRecipesTabModel.AddRecipe();
//        }

        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            myRecipesTabModel.StartAddingIngredient();
        }

        private void AddInstructionButton_Click(object sender, RoutedEventArgs e)
        {
            myRecipesTabModel.StartAddingRecipeTask();
        }

        private void PopUpAddButton_Click(object sender, RoutedEventArgs e)
        {
            myRecipesTabModel.AddIngredient(IngredientDescription.Text);
            myRecipesTabModel.StopAddingIngredient();
            IngredientDescription.Text = string.Empty;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            myRecipesTabModel.StopAddingIngredient();
        }
    }
}
