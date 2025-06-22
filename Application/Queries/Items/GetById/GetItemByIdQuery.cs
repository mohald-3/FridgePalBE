using Application.Dtos.Items;
using Application.Dtos.MediatR;
using MediatR;

namespace Application.Queries.Items.GetById
{
    public class GetItemByIdQuery : IRequest<OperationResult<ItemResponseDto>>
    {
        public Guid Id { get; }
        public GetItemByIdQuery(Guid id) => Id = id;
    }
}
