using Application.Dtos.Items;
using Application.Dtos.MediatR;
using MediatR;

namespace Application.Commands.Items.AddItem
{
    public class AddItemCommand : IRequest<OperationResult<ItemResponseDto>>
    {
        public ItemDto Item { get; }
        public string ImageUrl { get; }

        public AddItemCommand(ItemDto item, string imageUrl)
        {
            Item = item;
            ImageUrl = imageUrl;
        }
    }
}
