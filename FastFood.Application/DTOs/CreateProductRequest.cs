using FastFood.Domain.Enums;

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
