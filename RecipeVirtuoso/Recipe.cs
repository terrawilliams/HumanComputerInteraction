using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeVirtuoso;

namespace RecipeVirtuoso
{
    class Recipe
    {
        private List<RecipeTask> tasks = new List<RecipeTask>();
        private string name;
        private List<string> ingredients = new List<string>();

        public Recipe(string recipeName)
        {
            name = recipeName;
        }

        public string getName()
        {
            return name;
        }

        public void addIngredient(string ingredient)
        {
            ingredients.Add(ingredient);
        }

        public List<string> getIngredients()
        {
            return ingredients;
        }

        public void addTask(RecipeTask r)
        {
            tasks.Add(r);
        }

        public void removeTask(int taskNum)
        {
            tasks.RemoveAt(taskNum);
        }

        public void editTask(RecipeTask r, int taskNum)
        {
            tasks[taskNum] = r;
        }

        public int getNumTasks()
        {
            return tasks.Count;
        }

        public List<RecipeTask> getTasks()
        {
            return tasks;
        }
    }
}
