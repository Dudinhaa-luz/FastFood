using FastFood.Domain.Enums;

namespace FastFood.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public List<Guid>? Products { get; set; }
        public DateTime CreateDate { get; set; }
        public EnumOrderStatus Status { get; set; }
    }
}
