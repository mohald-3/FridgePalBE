using Application.Dtos.MediatR;
using Application.Interfaces.Repositories.Items;
using MediatR;

namespace Application.Commands.Items.DeleteItem
{
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, OperationResult<bool>>
    {
        private readonly IItemRepository _repo;
        public DeleteItemCommandHandler(IItemRepository repo) => _repo = repo;

        public async Task<OperationResult<bool>> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var success = await _repo.DeleteAsync(request.ItemId);
            if (!success)
                return OperationResult<bool>.Fail("Item not found or already deleted");

            return OperationResult<bool>.Ok(true);
        }
    }
}
