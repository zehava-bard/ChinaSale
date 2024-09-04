using Microsoft.AspNetCore.Mvc;
using Project.BLL;
using Project.Models.DTO;
using Project.Models;
using Project.DAL;

namespace Project.Controllers
{ 
    [ApiController]
    [Route("[controller]")]
    public class CategoryController:ControllerBase
    {
        private readonly ICategoryService _categoryDal;
        public CategoryController(ICategoryService category)
        {
            this._categoryDal = category;
        }

        [HttpGet("getAllCategories")]
        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            return await _categoryDal.GetAllCategory();
        }


    }
}



 