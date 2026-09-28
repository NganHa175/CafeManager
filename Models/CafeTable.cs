namespace CafeManagement.Models
{
    public class CafeTable
    {
        public int Id { get; set; }
        public string TableName { get; set; } = "";
        public string Status { get; set; } = "Empty"; // "Empty", "Occupied", "Paid"
    }
}
