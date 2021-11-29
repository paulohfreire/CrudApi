﻿using CrudApi.Domain.Entities;
using CrudApi.Domain.Interfaces;
using CrudApi.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudApi.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        ApplicationDbContext _productContext;
        public  ProductRepository(ApplicationDbContext context)
        {
            _productContext = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _productContext.Add(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}