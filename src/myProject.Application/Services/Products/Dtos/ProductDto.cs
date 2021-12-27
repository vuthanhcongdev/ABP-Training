using Abp.AutoMapper;
using myProject.Data.Entities.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace myProject.Services.Products.Dtos
{
    [AutoMapTo(typeof(Product))]
    public class ProductDto
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public string Image { get; set; }
    }
}