using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSystem
{
    public class bizCookbook :bizObject<bizCookbook>
    {
        public bizCookbook() { }

        private int _cookbookId;
        private int _userNameId;
        private string _cookbookName;
        private decimal _price;
        private bool _activeStatus;
        private DateTime _dateCreated;
        private string _pictureName;
        private int _skill;
        private string _skillDesc;
        private string _author;
        private int _numRecipes;

        public List<bizCookbook> Search(string cookbookval)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand(this.GetSprocName);
            SQLUtility.SetParamValue(cmd, "CookbookName", cookbookval);
            DataTable dt = SQLUtility.GetDataTable(cmd);
            return this.GetListFromDataTable(dt);
        }

        public int CookbookId
        {
            get { return _cookbookId; }
            set
            {
                if (_cookbookId != value)
                {
                    _cookbookId = value;
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

        public string CookbookName
        {
            get { return _cookbookName; }
            set
            {
                if (_cookbookName != value)
                {
                    _cookbookName = value;
                    InvokePropertyChanged();
                }
            }
        }

        public decimal Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    InvokePropertyChanged();
                }
            }
        }

        public bool ActiveStatus
        {
            get { return _activeStatus; }
            set
            {
                if (_activeStatus != value)
                {
                    _activeStatus = value;
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

        public int Skill
        {
            get { return _skill; }
            set
            {
                if (_skill != value)
                {
                    _skill = value;
                    InvokePropertyChanged();
                }
            }
        }

        public string SkillDesc
        {
            get { return _skillDesc; }
            set
            {
                if (_skillDesc != value)
                {
                    _skillDesc = value;
                    InvokePropertyChanged();
                }
            }
        }

        public string Author
        {
            get { return _author; }
            set
            {
                if (_author != value)
                {
                    _author = value;
                    InvokePropertyChanged();
                }
            }
        }

        public int NumRecipes
        {
            get { return _numRecipes; }
            set
            {
                if (_numRecipes != value)
                {
                    _numRecipes = value;
                    InvokePropertyChanged();
                }
            }
        }
    }
}
