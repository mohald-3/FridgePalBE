using Application.Dtos.Items;
using Application.Dtos.MediatR;
using Application.Interfaces.Repositories.Items;
using Domain.Models.Item;
using MediatR;

namespace Application.Commands.Items.UpdateItem
{
    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, OperationResult<ItemResponseDto>>
    {
        private readonly IItemRepository _repo;
        public UpdateItemCommandHandler(IItemRepository repo) => _repo = repo;

        public async Task<OperationResult<ItemResponseDto>> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var model = new ItemModel
            {
                ProductName = request.UpdatedItem.ProductName,
                Quantity = request.UpdatedItem.Quantity,
                ExpirationDate = request.UpdatedItem.ExpirationDate,
                CategoryId = request.UpdatedItem.CategoryId
            };

            var updated = await _repo.UpdateAsync(request.ItemId, model);

            if (updated == null)
                return OperationResult<ItemResponseDto>.Fail("Item not found");

            var result = new ItemResponseDto
            {
                ItemId = updated.ItemId,
                ProductName = updated.ProductName,
                Quantity = updated.Quantity,
                ExpirationDate = updated.ExpirationDate,
                CreationDate = updated.CreationDate,
                Notified = updated.Notified,
                CategoryId = updated.CategoryId,
                CategoryName = updated.Category?.CategoryName
            };

            return OperationResult<ItemResponseDto>.Ok(result);
        }
    }
}
