using Application.Dtos.Items;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Commands.Items.RecognizeItem
{
    public class RecognizeItemCommand : IRequest<RecognizedItemDto>
    {
        public IFormFile Image { get; set; }

        public RecognizeItemCommand(IFormFile image)
        {
            Image = image;
        }
    }
}
