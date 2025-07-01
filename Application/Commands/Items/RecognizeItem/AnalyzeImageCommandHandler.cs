using Application.Dtos.Items;
using Application.Interfaces.Services.OpenAI;
using MediatR;

namespace Application.Commands.Items.RecognizeItem
{
    public class AnalyzeImageCommandHandler : IRequestHandler<AnalyzeImageCommand, AnalyzeImageResponseDto>
    {
        private readonly IOpenAIService _openAIService;

        public AnalyzeImageCommandHandler(IOpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        public async Task<AnalyzeImageResponseDto> Handle(AnalyzeImageCommand request, CancellationToken cancellationToken)
        {
            return await _openAIService.AnalyzeImageAsync(request.Image, cancellationToken);
        }
    }
}
