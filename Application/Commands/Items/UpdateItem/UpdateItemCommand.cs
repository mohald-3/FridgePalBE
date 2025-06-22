using Application.Dtos.Items;
using Application.Dtos.MediatR;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Items.UpdateItem
{
    public class UpdateItemCommand : IRequest<OperationResult<ItemResponseDto>>
    {
        public Guid ItemId { get; }
        public ItemDto UpdatedItem { get; }

        public UpdateItemCommand(Guid itemId, ItemDto updatedItem)
        {
            ItemId = itemId;
            UpdatedItem = updatedItem;
        }
    }
}
