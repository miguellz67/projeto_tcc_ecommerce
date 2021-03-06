﻿using ECOM.Business.Interfaces;
using ECOM.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECOM.Business.Models;

namespace ECOM.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(InitialDbContext context) : base(context) { }


        public async Task<Product> ObterProdutoPorId(Guid id)
        {
            return await Db.Products.AsNoTracking().Include(p => p.Category)
                .Include(ap => ap.AssociatedProducts).ThenInclude(ap => ap.ProductSon).ThenInclude(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> ObterTodosProdutos()
        {
            return await Db.Products.AsNoTracking().Include(p => p.Category)
                .Include(ap => ap.AssociatedProducts).ThenInclude(ap => ap.ProductSon).ThenInclude(p => p.Category)
                .OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<IEnumerable<Product>> ObterProdutosPorCategoria(Guid categoryId)
        {
            return await Buscar(p => p.CategoryId == categoryId);
        }

        public async Task<List<Product>> ObterProdutosPorId(string ids)
        {
            var idsGuid = ids.Split(',')
                .Select(id => (Ok: Guid.TryParse(id, out var x), Value: x));

            if (!idsGuid.All(nid => nid.Ok)) return new List<Product>();

            var idsValue = idsGuid.Select(id => id.Value);

            return await Db.Products.AsNoTracking()
                .Where(p => idsValue.Contains(p.Id) && p.Active).ToListAsync();
        }
    }
}