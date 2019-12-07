using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for AddRecipePopup.xaml
    /// </summary>
    public partial class AddRecipePopup : UserControl
    {
        public AddRecipePopup()
        {
            InitializeComponent();
        }

        // Handles the Click event of the 'Save' button simulating a save and close 
        private void SimulateSaveClicked(object sender, RoutedEventArgs e)
        {
            // in this example we assume the parent of the UserControl is a Popup 
            Popup p = this.Parent as Popup;
            // close the Popup
            if (p != null) { p.IsOpen = false; }

            MyRecipesTab.myRecipesTabModel.AddRecipe(uhh.Text);
        }
    }
}
