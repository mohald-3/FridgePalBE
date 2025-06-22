using Application.Dtos.Items;
using Application.Interfaces.Repositories.Items;
using Domain.Models.Item;
using MediatR;

namespace Application.Commands.Items
{
    public class AddItemCommandHandler : IRequestHandler<AddItemCommand, ItemResponseDto>
    {
        private readonly IItemRepository _repo;
        public AddItemCommandHandler(IItemRepository repo) => _repo = repo;

        public async Task<ItemResponseDto> Handle(AddItemCommand request, CancellationToken cancellationToken)
        {
            var model = new ItemModel
            {
                ItemId = Guid.NewGuid(),
                ProductName = request.Item.ProductName,
                Quantity = request.Item.Quantity,
                ExpirationDate = request.Item.ExpirationDate,
                CategoryId = request.Item.CategoryId,
                CreationDate = DateTime.UtcNow,
                Notified = false
            };

            var saved = await _repo.AddAsync(model);

            return new ItemResponseDto
            {
                ItemId = saved.ItemId,
                ProductName = saved.ProductName,
                Quantity = saved.Quantity,
                ExpirationDate = saved.ExpirationDate,
                CreationDate = saved.CreationDate,
                Notified = saved.Notified,
                CategoryId = saved.CategoryId
            };
        }
    }
}
