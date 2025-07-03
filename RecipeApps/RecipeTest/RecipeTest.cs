using RecipeSystem;
using System.Data;
using System.Windows.Forms;

namespace RecipeTest
{
    public class RecipeTest
    {
        [SetUp]
        public void Setup()
        {
            DBManager.SetConnectionString("Server=tcp:dev-mb.database.windows.net,1433;Initial Catalog=RecipeDB;Persist Security Info=False;User ID=devmbadmin;Password=HELlo111;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        [Test]
        [TestCase("test1", 800, "2020-01-01")]
        [TestCase("test2", 200, "2012-01-01")]
        public void InsertNewRecipe(string recipename, int calories, DateTime datedrafted)
        {
            DataTable dtfordelete = SQLUtility.GetDataTable("select * from recipe where recipename like 'test%'");
            if (dtfordelete.Rows.Count > 0)
            {
                Recipe.Delete(dtfordelete);
            }

            DataTable dt = SQLUtility.GetDataTable("select * from recipe where recipeid = 0");
            DataRow r = dt.Rows.Add();
            Assume.That(dt.Rows.Count == 1);
            int cuisineid = SQLUtility.GetFirstColumnFirstRowValue("select top 1 cuisineid from cuisine");
            Assume.That(cuisineid > 0, "no cuisines in the DB, cannot run test");
            int usernameid = SQLUtility.GetFirstColumnFirstRowValue("select top 1 usernameid from username");
            Assume.That(usernameid > 0, "no usernames in the DB, cannot run test");

            TestContext.WriteLine("insert recipe with recipename = " + recipename);

            r["recipename"] = recipename;
            r["calories"] = calories;
            r["datedrafted"] = datedrafted;
            r["cuisineid"] = cuisineid;
            r["usernameid"] = usernameid;
            Recipe.Save(dt);

            int newid = SQLUtility.GetFirstColumnFirstRowValue("select * from recipe where recipename = '" + recipename + "'");

            Assert.IsTrue(newid > 0, "recipe with " + recipename + " is not found in the DB");
            TestContext.WriteLine("recipe with recipename = " + recipename + ", is found in the DB with pk value of " + newid);
        }

        [Test]
        [TestCase("recipename", "changedname")]
        [TestCase("calories", "300")]
        public void ChangeExistingRecipe(string column, string newvalue)
        {
            DataTable dt = SQLUtility.GetDataTable("select top 1 * from recipe");
            int recipeid = (int)dt.Rows[0]["recipeid"];
            Assume.That(recipeid > 0, "no recipes in DB, cannot run tests");
            TestContext.WriteLine("updating " + column + " from " + dt.Rows[0][column].ToString() + " to " + newvalue + " for recipe with an id of " + recipeid);

            dt.Rows[0][column] = newvalue;
            Recipe.Save(dt);

            DataTable dtnew = SQLUtility.GetDataTable("select " + column + " from recipe where recipeid = " + recipeid);
            string insertedvalue = dtnew.Rows[0][column].ToString();
            Assert.IsTrue(insertedvalue == newvalue, column + " was updated to " + insertedvalue + " instead of " + newvalue + " for recipe with an id of " + recipeid);
            TestContext.WriteLine(column + " now is " + newvalue);
        }

        [Test]
        public void ChangeExistingRecipeToBlankRecipeName()
        {
            DataTable dt = SQLUtility.GetDataTable("select top 1 * from recipe");
            int recipeid = (int)dt.Rows[0]["recipeid"];
            Assume.That(recipeid > 0, "no recipes in DB, cannot run tests");
            TestContext.WriteLine("updating the recipename from recipe " + recipeid + " to blank");

            dt.Rows[0]["recipename"] = "";
            Exception ex = Assert.Throws<Exception>(() => Recipe.Save(dt));
            TestContext.WriteLine(ex.Message);
        }

        [Test]
        public void ChangeExistingRecipeToInvalidRecipeName()
        {
            DataTable dt = SQLUtility.GetDataTable("select top 1 * from recipe");
            string currentrecipename = dt.Rows[0]["recipename"].ToString();
            string recipename = GetFirstColumnFirstRowString("select top 1 recipename from recipe");
            Assume.That(currentrecipename != "", "no recipes in DB, cannot run tests");
            TestContext.WriteLine("updating the recipename from recipe " + currentrecipename + " to " + recipename);

            dt.Rows[0]["recipename"] = recipename;
            Exception ex = Assert.Throws<Exception>(() => Recipe.Save(dt));
            TestContext.WriteLine(ex.Message);
        }

        [Test]
        public void DeleteRecipe()
        {
            DataTable dt = SQLUtility.GetDataTable(@"select * from recipe r
                left join recipemealcourse rmc
                on rmc.recipeid = r.recipeid
                left join cookbookrecipe cr 
                on cr.recipeid = r.recipeid
                where rmc.recipemealcourseid is null 
                    and cr.cookbookrecipeid is null
                    and (r.recipestatus = 'draft'
                        or DATEDIFF(DAY, r.datearchived, GETDATE()) >= 30)");
            Assume.That(dt.Rows.Count > 0, "no recipes without related records, cannot run test");
            int recipeid = (int)dt.Rows[0]["recipeid"];
            string recipedesc = dt.Rows[0]["recipename"].ToString();
            TestContext.WriteLine(recipedesc + " is an existing recipe with id of " + recipeid);
            TestContext.WriteLine("ensure that app will delete this recipe");

            Recipe.Delete(dt);
            DataTable dtafterdelete = SQLUtility.GetDataTable("select * from recipe where recipeid = " + recipeid);

            Assert.IsTrue(dtafterdelete.Rows.Count == 0, "record with recipeid " + recipeid + " still exists in DB");
            TestContext.WriteLine("record with recipeid " + recipeid + " does not exists in DB anymore");
        }

        [Test]
        public void DeleteRecipeThatHasRelatedRecords()
        {
            DataTable dt = SQLUtility.GetDataTable(@"select * 
                from recipe r
                left join RecipeMealCourse rmc 
                on r.RecipeID = rmc.RecipeID 
                left join CookbookRecipe cr 
                on cr.RecipeID = r.RecipeID
                where (rmc.RecipeMealCourseID is not null 
                	or cr.CookbookRecipeID is null)
                	and (r.recipestatus = 'draft' or DATEDIFF(DAY, r.datearchived, GETDATE()) >= 30)");

            Assume.That(dt.Rows.Count > 0, "no recipes with related records, cannot run test");
            int recipeid = (int)dt.Rows[0]["recipeid"];
            string recipedesc = dt.Rows[0]["recipename"].ToString();
            TestContext.WriteLine("ensure that app cannot delete " + recipedesc);

            Exception ex = Assert.Throws<Exception>(() => Recipe.Delete(dt));
            TestContext.WriteLine(ex.Message);
        }

        [Test]
        public void DeleteRecipeThatIsNotDraftedAndRecentlyArchived()
        {
            DataTable dt = SQLUtility.GetDataTable(@"select top 1
                r.recipeid,
                r.recipename
                from recipe r
                where r.recipestatus <> 'draft'
                and (r.datearchived is null or DATEDIFF(DAY, r.datearchived, GETDATE()) < 30)");
               
            Assume.That(dt.Rows.Count > 0, "no recipes that are not drafted and recently archive, cannot run test");
            int recipeid = (int)dt.Rows[0]["recipeid"];
            string recipedesc = dt.Rows[0]["recipename"].ToString();
            TestContext.WriteLine("ensure that app cannot delete " + recipedesc);

            Exception ex = Assert.Throws<Exception>(() => Recipe.Delete(dt));
            TestContext.WriteLine(ex.Message);
        }

        [Test]
        public void LoadRecipe()
        {
            int recipeid = GetRandomExistingRecipeID();
            Assume.That(recipeid > 0, "no recipes in DB, cannot run test");
            TestContext.WriteLine("existing recipe with id of " + recipeid);
            TestContext.WriteLine("ensure that app loads recipe with id of " + recipeid);

            DataTable dt = Recipe.LoadRecipe(recipeid);
            int loadedid = (int)dt.Rows[0]["RecipeID"];

            Assert.That(loadedid == recipeid, "the recipe that loaded did not match the recipeid, " + loadedid + " <> " + recipeid);
            TestContext.WriteLine("loaded president with an id of " + loadedid);
        }

        [Test]
        [TestCase("username")]
        [TestCase("cuisine")]
        public void GetLists(string listof)
        {
            int countlist = SQLUtility.GetFirstColumnFirstRowValue("select total = count(*) from " + listof);
            Assume.That(countlist > 0, "no " + listof + "s in DB, can't test");
            TestContext.WriteLine(countlist + " = num of " + listof + "s in DB");
            TestContext.WriteLine("ensure that num of rows returned by app matches " + countlist);

            DataTable dtlist = new();
            switch (listof)
            {
                case "username":
                    dtlist = Recipe.GetUserNameList();
                    break;
                case "cuisine":
                    dtlist = Recipe.GetCuisineList();
                    break;
            }

            Assert.IsTrue(dtlist.Rows.Count == countlist, "number of rows returned by app is " + dtlist.Rows.Count + ") <> " + countlist);
            TestContext.WriteLine("app returned " + dtlist.Rows.Count + " rows");
        }

        [Test]
        public void SearchRecipe()
        {
            string criteria = "t";
            int numrecipes = SQLUtility.GetFirstColumnFirstRowValue("select total = count(*) from recipe where recipename like '%" + criteria + "%'");
            Assume.That(numrecipes > 0, "there are no recipes that match the search for " + criteria);
            TestContext.WriteLine(numrecipes + " recipes that match " + criteria);
            TestContext.WriteLine("ensure that recipe search returns " + numrecipes + "rows");

            DataTable dt = Recipe.SearchRecipe(criteria);
            int results = dt.Rows.Count;
            Assert.IsTrue(results == numrecipes, "results of recipes search does not match number of recipe " + results + " <> " + numrecipes);
            TestContext.WriteLine("number of rows returned by recipes search is " + results);
        }

        private int GetRandomExistingRecipeID()
        {
            return SQLUtility.GetFirstColumnFirstRowValue("select top 1 recipeid from recipe");
        }

        public static string GetFirstColumnFirstRowString(string sql)
        {
            string s = "";
            DataTable dt = SQLUtility.GetDataTable(sql);
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