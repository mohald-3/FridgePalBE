using Application.Dtos.Items;
using Application.Dtos.MediatR;
using Application.Interfaces.Repositories.Items;
using Application.Interfaces.Services.Images;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Items.PatchItem
{
    public class PatchItemCommandHandler : IRequestHandler<PatchItemCommand, OperationResult<ItemResponseDto>>
    {
        private readonly IItemRepository _repo;
        private readonly IImageStorageService _imageService;

        public PatchItemCommandHandler(IItemRepository repo, IImageStorageService imageService)
        {
            _repo = repo;
            _imageService = imageService;
        }

        public async Task<OperationResult<ItemResponseDto>> Handle(PatchItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _repo.GetByIdAsync(request.ItemId);
            if (item == null)
                return OperationResult<ItemResponseDto>.Fail("Item not found");

            var dto = request.PartialItem;

            if (dto.ProductName != null) item.ProductName = dto.ProductName;
            if (dto.Quantity.HasValue) item.Quantity = dto.Quantity.Value;
            if (dto.ExpirationDate.HasValue) item.ExpirationDate = dto.ExpirationDate.Value;
            if (dto.CategoryId.HasValue) item.CategoryId = dto.CategoryId.Value;

            if (dto.Image != null)
            {
                if (!string.IsNullOrEmpty(item.ImageUrl))
                    await _imageService.DeleteImageAsync(item.ImageUrl);

                var uploadedUrl = await _imageService.UploadImageAsync(dto.Image);
                item.ImageUrl = string.IsNullOrWhiteSpace(uploadedUrl) ? null : uploadedUrl;
            }

            var updated = await _repo.UpdateAsync(request.ItemId, item);

            var result = new ItemResponseDto
            {
                ItemId = updated.ItemId,
                ProductName = updated.ProductName,
                Quantity = updated.Quantity,
                ExpirationDate = updated.ExpirationDate,
                CreationDate = updated.CreationDate,
                Notified = updated.Notified,
                CategoryId = updated.CategoryId,
                CategoryName = updated.Category?.CategoryName,
                ImageUrl = updated.ImageUrl
            };

            return OperationResult<ItemResponseDto>.Ok(result);
        }
    }

}
