using Application.Commands.Items;
//using Application.Commands.Items.AddItem;
using Application.Dtos.Items;
using Application.Exceptions.EntityNotFound;
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
            return Ok(await _mediator.Send(new GetAllItemsQuery()));
        }

        // GET: api/items/getItemById/{id}
        [HttpGet]
        [Route("getItemById/{id}")]
        public async Task<IActionResult> GetItemById(Guid id)
        {
            try
            {
                return Ok(await _mediator.Send(new GetItemByIdQuery(id)));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/items/addNewItem
        [HttpPost]
        [Route("addNewItem")]
        [ProducesResponseType(typeof(ItemDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddItem([FromBody] ItemDto newItem)
        {
            var validatedItem = _itemValidator.Validate(newItem);

            if (!validatedItem.IsValid)
            {
                return BadRequest(validatedItem.Errors.ConvertAll(error => error.ErrorMessage));
            }

            try
            {
                return Ok(await _mediator.Send(new AddItemCommand(newItem)));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT/DELETE can be added here as needed.

    }
}
