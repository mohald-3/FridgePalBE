using Application.Dtos.MediatR;
using Application.Exceptions.EntityNotFound;
using Domain.Models;
using Infrastructure.Database;
using Infrastructure.Database.MySQLDatabase;
using Infrastructure.Repositories.Dogs;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Queries.Dogs.GetById
{
    public class GetDogByIdQueryHandler : IRequestHandler<GetDogByIdQuery, OperationResult<Dog>>
    {
        private readonly IDogRepository _dogRepository;
        private readonly ILogger<GetDogByIdQueryHandler> _logger;

        public GetDogByIdQueryHandler(IDogRepository dogRepository, ILogger<GetDogByIdQueryHandler> logger)
        {
            _dogRepository = dogRepository;
            _logger = logger;
        }

        public async Task<OperationResult<Dog>> Handle(GetDogByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogDebug("Handling GetDogByIdQuery");

                Dog wantedDog = await _dogRepository.GetDogById(request.Id);

                if (wantedDog == null)
                {
                    throw new EntityNotFoundException("Dog", request.Id);
                }

                _logger.LogInformation($"Dog with Id {request.Id} found");

                return await Task.FromResult(new OperationResult<Dog>
                {
                    IsSuccess = true,
                    Result = wantedDog,
                });
            }
            catch (EntityNotFoundException ex)
            {
                return await Task.FromResult(new OperationResult<Dog>
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while handling GetDogByIdQuery");
                return new OperationResult<Dog>
                {
                    IsSuccess = false,
                    ErrorMessage = "An error occurred while handling GetDogByIdQuery"
                };
            }
        }
    }
}
