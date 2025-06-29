using Application.Dtos.Items;

namespace Application.Interfaces.Services.Mocks
{
    public interface IGptRecognitionService
    {
        Task<RecognizedItemDto> RecognizeItemAsync(string imageUrl);
    }
}
