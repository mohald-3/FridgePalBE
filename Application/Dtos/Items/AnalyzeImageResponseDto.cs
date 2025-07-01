namespace Application.Dtos.Items
{
    public class AnalyzeImageResponseDto
    {
        public string ItemName { get; set; }
        public string Category { get; set; }
        public string ShelfLife { get; set; } // e.g., "5-7 days in fridge"
    }
}
