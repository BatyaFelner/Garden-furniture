using Dal.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Company:IDal.ICompanyDal
    {
        PatioFurnitureContext db;
        public Company(PatioFurnitureContext db)
        {
            this.db = db;
        }

        public async Task<List<Dto.Company>> GetAllAsync()
        {
            var list = await db.Companies.ToListAsync();
            return converters.company.ToListCategoryDto(list);
        }

    }
}
