using Application.Dtos.Items;
using Application.Dtos.MediatR;
using Application.Interfaces.Repositories.Items;
using MediatR;

namespace Application.Queries.Items.GetById
{
    public class GetItemByIdQueryHandler : IRequestHandler<GetItemByIdQuery, OperationResult<ItemResponseDto>>
    {
        private readonly IItemRepository _repo;
        public GetItemByIdQueryHandler(IItemRepository repo) => _repo = repo;

        public async Task<OperationResult<ItemResponseDto>> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
        {
            var item = await _repo.GetByIdAsync(request.Id);

            if (item == null)
                return OperationResult<ItemResponseDto>.Fail("Item not found");

            var result = new ItemResponseDto
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
            };

            return OperationResult<ItemResponseDto>.Ok(result);
        }
    }
}
