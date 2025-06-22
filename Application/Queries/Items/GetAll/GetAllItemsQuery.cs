using Application.Dtos.Items;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Items.GetAll
{
    public class GetAllItemsQuery : IRequest<List<ItemResponseDto>> { }
}
