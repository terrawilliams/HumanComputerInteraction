using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeVirtuoso;

namespace RecipeVirtuoso
{
    class Recipe
    {
        private ObservableCollection<RecipeTask> tasks = new ObservableCollection<RecipeTask>();
        private string name;
        private ObservableCollection<string> ingredients = new ObservableCollection<string>();

        public string Name
        { 
            get { return name; }
            set { name = value; }
        }

        public ObservableCollection<RecipeTask> Tasks
        {
            get { return tasks; }
        }

        public ObservableCollection<string> Ingredients
        {
            get { return ingredients; }
        }

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

        public ObservableCollection<string> getIngredients()
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

        public ObservableCollection<RecipeTask> getTasks()
        {
            return tasks;
        }
    }
}
