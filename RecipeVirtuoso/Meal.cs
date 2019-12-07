using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeVirtuoso;

namespace RecipeVirtuoso
{
    public class Meal
    {
        private List<Recipe> recipes = new List<Recipe>();
        private List<RecipeTask> sortedRecipeTasks = new List<RecipeTask>();
        private int totalTimeRequired;
        private string name;

        public Meal(string mealName)
        {
            name = mealName;
        }

        public string getName()
        {
            return name;
        }

        public void addRecipe(Recipe r)
        {
            recipes.Add(r);
        }

        public void editRecipe(Recipe r, int recipeNum)
        {
            recipes[recipeNum] = r;
        }

        public int getTotalTimeRequired()
        {
            return totalTimeRequired;
        }

        public List<RecipeTask> getSortedRecipeTasks()
        {
            return sortedRecipeTasks;
        }

        //cook processes all the data and is the main algorithm. 
        //After calling cook(), getTotalTimeRequired() and getSortedRecipeTasks() are natural next steps
        public void cook()
        {
            //terra: i have a gigantic brain
            int numRecipes = recipes.Count;
            int [] tasksPerRecipe = new int[numRecipes];
            for (int i = 0; i < numRecipes; i++)
            {
                tasksPerRecipe[i] = recipes[i].getNumTasks();
            }
            //an array of total time remaining at each step. Each row is a recipe, each column is the time to finish.
            int [,] totalTimeRemaining = new int[numRecipes,tasksPerRecipe.Max()];
            int lastTime;
            for (int i = 0; i < numRecipes; i++)
            {
                lastTime = 0;
                for (int j = recipes[i].getNumTasks() - 1; j >= 0; j--)
                {
                    totalTimeRemaining[i, j] = recipes[i].getTasks()[j].getTime() + lastTime;
                    lastTime = totalTimeRemaining[i, j];
                }
            }
            //these are iterators that increment for each recipe's task
            int [] taskIterators = new int[numRecipes];
            for (int i = 0; i < numRecipes; i++)
            {
                taskIterators[i] = 0;
            }
            //these are holds put on a recipe's task while a passive task is happening. 0 is no hold
            int [] holds = new int[numRecipes];
            for (int i = 0; i < numRecipes; i++)
            {
                holds[i] = 0;
            }
            //Here's the juicy part
            totalTimeRequired = 0;
            while (!Enumerable.SequenceEqual(tasksPerRecipe, taskIterators))
            {
                int longestTimeRemaining = 0;
                int longestTimeIndex = -1;

                //If all recipes that aren't finished are on hold, then set the lowest hold to 0.
                int lowestHold = Int32.MaxValue;
                int lowestHoldIndex = -1;
                for (int i = 0; i < numRecipes; i++)
                {
                    //make sure recipe isn't done
                    if (taskIterators[i] < tasksPerRecipe[i])
                    {
                        if (holds[i] < lowestHold)
                        {
                            lowestHold = holds[i];
                            lowestHoldIndex = i;
                        }
                    }
                }

                holds[lowestHoldIndex] = 0;

                for (int i = 0; i < numRecipes; i++)
                {
                    //make sure that recipe isn't done or on hold
                    if (taskIterators[i] < tasksPerRecipe[i] && holds[i] == 0) 
                    {
                        //compute max
                        if (totalTimeRemaining[i, taskIterators[i]] > longestTimeRemaining)
                        {
                            longestTimeRemaining = totalTimeRemaining[i, taskIterators[i]];
                            longestTimeIndex = i;
                        }
                    }
                }

                //This is the recipe task to select to add.
                RecipeTask recipeTask = recipes[longestTimeIndex].getTasks()[taskIterators[longestTimeIndex]];
                sortedRecipeTasks.Add(recipeTask);
                totalTimeRequired += recipeTask.getTime();

                //update all of the holds
                for (int i = 0; i < numRecipes; i++)
                {
                    holds[i] = Math.Max(0, holds[i] - recipeTask.getTime());
                    totalTimeRequired -= holds[i]; //this just takes off time that is spent on waiting for passive events
                }
                //if the task is passive, add a hold
                holds[longestTimeIndex] = !recipeTask.getActive() ? recipeTask.getTime() : 0;

                taskIterators[longestTimeIndex]++; //iterate to next task for that recipe
            }
            //Debugging
            Console.WriteLine("Sorted List:");
            foreach (var recipeTask in sortedRecipeTasks)
            {
                Console.WriteLine(recipeTask.getTime());
            }
            //End Debugging
        }
    }
}
