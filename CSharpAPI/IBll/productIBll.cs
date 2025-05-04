using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBll
{
    public interface productIBll : IBll<Dto.Product>
    {
        Task<List<Dto.Product>> GetProductsByCategoryIdAsync(int categoryId);
        Task<Dto.Product> GetByIdAsync(int Id);
        Task<List<Dto.Product>> filterAsync(int? CodeCat = 0, int? minPrice = 0, int? maxprice = 0, int? codeComp = 0);
        //Task<List<Dto.Category>> GetProductAsync();
        Task<List<Dto.Product>> selectNewasAsync();
    }
}
