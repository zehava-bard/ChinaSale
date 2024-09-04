using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.DAL
{
    public class CategoryDal : ICategoryDal
    {
        private readonly Context Context;

        public CategoryDal(Context Context)
        {
            this.Context = Context;
        }
        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            return await Context.Category
                .ToListAsync();
        }
    }

          
        
}
