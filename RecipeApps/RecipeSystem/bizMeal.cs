using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSystem
{
    public class bizMeal : bizObject<bizMeal>
    {
        public bizMeal() { }

        private int _mealId;
        private int _userNameId;
        private string _mealName;
        private DateTime _dateCreated;
        private string _pictureName;
        private string _mealDesc;
        private string _userName;
        private int _numCalories;
        private int _numCourses;
        private int _numrecipes;

        public List<bizMeal> Search(string mealval) {
            SqlCommand cmd = SQLUtility.GetSQLCommand(this.GetSprocName);
            SQLUtility.SetParamValue(cmd, "MealName", mealval);
            DataTable dt = SQLUtility.GetDataTable(cmd);
            return this.GetListFromDataTable(dt);
        }

        public int MealId
        {
            get { return _mealId; }
            set
            {
                if (_mealId != value)
                {
                    _mealId = value;
                    InvokePropertyChanged();
                }
            }
        }

        public int UserNameId
        {
            get { return _userNameId; }
            set
            {
                if (_userNameId != value)
                {
                    _userNameId = value;
                    InvokePropertyChanged();
                }
            }
        }

        public string MealName
        {
            get { return _mealName ; }
            set
            {
                if (_mealName != value)
                {
                    _mealName = value;
                    InvokePropertyChanged();
                }
            }
        }

        public DateTime DateCreated
        {
            get { return _dateCreated; }
            set
            {
                if (_dateCreated != value)
                {
                    _dateCreated = value;
                    InvokePropertyChanged();
                }
            }
        }

        public string PictureName
        {
            get { return _pictureName; }
            set
            {
                if (_pictureName != value)
                {
                    _pictureName = value;
                    InvokePropertyChanged();
                }
            }
        }

        public string MealDesc
        {
            get { return _mealDesc; }
            set
            {
                if (_mealDesc != value)
                {
                    _mealDesc = value;
                    InvokePropertyChanged();
                }
            }
        }

        public string UserName
        {
            get { return _userName; }
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    InvokePropertyChanged();
                }
            }
        }

        public int NumCalories
        {
            get { return _numCalories; }
            set
            {
                if (_numCalories != value)
                {
                    _numCalories = value;
                    InvokePropertyChanged();
                }
            }
        }

        public int NumCourses
        {
            get { return _numCourses; }
            set
            {
                if (_numCourses != value)
                {
                    _numCourses = value;
                    InvokePropertyChanged();
                }
            }
        }

        public int NumRecipes
        {
            get { return _numrecipes; }
            set
            {
                if (_numrecipes != value)
                {
                    _numrecipes = value;
                    InvokePropertyChanged();
                }
            }
        }

    }
}
