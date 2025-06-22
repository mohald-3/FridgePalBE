using Application.Dtos.Items;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Items.GetById
{
    public class GetItemByIdQuery : IRequest<ItemResponseDto>
    {
        public Guid Id { get; }
        public GetItemByIdQuery(Guid id) => Id = id;
    }
}
