using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;
using myProject.Data.Entities.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace myProject.Services.Products.Dtos
{
    [AutoMapTo(typeof(Product))]
    public class CreateProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }

    }
}
