using Application.Commands.Dogs;
using Application.Commands.Dogs.UpdateDog;
using Application.Dtos.Dogs;
using Application.Dtos.Users;
using Application.Exceptions.Authorize;
using Application.Exceptions.EntityNotFound;
using Application.Queries.Dogs.GetAll;
using Application.Queries.Dogs.GetById;
using Application.Validators.Dog;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.DogsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        internal readonly IMediator _mediator;
        internal readonly DogValidator _dogValidator;
        public DogsController(IMediator mediator, DogValidator dogValidator)
        {
            _mediator = mediator;
            _dogValidator = dogValidator;
        }

        // Get all dogs from database
        [HttpGet]
        [Route("getAllDogs")]
        public async Task<IActionResult> GetAllDogs()
        {
            return Ok(await _mediator.Send(new GetAllDogsQuery()));
        }

        // Get a dog by Id
        [HttpGet]
        [Route("getDogById/{dogId}")]
        public async Task<IActionResult> GetDogById(Guid dogId)
        {
            try
            {
                return Ok(await _mediator.Send(new GetDogByIdQuery(dogId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Create a new dog 
        [HttpPost]
        [Route("addNewDog")]
        //[Authorize(Policy = "Admin")]
        [ProducesResponseType(typeof(DogDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddDog([FromBody] DogDto newDog)
        {
            // Validate Dog
            var validatedDog = _dogValidator.Validate(newDog);

            // Error handling
            if (!validatedDog.IsValid)
            {
                return BadRequest(validatedDog.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            // Try Catch
            try
            {
                return Ok(await _mediator.Send(new AddDogCommand(newDog)));
            }
            catch (EntityNotFoundException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Update a specific dog
        [HttpPut]
        [Route("updateDog/{updatedDogId}")]
        public async Task<IActionResult> UpdateDog([FromBody] DogDto updatedDog, Guid updatedDogId)
        {
            return Ok(await _mediator.Send(new UpdateDogByIdCommand(updatedDog, updatedDogId)));
        }

        // IMPLEMENT DELETE !!!

    }
}
