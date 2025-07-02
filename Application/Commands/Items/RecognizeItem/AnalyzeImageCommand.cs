using Application.Dtos.Items;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Commands.Items.RecognizeItem
{
    public class AnalyzeImageCommand : IRequest<AnalyzeImageResponseDto>
    {
        public IFormFile Image { get; set; }

        public AnalyzeImageCommand(IFormFile image)
        {
            Image = image;
        }
    }

}
