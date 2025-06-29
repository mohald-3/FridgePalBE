namespace Application.Dtos.Items
{
    public class RecognizedItemDto
    {
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int EstimatedShelfLifeInDays { get; set; }
        public int CategoryId { get; set; } // optional mapping if you store categories in DB
    }
}
