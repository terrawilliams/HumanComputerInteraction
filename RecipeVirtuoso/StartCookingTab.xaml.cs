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
    /// Interaction logic for StartCookingTab.xaml
    /// </summary>
    public partial class StartCookingTab : UserControl
    {
        StartCookingTabModel startCookingTabModel = new StartCookingTabModel();
        public StartCookingTab()
        {
            InitializeComponent();
            this.DataContext = startCookingTabModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            startCookingTabModel.CookMeal();
        }
    }
}
