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

namespace RecipeVirtuoso
{
    /// <summary>
    /// Interaction logic for MyMealsTab.xaml
    /// </summary>
    public partial class MyMealsTab : UserControl
    {
        MyMealsTabModel myMealsTabModel = new MyMealsTabModel();
        public MyMealsTab()
        {
            InitializeComponent();
            this.DataContext = myMealsTabModel;
        }

        private void AddMealButton_Click(object sender, RoutedEventArgs e)
        {
            myMealsTabModel.StartAddingMeal();
        }

        private void PopUpAddMealButton_Click(object sender, RoutedEventArgs e)
        {
            myMealsTabModel.AddMeal(MealName.Text);
            myMealsTabModel.StopAddingMeal();
            MealName.Text = string.Empty;
        }

        private void MealCancelButton_Click(object sender, RoutedEventArgs e)
        {
            myMealsTabModel.StopAddingMeal();
        }

        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            myMealsTabModel.StartAddingRecipe();
        }

        private void PopUpAddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            foreach(Recipe recipe in UserData.UserRecipes)
            {
                if(recipe.Name == RecipeName.SelectedItem.ToString())
                {
                    myMealsTabModel.AddRecipe(recipe);
                }
            }

            myMealsTabModel.StopAddingRecipe();
        }

        private void RecipeCancelButton_Click(object sender, RoutedEventArgs e)
        {
            myMealsTabModel.StopAddingRecipe();
        }
    }
}
