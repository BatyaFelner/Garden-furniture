using Dal.models;
using Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class prodfunc : IDal.IProductDal
    {
        PatioFurnitureContext db;
        public prodfunc(PatioFurnitureContext db)
        {
            this.db = db;
        }
        public async Task<List<Dto.Product>> GetProductsByCategoryAsync(int categoryId)
        {
            var products = await db.Products
            .Where(p => p.CodeCat == categoryId)
            .Include(p => p.CodeCatNavigation)
            .Include(p => p.CodeComNavigation)
            .ToListAsync();

            return converters.ProductConverter.ToListProductDto(products);
        }
        public async Task<List<Dto.Product>> filterAsync(int? CodeCat = 0, int? minPrice = 0, int? maxprice = 0, int? codeComp = 0)
        {



            var products = await db.Products.Include(p => p.CodeCatNavigation).Include(p => p.CodeComNavigation)
                .Where(p => CodeCat == 0 || p.CodeCat == CodeCat)
                .Where(p => codeComp == 0 || p.CodeCom == codeComp)
                .Where(p => maxprice == 0 && minPrice == 0 || minPrice == 0 && p.Price < maxprice || maxprice == 0 && p.Price > minPrice
                || minPrice != 0 && maxprice != 0 && p.Price > minPrice && p.Price < maxprice).ToListAsync();

            return converters.ProductConverter.ToListProductDto(products);


        }

        /*  public async Task<List<Dto.Product>> GetProductsByCcompenyAsync(int compenyId)
          {
              var products = await db.Products
              .Where(p => p.CodeCom == compenyId)
              .Include(p => p.CodeCatNavigation)
              .Include(p => p.CodeComNavigation)
              .ToListAsync();

              return converters.ProductConverter.ToListProductDto(products);
          }*/
        /*public async Task<List<Dto.Product>> GetAllAsync()
        {
            var list = await db.Products.Include(p => p.CodeCatNavigation)
            .Include(p => p.CodeComNavigation)
            .ToListAsync();

            return converters.productcovverter.toListDtoProd();


        }
        */
        public async Task<List<Dto.Product>> GetProductAsync()
        {
            var list = await db.Products.Include(p => p.CodeCatNavigation)
            .Include(p => p.CodeComNavigation)
            .ToListAsync();

            return converters.productcoverter.toListDtoProd(list);
        }

        public async Task<List<Dto.Product>> GetAllAsync()
        {
            var list = await db.Products.Include(p => p.CodeCatNavigation)
            .Include(p => p.CodeComNavigation).Skip(17).Take(30)

            .ToListAsync();

            return converters.productcoverter.toListDtoProd(list);
        }
        public async Task<List<Dto.Product>> selectNewasAsync()
        {
         
            var purchaseDetails = await db.PurchaseDetails
                .Include(x => x.CodeProdNavigation)
                    .ThenInclude(p => p.CodeCatNavigation)
                .Include(x => x.CodeProdNavigation)
                    .ThenInclude(p => p.CodeComNavigation)
                .ToListAsync();

            var Products = purchaseDetails
                .GroupBy(x => x.CodeProdNavigation)
                .Select(x => new { Product = x.Key, Count = x.Count() })
                .OrderByDescending(x => x.Count)
                .Take(4)
                .Select(x => x.Product)
                .ToList();

            return converters.productcoverter.toListDtoProd(Products);
        }

        public async Task<Dto.Product> GetByIdAsync(int Id)
        {

            var product = await db.Products
                .Include(p => p.CodeCatNavigation)
                .Include(p => p.CodeComNavigation)
               .FirstOrDefaultAsync(p => p.Id == Id);


            return converters.ProductConverter.ToDtoProduct(product);
        }


    }
}
