﻿using System;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //currently using this as a test driver, will remove this junk later
            RecipeTask r1 = new RecipeTask("a", 1, true);
            RecipeTask r2 = new RecipeTask("b", 2, true);
            RecipeTask r3 = new RecipeTask("c", 3, true);
            RecipeTask r4 = new RecipeTask("d", 15, true);
            RecipeTask r5 = new RecipeTask("e", 100, false);
            Recipe re = new Recipe("aa");
            re.addTask(r3);
            re.addTask(r3);
            Recipe re2 = new Recipe("bb");
            re2.addTask(r1);
            re2.addTask(r5);
            re2.addTask(r4);
            Meal m = new Meal("owowowow");
            m.addRecipe(re);
            m.addRecipe(re2);

            m.cook();
            Console.WriteLine("Timereq: " + m.TotalTimeRequired);
            InitializeComponent();
        }
    }
}
