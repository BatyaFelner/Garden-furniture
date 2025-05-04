using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBll
{

        public interface buyIBll : IBll<Dto.Buy>
        {

        Task<Dto.Buy> addbuyAsync(Dto.Buy buy);
        Task<Dictionary<string, int>> SaveBUy(int id);
        Task<List<Dto.Buy>> GetByIdcleinAsync(string id);
        //Task<List<Dto.Category>> GetCategoryAsync();



    }
    }

