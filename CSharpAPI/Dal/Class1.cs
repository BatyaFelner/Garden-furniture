using Dal.models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Dal
{
    public class catfunc : IDal.ICategoryDal

    {
        PatioFurnitureContext db;
        public catfunc(PatioFurnitureContext db)
        {
            this.db = db;
        }

        public async Task<List<Dto.Category>> GetAllAsync()
        {
            var list = await db.Categories.ToListAsync();
            return converters.category.ToListCategoryDto(list);
        }

        /*public async Task<List<Dto.Category>> GetCategoryAsync()
        {
            var list = await db.Categories.ToListAsync();
            return converters.category.ToListCategoryDto(list);


        }*/
    }
}