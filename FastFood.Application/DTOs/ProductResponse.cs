using FastFood.Domain.Enums;

namespace FastFood.Application.DTOs
{
    public class ProductResponse
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public EnumCategoryProduct Category { get; set; }
    }
}
