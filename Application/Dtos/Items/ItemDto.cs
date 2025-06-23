namespace Application.Dtos.Items
{
    public class ItemDto
    {
        public string ProductName { get; set; } = null!;
        public int Quantity { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int CategoryId { get; set; }
        // public Guid UserId { get; set; } // Should be added later
    }
}
