using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
       private ICategoryService _categoryservice;

        public CategoriesController(ICategoryService categoryservice)
        {
            _categoryservice = categoryservice;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _categoryservice.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
