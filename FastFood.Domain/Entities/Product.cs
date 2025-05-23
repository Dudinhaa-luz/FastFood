using System;
using FastFood.Domain.Entities;

public class Product
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public EnumCategoryProduct Category  { get; set; }
}
