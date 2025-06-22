using Application.Dtos.Items;
using Application.Dtos.MediatR;
using MediatR;

namespace Application.Commands.Items.AddItem
{
    public class AddItemCommand : IRequest<OperationResult<ItemResponseDto>>
    {
        public ItemDto Item { get; }
        public AddItemCommand(ItemDto item) => Item = item;
    }
}
