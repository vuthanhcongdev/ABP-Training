using Abp.Application.Services;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using myProject.Data.Entities.Products;
using myProject.Services.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace myProject.Services.Products
{
    public class ProductAppService : ApplicationService
    {
        private readonly IRepository<Product> _productRepo;

        public ProductAppService(
            IRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<bool> CreateAsync(ProductDto productDto)
        {
            var product = ObjectMapper.Map<Product>(productDto);
            await _productRepo.InsertAsync(product);
            return true;
        }
    }
}