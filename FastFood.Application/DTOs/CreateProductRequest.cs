using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastFood.Domain.Entities;

namespace FastFood.Application.DTOs
{
    public class CreateProductRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public EnumCategoryProduct Category { get; set; }
    }
}
