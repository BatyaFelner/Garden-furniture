using Dto;
using IBll;

namespace Bll
{
    public class funcCategory : CategoryIBll
    {
        public IDal.ICategoryDal delc;

        public funcCategory(IDal.ICategoryDal c)
        {
            this.delc = c;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await delc.GetAllAsync();
        }

        public async Task<List<Dto.Category>> GetCategoryAsync()
        {
            return await delc.GetAllAsync();
        }

    }
}