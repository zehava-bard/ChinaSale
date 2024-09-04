using Project.Models;

namespace Project.DAL
{
    public interface ICategoryDal
    {
        public Task<IEnumerable<Category>> GetAllCategory();

    }
}
