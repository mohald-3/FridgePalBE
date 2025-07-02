using Application.Dtos.Items;
using Application.Dtos.MediatR;
using Application.Interfaces.Repositories.Items;
using MediatR;

namespace Application.Queries.Items.GetAll
{
    public class GetAllItemsQueryHandler : IRequestHandler<GetAllItemsQuery, OperationResult<List<ItemResponseDto>>>
    {
        private readonly IItemRepository _repo;
        public GetAllItemsQueryHandler(IItemRepository repo) => _repo = repo;

        public async Task<OperationResult<List<ItemResponseDto>>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            var items = await _repo.GetAllAsync();

            var result = items.Select(item => new ItemResponseDto
            {
                ItemId = item.ItemId,
                ProductName = item.ProductName,
                Quantity = item.Quantity,
                ExpirationDate = item.ExpirationDate,
                CreationDate = item.CreationDate,
                Notified = item.Notified,
                CategoryId = item.CategoryId,
                CategoryName = item.Category?.CategoryName,
                ImageUrl = item.ImageUrl
            }).ToList();

            return OperationResult<List<ItemResponseDto>>.Ok(result);
        }
    }
}
