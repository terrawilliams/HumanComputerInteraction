using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeVirtuoso;

namespace RecipVirtuoso
{
    class Recipe
    {
        private List<RecipeTask> tasks = new List<RecipeTask>();

        public void addTask(RecipeTask r)
        {
            tasks.Add(r);
        }

        public void removeTask(int taskNum)
        {
            //todo
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
