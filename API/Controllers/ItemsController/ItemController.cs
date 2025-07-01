﻿using Application.Commands.Items.AddItem;
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
        private readonly ItemDtoValidator _itemValidator;
        private readonly IImageStorageService _imageService;
        private readonly ItemWithImageDtoValidator _itemWithImageValidator;
        private readonly UpdateItemPartialDtoValidator _updateItemPartialDtoValidator;



        public ItemController(IMediator mediator,
            ItemDtoValidator itemValidator, 
            ItemWithImageDtoValidator itemWithImageValidator,
            UpdateItemPartialDtoValidator patchValidator,
            IImageStorageService imageService)
        {
            _mediator = mediator;
            _itemValidator = itemValidator;
            _itemWithImageValidator = itemWithImageValidator;
            _updateItemPartialDtoValidator = patchValidator;
            _imageService = imageService;
        }

        // GET: api/items/getAllItems
        [HttpGet]
        [Route("getAllItems")]
        public async Task<IActionResult> GetAllItems()
        {
            Console.WriteLine("📱 Request received from mobile frontend");
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
            Console.WriteLine("📱 Request received from mobile frontend");
            var result = await _mediator.Send(new GetItemByIdQuery(id));

            if (!result.IsSuccess)
                return NotFound(result.ErrorMessage);

            return Ok(result.Result);
        }

        // POST: api/items/addNewItem
        [HttpPost]
        [Route("addNewItem")]
        [ProducesResponseType(typeof(ItemResponseDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddItem([FromForm] ItemWithImageDto newItem)
        {
            Console.WriteLine("📱 Request received from mobile frontend");

            var validatedItem = _itemWithImageValidator.Validate(newItem);

            if (!validatedItem.IsValid)
            {
                return BadRequest(validatedItem.Errors.ConvertAll(error => error.ErrorMessage));
            }

            var imageUrl = string.Empty;
            if (newItem.Image != null && newItem.Image.Length > 0)
            {
                imageUrl = await _imageService.UploadImageAsync(newItem.Image);
            }

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
            Console.WriteLine("📱 PATCH request from mobile frontend");

            var validationResult = _updateItemPartialDtoValidator.Validate(updatedFields);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
            }

            var result = await _mediator.Send(new PatchItemCommand(itemId, updatedFields));

            if (!result.IsSuccess)
                return BadRequest(result.ErrorMessage);

            return Ok(result.Result);
        }

        [HttpDelete]
        [Route("deleteItem/{itemId}")]
        public async Task<IActionResult> DeleteItem(Guid itemId)
        {
            Console.WriteLine("📱 Request received from mobile frontend");
            var result = await _mediator.Send(new DeleteItemCommand(itemId));

            if (!result.IsSuccess)
                return NotFound(result.ErrorMessage);

            return Ok(result.Result);
        }

    }
}
