using System.Data;

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
            if (dtfordelete.Rows.Count >= 0)
            {
                Recipe.Delete(dtfordelete);
            }

            DataTable dt = SQLUtility.GetDataTable("select * from recipe where recipeid = 0");
            DataRow r = dt.Rows.Add();
            Assume.That(dt.Rows.Count == 1);
            int cuisineid = SQLUtility.GetFirstColumnFirstRowValue("select top 1 cuisineid from cuisine");
            Assume.That(cuisineid > 0 , "no cuisines in the DB, cannot run test");
            int usernameid = SQLUtility.GetFirstColumnFirstRowValue("select top 1 usernameid from username");
            Assume.That(usernameid > 0, "no usernames in the DB, cannot run test");

            TestContext.WriteLine("insert recipe with recipename = " + recipename);

            r["recipename"] = recipename;
            r["calories"] = calories;
            r["datedrafted"] = datedrafted;
            r["cuisineid"] = cuisineid;
            r["usernameid"] = usernameid;
            Recipe.Save(dt);

            int newid = SQLUtility.GetFirstColumnFirstRowValue("select * from recipe where recipename = '" + recipename +"'");

            Assert.IsTrue(newid > 0, "recipe with " + recipename + " is not found in the DB");
            TestContext.WriteLine("recipe with recipename = " + recipename + ", is found in the DB with pk value of " + newid);
        }

        [Test]
        [TestCase("recipename", "Test")]
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
        public void DeleteRecipe()
        {
            DataTable dt = SQLUtility.GetDataTable("select top 1 r.recipeid, r.recipename from recipe r");
            int recipeid = (int)dt.Rows[0]["recipeid"];
            string recipedesc = dt.Rows[0]["recipename"].ToString();
            Assume.That(recipeid > 0, "no recipes in DB can't run test");
            TestContext.WriteLine(recipedesc + " is an existing recipe with id of " + recipeid);
            TestContext.WriteLine("ensure that app will delete this recipe");

            Recipe.Delete(dt);
            DataTable dtafterdelete = SQLUtility.GetDataTable("select * from recipe where recipeid = " + recipeid);

            Assert.IsTrue(dtafterdelete.Rows.Count == 0, "record with recipeid " + recipeid + " still exists in DB");
            TestContext.WriteLine("record with recipeid " + recipeid + " does not exists in DB anymore");
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

        private int GetRandomExistingRecipeID()
        {
            return SQLUtility.GetFirstColumnFirstRowValue("select top 1 recipeid from recipe");
        }
    }
}