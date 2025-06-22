using Application.Dtos.Items;
using MediatR;

namespace Application.Commands.Items
{
    public class AddItemCommand : IRequest<ItemResponseDto>
    {
        public ItemDto Item { get; }
        public AddItemCommand(ItemDto item) => Item = item;
    }
}
