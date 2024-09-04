using Project.Models;

namespace Project.BLL
{
    public interface ICategoryService
    {

        public Task<IEnumerable<Category>> GetAllCategory();

    }
}
