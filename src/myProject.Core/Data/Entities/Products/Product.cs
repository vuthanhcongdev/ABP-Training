using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace myProject.Data.Entities.Products
{
    public class Product : FullAuditedEntity
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
    }
}