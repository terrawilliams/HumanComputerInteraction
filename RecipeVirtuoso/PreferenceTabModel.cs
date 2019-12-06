using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeVirtuoso
{
    class PreferenceTabModel
    {
        #region Members
        private List<int> numOvens = new List<int>();
        private List<int> numStoves = new List<int>();

        private int selectedNumOvens;
        private int selectedNumStoves;
        #endregion

        #region Getters and Setters
        public List<int> NumOvens
        {
            get { return numOvens; }
            set { numOvens = value; }
        }

        public List<int> NumStoves
        {
            get { return numStoves; }
            set { numStoves = value; }
        }

        public int SelectedNumOvens 
        { 
            get { return selectedNumOvens; }
            set { selectedNumOvens = value; }
        }

        public int SelectedNumStoves
        {
            get { return selectedNumStoves; }
            set { selectedNumStoves = value; }
        }
        #endregion

        #region Constructor
        public PreferenceTabModel()
        {
            numOvens.Add(1);
            numOvens.Add(2);
            numOvens.Add(3);
            numOvens.Add(4);
            numOvens.Add(5);

            numStoves.Add(1);
            numStoves.Add(2);
            numStoves.Add(3);
            numStoves.Add(4);
            numStoves.Add(5);
            numStoves.Add(6);
            numStoves.Add(7);
            numStoves.Add(8);

            selectedNumOvens = numOvens.First();
            selectedNumStoves = numStoves.First();
        }
        #endregion
    }
}
