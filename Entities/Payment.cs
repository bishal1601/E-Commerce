namespace E_Commerce.Entities
{
    public class Payment
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public virtual Order Order { get; set; }
        
        public string PaymentMethod { get; set; } // Cash, Card, Online
        public string PaymentStatus { get; set; } // Paid, Pending, Failed
        public DateTime PaymentDate { get; set; }

    }
}