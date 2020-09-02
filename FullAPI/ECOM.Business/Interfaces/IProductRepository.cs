﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ECOM.API.Models;

namespace ECOM.Business.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> ObterProdutoPorId(Guid id);
        Task<IEnumerable<Product>> ObterProdutos();
        Task<IEnumerable<Product>> ObterProdutosPorCategoria(Guid categoryId);
    }
}
