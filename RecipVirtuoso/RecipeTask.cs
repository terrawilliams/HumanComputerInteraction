using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeVirtuoso
{
    class RecipeTask
    {
        private string description;
        private int timeRequired;
        private bool activeTask;

        public RecipeTask(string desc, int time, bool active)
        {
            description = desc;
            timeRequired = time;
            activeTask = active;
        }

        public string getDesc()
        {
            return description;
        }
        public int getTime()
        {
            return timeRequired;
        }

        public bool getActive()
        {
            return activeTask;
        }
    }
}
