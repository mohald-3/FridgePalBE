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

            var result = items.Select(i => new ItemResponseDto
            {
                ItemId = i.ItemId,
                ProductName = i.ProductName,
                Quantity = i.Quantity,
                ExpirationDate = i.ExpirationDate,
                CreationDate = i.CreationDate,
                Notified = i.Notified,
                CategoryId = i.CategoryId,
                CategoryName = i.Category?.CategoryName
            }).ToList();

            return OperationResult<List<ItemResponseDto>>.Ok(result);
        }
    }
}
