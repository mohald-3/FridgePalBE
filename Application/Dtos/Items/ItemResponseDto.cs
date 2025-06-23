namespace Application.Dtos.Items
{
    public class ItemResponseDto : ItemDto
    {
        public Guid ItemId { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Notified { get; set; }
        public string? CategoryName { get; set; } // Joined info from navigation property
    }
}
