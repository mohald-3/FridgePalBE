using Application.Dtos.MediatR;
using Application.Interfaces.Repositories.Items;
using Application.Interfaces.Services.Images;
using MediatR;


namespace Application.Commands.Items.DeleteItem
{
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, OperationResult<bool>>
    {
        private readonly IItemRepository _repo;
        private readonly IImageStorageService _imageService;

        public DeleteItemCommandHandler(IItemRepository repo, IImageStorageService imageService)
        {
            _repo = repo;
            _imageService = imageService;
        }

        public async Task<OperationResult<bool>> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            // Get the item first
            var item = await _repo.GetByIdAsync(request.ItemId);

            if (item == null)
                return OperationResult<bool>.Fail("Item not found");

            // Remove the image if it exists
            if (!string.IsNullOrEmpty(item.ImageUrl))
            {
                try
                {
                    await _imageService.DeleteImageAsync(item.ImageUrl);
                }
                catch (Exception ex)
                {
                    // Optionally log it and proceed anyway
                    return OperationResult<bool>.Fail("Failed to delete image: " + ex.Message);
                }
            }

            var success = await _repo.DeleteAsync(request.ItemId);
            if (!success)
                return OperationResult<bool>.Fail("Item could not be deleted");

            return OperationResult<bool>.Ok(true);
        }
    }
}
