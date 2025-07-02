using Application.Commands.Items.AddItem;
using Application.Commands.Items.DeleteItem;
using Application.Commands.Items.PatchItem;
using Application.Commands.Items.RecognizeItem;
using Application.Dtos.Items;
using Application.Interfaces.Services.Images;
using Application.Queries.Items.GetAll;
using Application.Queries.Items.GetById;
using Application.Validators.Item;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers.ItemsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IImageStorageService _imageService;
        private readonly AddItemDtoValidator _itemWithImageValidator;
        private readonly UpdateItemPartialDtoValidator _updateItemPartialDtoValidator;

        public ItemController(IMediator mediator,
            AddItemDtoValidator itemWithImageValidator, 
            UpdateItemPartialDtoValidator patchValidator, 
            IImageStorageService imageService)
        {
            _mediator = mediator;
            _itemWithImageValidator = itemWithImageValidator;
            _updateItemPartialDtoValidator = patchValidator;
            _imageService = imageService;
        }

        // GET: api/items/getAllItems
        [HttpGet]
        [Route("getAllItems")]
        public async Task<IActionResult> GetAllItems()
        {
            var result = await _mediator.Send(new GetAllItemsQuery());

            if (!result.IsSuccess)
                return BadRequest(result.ErrorMessage);

            return Ok(result.Result);
        }

        // GET: api/items/getItemById/{id}
        [HttpGet]
        [Route("getItemById/{id}")]
        public async Task<IActionResult> GetItemById(Guid id)
        {
            var result = await _mediator.Send(new GetItemByIdQuery(id));

            if (!result.IsSuccess)
                return NotFound(result.ErrorMessage);

            return Ok(result.Result);
        }

        [HttpPost]
        [Route("addNewItem")]
        [ProducesResponseType(typeof(ItemResponseDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddItem([FromForm] ItemWithImageDto newItem)
        {
            // Validation
            var validatedItem = _itemWithImageValidator.Validate(newItem);
            if (!validatedItem.IsValid)
            {
                return BadRequest(validatedItem.Errors.ConvertAll(error => error.ErrorMessage));
            }

            // uploading image to cloudinary
            string? imageUrl = null;
            if (newItem.Image != null && newItem.Image.Length > 0)
            {
                var uploadedUrl = await _imageService.UploadImageAsync(newItem.Image);
                imageUrl = string.IsNullOrWhiteSpace(uploadedUrl) ? null : uploadedUrl;
            }

            // Adding the item to the DB
            var result = await _mediator.Send(new AddItemCommand(newItem, imageUrl));

            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(result.Result);
        }

        [HttpPatch]
        [Route("updateItem/{itemId}")]
        public async Task<IActionResult> PatchItem(Guid itemId, [FromForm] UpdateItemPartialDto updatedFields)
        {
            // Validation for the input fields
            var validationResult = _updateItemPartialDtoValidator.Validate(updatedFields);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
            }

            // Patching the item
            var result = await _mediator.Send(new PatchItemCommand(itemId, updatedFields));

            if (!result.IsSuccess)
                return BadRequest(result.ErrorMessage);

            return Ok(result.Result);
        }

        [HttpDelete]
        [Route("deleteItem/{itemId}")]
        public async Task<IActionResult> DeleteItem(Guid itemId)
        {
            var result = await _mediator.Send(new DeleteItemCommand(itemId));

            if (!result.IsSuccess)
                return NotFound(result.ErrorMessage);

            return Ok(result.Result);
        }

        [HttpPost("analyze-image")]
        public async Task<IActionResult> AnalyzeImage([FromForm] AnalyzeImageRequestDto dto)
        {
            var command = new AnalyzeImageCommand(dto.Image);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
