using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeVirtuoso
{
    class StartCookingTabModel : INotifyPropertyChanged
    {
        #region Members
        private Meal selectedMeal;
        private Meal currentMeal;

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Getters and Setters
        public ObservableCollection<Meal> Meals
        {
            get 
            {
                return UserData.UserMeals; 
            }
        }
        public Meal SelectedMeal
        {
            set
            {
                selectedMeal = value;
                OnPropertyChanged("SelectedMeal");

                foreach (Meal meal in UserData.UserMeals)
                {
                    if (meal.Name == selectedMeal.Name)
                        currentMeal = meal;
                }

                OnPropertyChanged("CurrentMeal");
            }
        }

        public Meal CurrentMeal
        {
            get { return currentMeal; }
        }
        #endregion

        #region Constructor
        public StartCookingTabModel()
        {

        }
        #endregion

        #region Methods
        public void CookMeal()
        {
            OnPropertyChanged("Meals");
            if (currentMeal != null)
            {
                currentMeal.cook();
                OnPropertyChanged("CurrentMeal");
            }
        }

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        #endregion
    }
}
