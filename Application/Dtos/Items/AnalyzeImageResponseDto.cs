namespace Application.Dtos.Items
{
    public class AnalyzeImageResponseDto
    {
        public string ItemName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
        public int ShelfLifeDays { get; set; }
    }
}
