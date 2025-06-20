using Application.Dtos.MediatR;
using Domain.Models;
using MediatR;

namespace Application.Queries.Dogs.GetById
{
    public class GetDogByIdQuery : IRequest<OperationResult<Dog>>
    {
        public GetDogByIdQuery(Guid dogId)
        {
            Id = dogId;
        }

        public Guid Id { get; }
    }
}
