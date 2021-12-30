using Abp.Application.Services.Dto;
using myProject.PagingModel;
using myProject.Services.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace myProject.Services.Products
{
    public interface IProductAppService
    {
        Task<PagedResultDto<ProductDto>> GetAllProductPaging(GetProductPagingRequest request);

        //Task<ProductDto> GetProductById(int productId);


    }
}
