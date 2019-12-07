using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeVirtuoso
{
    public class RecipeTask
    {
        private string description;
        private int timeRequired;
        private bool activeTask;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public int TimeRequired
        {
            get { return timeRequired; }
        }

        public bool ActiveTask
        { 
            get { return activeTask; }
        }

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
