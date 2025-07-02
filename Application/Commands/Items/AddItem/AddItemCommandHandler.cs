using Application.Dtos.Items;
using Application.Dtos.MediatR;
using Application.Interfaces.Repositories.Items;
using Domain.Models.Item;
using MediatR;

namespace Application.Commands.Items.AddItem
{
    public class AddItemCommandHandler : IRequestHandler<AddItemCommand, OperationResult<ItemResponseDto>>
    {
        private readonly IItemRepository _repo;
        public AddItemCommandHandler(IItemRepository repo) => _repo = repo;

        public async Task<OperationResult<ItemResponseDto>> Handle(AddItemCommand request, CancellationToken cancellationToken)
        {
            var model = new ItemModel
            {
                ItemId = Guid.NewGuid(),
                ProductName = request.Item.ProductName,
                Quantity = request.Item.Quantity,
                ExpirationDate = request.Item.ExpirationDate,
                CategoryId = request.Item.CategoryId,
                CreationDate = DateTime.UtcNow,
                Notified = false,
                ImageUrl = request.ImageUrl
            };

            var saved = await _repo.AddAsync(model);

            var result = new ItemResponseDto
            {
                ItemId = saved.ItemId,
                ProductName = saved.ProductName,
                Quantity = saved.Quantity,
                ExpirationDate = saved.ExpirationDate,
                CreationDate = saved.CreationDate,
                Notified = saved.Notified,
                CategoryId = saved.CategoryId,
                ImageUrl = saved.ImageUrl
            };

            return OperationResult<ItemResponseDto>.Ok(result);
        }
    }
}
