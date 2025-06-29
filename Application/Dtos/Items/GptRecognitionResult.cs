namespace Application.Dtos.Items
{
    public class GptRecognitionResult
    {
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int CategoryId { get; set; } // optional
        public int EstimatedShelfLifeInDays { get; set; }
    }
}
