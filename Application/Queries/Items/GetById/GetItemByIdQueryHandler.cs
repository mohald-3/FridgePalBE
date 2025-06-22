using Application.Dtos.Items;
using Application.Interfaces.Repositories.Items;
using MediatR;

namespace Application.Queries.Items.GetById
{
    public class GetItemByIdQueryHandler : IRequestHandler<GetItemByIdQuery, ItemResponseDto>
    {
        private readonly IItemRepository _repo;
        public GetItemByIdQueryHandler(IItemRepository repo) => _repo = repo;

        public async Task<ItemResponseDto> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
        {
            var item = await _repo.GetByIdAsync(request.Id) ?? throw new Exception("Item not found");

            return new ItemResponseDto
            {
                ItemId = item.ItemId,
                ProductName = item.ProductName,
                Quantity = item.Quantity,
                ExpirationDate = item.ExpirationDate,
                CreationDate = item.CreationDate,
                Notified = item.Notified,
                CategoryId = item.CategoryId,
                CategoryName = item.Category?.CategoryName
            };
        }
    }
}
