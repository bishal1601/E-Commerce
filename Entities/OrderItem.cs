﻿namespace E_Commerce.Entities
{
    public class OrderItem
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public virtual Order Order { get; set; }
        
        public long ProductId { get; set; }
        public virtual Product Product { get; set; }
        
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }
}