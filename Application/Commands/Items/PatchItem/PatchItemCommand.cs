using Application.Dtos.Items;
using Application.Dtos.MediatR;
using MediatR;

namespace Application.Commands.Items.PatchItem
{
    public class PatchItemCommand : IRequest<OperationResult<ItemResponseDto>>
    {
        public Guid ItemId { get; }
        public UpdateItemPartialDto PartialItem { get; }

        public PatchItemCommand(Guid itemId, UpdateItemPartialDto partialItem)
        {
            ItemId = itemId;
            PartialItem = partialItem;
        }
    }
}
