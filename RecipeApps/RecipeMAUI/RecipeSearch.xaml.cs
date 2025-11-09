using RecipeSystem;
using System.Data;

namespace RecipeMAUI;

public partial class RecipeSearch : ContentPage
{
	public RecipeSearch()
	{
		InitializeComponent();
		SearchBtn.Clicked += SearchBtn_Clicked;

    }

	private void SearchRecipe()
	{
		DataTable dt = Recipe.SearchRecipe();
		RecipeLst.ItemsSource = dt.Rows;
	}

    private void SearchBtn_Clicked(object sender, EventArgs e)
    {
		SearchRecipe();
    }
}