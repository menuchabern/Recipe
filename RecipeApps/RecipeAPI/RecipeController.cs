using Microsoft.AspNetCore.Mvc;
using RecipeSystem;

namespace RecipeAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        [HttpGet]
        public List<bizRecipe> Get()
        {
            return new bizRecipe().GetList();
        }

        [HttpGet("getbyid/{recipeid:int:min(1)}")]
        public bizRecipe GetById(int recipeid)
        {
            bizRecipe r = new bizRecipe();
            r.Load(recipeid);
            return r;
        }
    }
}
