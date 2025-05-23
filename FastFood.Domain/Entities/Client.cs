﻿namespace FastFood.Domain.Entities
{
    public class Client
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? CPF { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
