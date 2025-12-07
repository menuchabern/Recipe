namespace RecipeSystem
{
    public class bizIngredient: bizObject<bizIngredient>
    {
        private int _ingredientId;
        private string _ingredientname = "";

        public List<bizIngredient> Search(string ingredientval)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand(this.GetSprocName);
            SQLUtility.SetParamValue(cmd, "IngredientName", ingredientval);
            DataTable dt = SQLUtility.GetDataTable(cmd);
            return this.GetListFromDataTable(dt);
        }

        public int IngredientId
        {
            get { return _ingredientId; }
            set
            {
                if (_ingredientId != value)
                {
                    _ingredientId = value;
                    InvokePropertyChanged();
                }
            }
        }

        public string IngredientName
        {
            get { return _ingredientname; }
            set
            {
                if (_ingredientname != value)
                {
                    _ingredientname = value;
                    InvokePropertyChanged();
                }
            }
        }
    }
}
