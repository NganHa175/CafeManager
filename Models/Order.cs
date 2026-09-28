namespace CafeManagement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Open"; // "Open", "Paid"
        public decimal TotalAmount { get; set; }
    }
}
