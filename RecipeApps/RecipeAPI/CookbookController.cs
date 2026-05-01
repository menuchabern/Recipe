using Microsoft.AspNetCore.Mvc;
using RecipeSystem;

namespace RecipeAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookbookController : ControllerBase
    {
        [HttpGet]
        public List<bizCookbook> Get()
        {
            return new bizCookbook().GetList();
        }

        [HttpGet("getbyid/{cookbookid:int:min(1)}")]
        public bizCookbook GetById(int cookbookid)
        {
            bizCookbook c = new bizCookbook();
            c.Load(cookbookid);
            return c;
        }
    }
}
