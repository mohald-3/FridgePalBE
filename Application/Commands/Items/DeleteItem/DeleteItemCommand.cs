using Application.Dtos.MediatR;
using MediatR;

namespace Application.Commands.Items.DeleteItem
{
    public class DeleteItemCommand : IRequest<OperationResult<bool>>
    {
        public Guid ItemId { get; }
        public DeleteItemCommand(Guid itemId) => ItemId = itemId;
    }
}
