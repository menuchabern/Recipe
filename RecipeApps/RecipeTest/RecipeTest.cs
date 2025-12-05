using System.Configuration;
using System.Data;

namespace RecipeTest
{
    public class RecipeTest
    {
        //string connstring = ConfigurationManager.ConnectionStrings["devconn"].ConnectionString;
        string testconnstring = ConfigurationManager.ConnectionStrings["liveconn"].ConnectionString;
        [SetUp]
        public void Setup()
        {
            DBManager.SetConnectionString(testconnstring, true);
        }

        private DataTable GetDataTable(string sql)
        {
            DataTable dt = new();
            DBManager.SetConnectionString(testconnstring, false);
            dt = SQLUtility.GetDataTable(sql);
           // DBManager.SetConnectionString(connstring, false);
            return dt;
        }

        private int GetFirstColumnFirstRowValue(string sql)
        {
            int n = 0;
            DBManager.SetConnectionString(testconnstring, false);
            n = SQLUtility.GetFirstColumnFirstRowValue(sql);
            //DBManager.SetConnectionString(connstring, false);
            return n;
        }

        private DataTable GetList(string sprocname)
        {
            DBManager.SetConnectionString(testconnstring, false);
            DataTable dt = SQLUtility.GetList(sprocname);
            //DBManager.SetConnectionString(connstring, false);
            return dt;
        }

        private void ExecuteSQL(string sql)
        {
            DBManager.SetConnectionString(testconnstring, false);
            SQLUtility.ExecuteSQL(sql);
            //DBManager.SetConnectionString(connstring, false);
        }

        [Test]
        [TestCase("test1", 800, "2020-01-01")]
        [TestCase("test2", 200, "2012-01-01")]
        public void InsertNewRecipe(string recipename, int calories, DateTime datedrafted)
        {
            //DateOnly datedrafted = DateOnly.Parse(_datedrafted);
            DataTable dtfordelete = GetDataTable("select * from recipe where recipename like 'test%'");
            if (dtfordelete.Rows.Count > 0)
            {
                bizRecipe deleterecipe = new();
                deleterecipe.Delete(dtfordelete);
            }

            int cuisineid = GetFirstColumnFirstRowValue("select top 1 cuisineid from cuisine");
            Assume.That(cuisineid > 0, "no cuisines in the DB, cannot run test");
            int usernameid = GetFirstColumnFirstRowValue("select top 1 usernameid from username");
            Assume.That(usernameid > 0, "no usernames in the DB, cannot run test");
            TestContext.WriteLine("insert recipe with recipename = " + recipename);

            bizRecipe recipe = new();
            recipe.RecipeName = recipename;
            recipe.Calories = calories;
            recipe.DateDrafted = datedrafted;
            recipe.CuisineId = cuisineid;
            recipe.UserNameId = usernameid;
            recipe.Save();

            int newid = GetFirstColumnFirstRowValue("select * from recipe where recipename = '" + recipename + "'");
            Assert.IsTrue(newid > 0, "recipe with " + recipename + " is not found in the DB");
            TestContext.WriteLine("recipe with recipename = " + recipename + ", is found in the DB with pk value of " + newid);
        }

        [Test]
        [TestCase("changedname")]
        [TestCase("differentname")]
        public void ChangeExistingRecipe(string newvalue)
        {
            int recipeid = GetRandomExistingRecipeID();
            bizRecipe recipe = new();
            recipe.Load(recipeid);
            string oldvalue = recipe.RecipeName;
            Assume.That(recipeid > 0, "no recipes in DB, cannot run tests");
            TestContext.WriteLine($"updating recipename from {recipe.RecipeName} to {newvalue} for recipe with an id of {recipe.RecipeId}");
            newvalue = newvalue + DateTime.Now.ToString();
            recipe.RecipeName = newvalue;
            recipe.Save();

            string insertedvalue = recipe.RecipeName;
            Assert.IsTrue(insertedvalue == newvalue, "recipe name was updated to " + insertedvalue + " from " + oldvalue + " for recipe with an id of " + recipeid);
            TestContext.WriteLine("recipename now is " + newvalue);
        }

        [Test]
        public void ChangeExistingRecipeToBlankRecipeName()
        {
            int recipeid = GetRandomExistingRecipeID();
            bizRecipe recipe = new();
            recipe.Load(recipeid);
            Assume.That(recipeid > 0, "no recipes in DB, cannot run tests");
            TestContext.WriteLine($"updating the recipename from recipe with and id of {recipe.RecipeId} from {recipe.RecipeName} to blank");
            recipe.RecipeName = "";
            Exception ex = Assert.Throws<Exception>(recipe.Save);
            TestContext.WriteLine(ex.Message);
        }

        [Test]
        public void ChangeExistingRecipeToInvalidRecipeName()
        {
            int recipeid = GetRandomExistingRecipeID();
            bizRecipe recipe = new();
            recipe.Load(recipeid);
            string currentrecipename = recipe.RecipeName;

            string recipename = GetFirstColumnFirstRowString($"select top 1 recipename from recipe where recipename <> '{currentrecipename}'");
            Assume.That(currentrecipename != "", "no recipes in DB, cannot run tests");
            TestContext.WriteLine("updating the recipename from recipe " + currentrecipename + " to " + recipename);
            recipe.RecipeName = recipename;
            Exception ex = Assert.Throws<Exception>(recipe.Save);
            TestContext.WriteLine(ex.Message);
        }

        [Test]
        public void DeleteRecipe()
        {
            DataTable dt = GetDataTable(@"select * from recipe r
                where r.recipestatus = 'draft'
                or DATEDIFF(DAY, r.datearchived, GETDATE()) >= 30");
            Assume.That(dt.Rows.Count > 0, "no recipes that can be deleted, cannot run test");
            int recipeid = (int)dt.Rows[0]["recipeid"];
            string recipedesc = dt.Rows[0]["recipename"].ToString();
            TestContext.WriteLine(recipedesc + " is an existing recipe with id of " + recipeid);
            TestContext.WriteLine("ensure that app will delete this recipe");

            bizRecipe recipe = new();
            recipe.Load(recipeid);
            recipe.Delete();

            DataTable dtafterdelete = GetDataTable("select * from recipe where recipeid = " + recipeid);
            Assert.IsTrue(dtafterdelete.Rows.Count == 0, "record with recipeid " + recipeid + " still exists in DB");
            TestContext.WriteLine("record with recipeid " + recipeid + " does not exists in DB anymore");
        }

        [Test]
        public void DeleteRecipeThatHasRelatedRecords()
        {
            int recipeid = GetFirstColumnFirstRowValue(@"select top 1 r.recipeid 
                    from recipe r
                    join RecipeMealCourse rmc 
                    on r.RecipeID = rmc.RecipeID 
                    join CookbookRecipe cr 
                    on cr.RecipeID = r.RecipeID
                    where (r.recipestatus = 'draft' or DATEDIFF(DAY, r.datearchived, GETDATE()) >= 30)");

            Assume.That(!Convert.IsDBNull(recipeid), "no recipes with related records, cannot run test");
            string recipedesc = GetFirstColumnFirstRowString(@"select top 1 r.recipename 
                    from recipe r
                    join RecipeMealCourse rmc 
                    on r.RecipeID = rmc.RecipeID 
                    join CookbookRecipe cr 
                    on cr.RecipeID = r.RecipeID
                    where (r.recipestatus = 'draft' or DATEDIFF(DAY, r.datearchived, GETDATE()) >= 30)");
            TestContext.WriteLine("ensure that app cannot delete " + recipedesc);

            Exception ex = Assert.Throws<Exception>(() => ExecuteSQL("delete recipe where recipeid = " + recipeid));
            TestContext.WriteLine(ex.Message);
        }

        [Test]
        public void DeleteRecipeThatIsNotDraftedAndRecentlyArchived()
        {
            DataTable dt = GetDataTable(@"select top 1
                r.recipeid,
                r.recipename
                from recipe r
                where r.recipestatus <> 'draft'
                and (r.datearchived is null or DATEDIFF(DAY, r.datearchived, GETDATE()) < 30)");

            Assume.That(dt.Rows.Count > 0, "no recipes that are not drafted and recently archive, cannot run test");
            int recipeid = (int)dt.Rows[0]["recipeid"];
            string recipedesc = dt.Rows[0]["recipename"].ToString();
            TestContext.WriteLine("ensure that app cannot delete " + recipedesc);

            bizRecipe recipe = new();
            Exception ex = Assert.Throws<Exception>(() => recipe.Delete(dt));
            TestContext.WriteLine(ex.Message);
        }

        [Test]
        public void LoadRecipe()
        {
            int recipeid = GetRandomExistingRecipeID();
            Assume.That(recipeid > 0, "no recipes in DB, cannot run test");
            TestContext.WriteLine("existing recipe with id of " + recipeid);
            TestContext.WriteLine("ensure that app loads recipe with id of " + recipeid);

            bizRecipe recipe = new();
            recipe.Load(recipeid);
            int loadedid = recipe.RecipeId;
            string recipename = recipe.RecipeName;
            Assert.That(loadedid == recipeid, "the recipe that loaded did not match the recipeid, " + loadedid + " <> " + recipeid);
            TestContext.WriteLine($"loaded {recipename} with an id of {loadedid}");
        }

        [Test]
        [TestCase("username")]
        [TestCase("cuisine")]
        public void GetLists(string listof)
        {
            int countlist = GetFirstColumnFirstRowValue("select total = count(*) from " + listof);
            Assume.That(countlist > 0, "no " + listof + "s in DB, can't test");
            TestContext.WriteLine(countlist + " = num of " + listof + "s in DB");
            TestContext.WriteLine("ensure that num of rows returned by app matches " + countlist);

            DataTable dtlist = new();
            switch (listof)
            {
                case "username":
                    dtlist = GetList("UserNameGet");
                    break;
                case "cuisine":
                    dtlist = GetList("CuisineGet");
                    break;
            }

            Assert.IsTrue(dtlist.Rows.Count == countlist, "number of rows returned by app is " + dtlist.Rows.Count + ") <> " + countlist);
            TestContext.WriteLine("app returned " + dtlist.Rows.Count + " rows");
        }

        [Test]
        public void SearchRecipe()
        {
            int numrecipes = GetFirstColumnFirstRowValue("select total = count(*) from recipe");
            Assume.That(numrecipes > 0, "there are no recipes in DB");
            TestContext.WriteLine(numrecipes + " recipes");
            TestContext.WriteLine("ensure that recipe search returns " + numrecipes + "rows");

            DataTable dt = Recipe.SearchRecipe();
            int results = dt.Rows.Count;
            Assert.IsTrue(results == numrecipes, "results of recipes search does not match number of recipe " + results + " <> " + numrecipes);
            TestContext.WriteLine("number of rows returned by recipes search is " + results);
        }

        private int GetRandomExistingRecipeID()
        {
            return GetFirstColumnFirstRowValue("select top 1 recipeid from recipe");
        }

        public string GetFirstColumnFirstRowString(string sql)
        {
            string s = "";
            DataTable dt = GetDataTable(sql);
            if (dt.Rows.Count > 0 && dt.Columns.Count > 0)
            {
                if (dt.Rows[0][0] != DBNull.Value)
                {
                    s = dt.Rows[0][0].ToString();
                }
            }
            return s;
        }
    }
}