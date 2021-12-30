using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myProject.Authorization;
using myProject.Common;
using myProject.Data.Entities.Products;
using myProject.EntityFrameworkCore;
using myProject.PagingModel;
using myProject.Services.Products.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace myProject.Services.Products
{
    [AbpAuthorize(PermissionNames.Pages_Products)]
    public class ProductAppService : ApplicationService, IProductAppService
    {
        private readonly IRepository<Product, int> _productRepository;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        public ProductAppService(IRepository<Product, int> productRepository, IStorageService storageService)
        {
            _productRepository = productRepository;
            _storageService = storageService;
        }

        public async Task<Product> CreateAsync(CreateProductDto input)
        {
            var product = new Product();
            product.Name = input.Name;
            product.Description = input.Description;
            product.Price = input.Price;
            product.Quantity = input.Quantity;
            product.ImagePath = input.Image;

            _productRepository.Insert(product);

            return product;
        }

        public async Task<ProductDto> GetById(int productId)
        {
            var product = await _productRepository.GetAsync(productId);
            if(product == null)
            {
                return null;
            }
            var productDto = new ProductDto()
            {
                Name = product.Name,
                Quantity = product.Quantity,
                ImagePath = product.ImagePath,
                Description = product.Description,
                Price = product.Price,
            };
            return productDto;
        }

        public async Task<UpdateProductDto> UpdateAsync(int productId, [FromBody]UpdateProductDto input)
        {
            if(input == null)
            {
                return null;
            }
            var product = await _productRepository.GetAsync(productId);
            if(product == null)
            {
                return null;
            }
            product.Name = input.Name;
            product.Description=input.Description;
            product.Quantity=input.Quantity;
            product.Price=input.Price;
            product.ImagePath = input.ImagePath != null ? input.ImagePath : "no-img.jpg";
            return input;
        }

        public async Task DeleteAsync(int productId)
        {
            var product = await _productRepository.GetAsync(productId);
            if(product != null)
            {
                await _productRepository.DeleteAsync(product);
            }
        }

        [HttpPost]
        public async Task<PagedResultDto<ProductDto>> GetAllProductPaging(GetProductPagingRequest request)
        {
            var query = _productRepository.GetAll();
            var totalRecord = query.Count();
            var abc = query.Skip(1).Take(request.MaxResultCount);
            var data = query.Skip(request.SkipCount).Take(request.MaxResultCount).Select(x => new ProductDto()
            {
                Name = x.Name,
                Quantity = x.Quantity,
                ImagePath = x.ImagePath,

            }).ToList();

            var pageResult = new PagedResultDto<ProductDto>() { 
                TotalCount = totalRecord,
                Items = data,
            };

            return pageResult;
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }
    }
}   