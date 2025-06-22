using Application.Dtos.Items;
using Application.Dtos.MediatR;
using MediatR;

namespace Application.Queries.Items.GetAll
{
    public class GetAllItemsQuery : IRequest<OperationResult<List<ItemResponseDto>>> { }
}
