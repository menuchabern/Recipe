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
        private int _activestatus;
        private string _pictureName;
        private string _mealDesc;

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

        public int ActiveStatus
        {
            get { return _activestatus; }
            set
            {
                if (_activestatus != value)
                {
                    _activestatus = value;
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
            get { return _mealName; }
            set
            {
                if (_mealDesc != value)
                {
                    _mealDesc = value;
                    InvokePropertyChanged();
                }
            }
        }
    }
}
