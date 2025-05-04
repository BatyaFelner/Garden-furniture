using Dto;
using IBll;
using IDal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bll
{
    public class FuncProducts : productIBll
    {
        public IDal.IProductDal delp;

        public FuncProducts(IDal.IProductDal p)
        {
            this.delp = p;
        }

        public async Task<List<Dto.Product>> GetProductsByCategoryIdAsync(int categoryId)
        {
            return await delp.GetProductsByCategoryAsync(categoryId);
        }

          public async Task<List<Dto.Product>> filterAsync(int? CodeCat = 0, int? minPrice = 0, int? maxprice = 0, int? codeComp = 0)
        {
            return await delp.filterAsync(CodeCat,minPrice , maxprice, codeComp);
        }
        public async Task<Dto.Product> GetByIdAsync(int Id)
        {
            return await delp.GetByIdAsync(Id);
        }
        public async Task<List<Dto.Product>> selectNewasAsync()

        {
            return await delp.selectNewasAsync();

        }


        public async Task<List<Dto.Product>> GetAllAsync()
        {
            return await delp.GetAllAsync();
        }
    }
}
