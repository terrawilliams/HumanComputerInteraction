using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeVirtuoso;

namespace RecipVirtuoso
{
    class Meal
    {
        private List<Recipe> recipes = new List<Recipe>();

        public void addRecipe(Recipe r)
        {
            recipes.Add(r);
        }

        public void editRecipe(Recipe r, int recipeNum)
        {
            recipes[recipeNum] = r;
        }

        public void cook()
        {
            List<RecipeTask> goodList = new List<RecipeTask>();
            //terra: i have a gigantic brain
            int numRecipes = recipes.Count;
            int [] tasksPerRecipe = new int[numRecipes];
            for (int i = 0; i < numRecipes; i++)
            {
                tasksPerRecipe[i] = recipes[i].getNumTasks();
            }
            int [,] totalTimeRemaining = new int[numRecipes,tasksPerRecipe.Max()];
            bool [,] actives = new bool[numRecipes, tasksPerRecipe.Max()];
            int lastTime;
            for (int i = 0; i < numRecipes; i++)
            {
                lastTime = 0;
                for (int j = recipes[i].getNumTasks() - 1; j >= 0; j--)
                {
                    totalTimeRemaining[i, j] = recipes[i].getTasks()[j].getTime() + lastTime;
                    lastTime = totalTimeRemaining[i, j];
                    actives[i, j] = recipes[i].getTasks()[j].getActive();
                }
            }
            int [] taskIterators = new int[numRecipes];
            for (int i = 0; i < numRecipes; i++)
            {
                taskIterators[i] = 0;
            }
            //Here's the juicy part
            while (!Enumerable.SequenceEqual(tasksPerRecipe, taskIterators))
            {
                int longestTimeRemaining = 0;
                int longestTimeIndex = -1;
                for (int i = 0; i < numRecipes; i++)
                {
                    if (taskIterators[i] < tasksPerRecipe[i]) //make sure that recipe isnt done
                    {
                        if (totalTimeRemaining[i, taskIterators[i]] > longestTimeRemaining)
                        {
                            longestTimeRemaining = totalTimeRemaining[i, taskIterators[i]];
                            longestTimeIndex = i;
                        }
                    }
                }
                goodList.Add(recipes[longestTimeIndex].getTasks()[taskIterators[longestTimeIndex]]);
                taskIterators[longestTimeIndex]++; //iterate to next task for that recipe
            }
            Console.WriteLine("Sorted List:");
            foreach (var recipeTask in goodList)
            {
                Console.WriteLine(recipeTask.getTime());
            }
        }
    }
}
