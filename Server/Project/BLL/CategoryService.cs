using AutoMapper;
using Project.DAL;
using Project.Models;

namespace Project.BLL
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryDal categoryDal;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryDal categoryDal, IMapper mapper)
        {
            this.categoryDal = categoryDal;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            return await (categoryDal.GetAllCategory());
        }



    }
}
