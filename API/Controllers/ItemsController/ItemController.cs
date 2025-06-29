using Application.Commands.Items.AddItem;
using Application.Commands.Items.DeleteItem;
using Application.Commands.Items.RecognizeItem;
using Application.Commands.Items.UpdateItem;
using Application.Dtos.Items;
using Application.Queries.Items.GetAll;
using Application.Queries.Items.GetById;
using Application.Validators.Item;
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

        public ItemController(IMediator mediator, ItemDtoValidator itemValidator)
        {
            _mediator = mediator;
            _itemValidator = itemValidator;
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
        public async Task<IActionResult> AddItem([FromBody] ItemDto newItem)
        {
            Console.WriteLine("📱 Request received from mobile frontend");
            var validatedItem = _itemValidator.Validate(newItem);

            if (!validatedItem.IsValid)
            {
                return BadRequest(validatedItem.Errors.ConvertAll(error => error.ErrorMessage));
            }

            var result = await _mediator.Send(new AddItemCommand(newItem));

            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(result.Result);
        }

        [HttpPut]
        [Route("updateItem/{itemId}")]
        public async Task<IActionResult> UpdateItem(Guid itemId, [FromBody] ItemDto updatedItem)
        {
            Console.WriteLine("📱 Request received from mobile frontend");
            var validationResult = _itemValidator.Validate(updatedItem);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
            }

            var result = await _mediator.Send(new UpdateItemCommand(itemId, updatedItem));
            return Ok(result);
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
