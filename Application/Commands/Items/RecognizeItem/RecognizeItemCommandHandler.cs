using Application.Dtos.Items;
using Application.Interfaces.Repositories.Items;
using Application.Interfaces.Services.Images;
using Application.Interfaces.Services.Mocks;
using Domain.Models.Item;
using MediatR;

namespace Application.Commands.Items.RecognizeItem
{
    public class RecognizeItemCommandHandler : IRequestHandler<RecognizeItemCommand, RecognizedItemDto>
    {
        private readonly IImageStorageService _imageStorageService;
        private readonly IGptRecognitionService _gptRecognitionService;
        private readonly IItemRepository _itemRepository;

        public RecognizeItemCommandHandler(
            IImageStorageService imageStorageService,
            IGptRecognitionService gptRecognitionService,
            IItemRepository itemRepository)
        {
            _imageStorageService = imageStorageService;
            _gptRecognitionService = gptRecognitionService;
            _itemRepository = itemRepository;
        }

        public async Task<RecognizedItemDto> Handle(RecognizeItemCommand request, CancellationToken cancellationToken)
        {
            // Upload image
            var imageUrl = await _imageStorageService.UploadImageAsync(request.Image);

            // Recognize item via GPT
            var recognitionResult = await _gptRecognitionService.RecognizeItemAsync(imageUrl);

            // Create entity
            var newItem = new ItemModel
            {
                ProductName = recognitionResult.Name,
                CategoryId = recognitionResult.CategoryId, // You may need to resolve category ID by name if needed
                Quantity = 1,
                CreationDate = DateTime.UtcNow,
                ExpirationDate = DateTime.UtcNow.AddDays(recognitionResult.EstimatedShelfLifeInDays),
                Notified = false,
            };

            var addedItem = await _itemRepository.AddAsync(newItem);

            // Return DTO
            return new RecognizedItemDto
            {
                Name = addedItem.ProductName,
                Category = recognitionResult.Category,
                EstimatedShelfLifeInDays = recognitionResult.EstimatedShelfLifeInDays,
                CategoryId = recognitionResult.CategoryId
            };
        }
    }
}
