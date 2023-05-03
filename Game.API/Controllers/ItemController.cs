using FluentValidation;
using FluentValidation.Results;
using Game.Contracts.Items;
using Game.Core.Items.Commands;
using Game.Core.Items.Queries;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Game.API.Controllers;

[ApiController]
[Route("api/[controller]")] /* URL: {host}/api/item */
public class ItemController : ControllerBase
{
    private readonly ILogger<ItemController> _logger;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public ItemController(ILogger<ItemController> logger, IMapper mapper, IMediator mediator)
    {
        _logger = logger;
        _mapper = mapper;
        _mediator = mediator;
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet("~/api/[controller]s")] /* GET: {host}/api/items */
    public async Task<ActionResult<List<ItemResponse>>> GetAll()
    {
        var response = await _mediator.Send(new GetItemsQuery());

        if (response is null)
        {
            _logger.LogInformation("Items are currently empty.");
            return NoContent();
        }

        _logger.LogInformation("Items fetched successfully.");
        return Ok(response);
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet("{id}")] /* GET: {host}/api/item/{id} */
    public async Task<ActionResult<ItemResponse>> Get(Guid id)
    {
        var response = await _mediator.Send(new GetItemQuery(id));

        if (response is null)
        {
            _logger.LogError("Item does not exist.");
            return NotFound();
        }

        _logger.LogInformation("Item fetched successfully.");
        return Ok(response);
    }

    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [HttpPost] /* POST: {host}/api/item */
    public async Task<ActionResult<ItemResponse>> Post(ItemRequest request, IValidator<ItemRequest> validator)
    {
        ValidationResult result = validator.Validate(request);

        if (!result.IsValid)
        {
            ModelStateDictionary dictionary = new();

            foreach (ValidationFailure failure in result.Errors)
            {
                dictionary.AddModelError(failure.PropertyName, failure.ErrorMessage);
            }

            _logger.LogError("Item is invalid.");
            return ValidationProblem(dictionary);
        }

        var response = await _mediator.Send(new PostItemCommand(request));
        
        _logger.LogInformation("Item created successfully.");
        return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpPut("{id}")] /* PUT: {host}/api/item/{id} */
    public async Task<IActionResult> Put(Guid id, ItemRequest request, IValidator<ItemRequest> validator)
    {
        var response = await _mediator.Send(new GetItemQuery(id));

        if (response is null)
        {
            _logger.LogError("Item does not exist.");
            return NotFound();
        }

        _mapper.Map(request, response);
        _mapper.Map(response, request);

        ValidationResult result = validator.Validate(request);

        if (!result.IsValid)
        {
            ModelStateDictionary dictionary = new();

            foreach (ValidationFailure failure in result.Errors)
            {
                dictionary.AddModelError(failure.PropertyName, failure.ErrorMessage);
            }

            _logger.LogError("Item is invalid.");
            return ValidationProblem(dictionary);
        }

        await _mediator.Send(new UpdateItemCommand(request));

        _logger.LogInformation("Item updated successfully.");
        return NoContent();
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpPatch("{id}")] /* PATCH: {host}/api/item/{id} */
    public async Task<IActionResult> Patch(Guid id, JsonPatchDocument<ItemRequest> patchDoc, IValidator<ItemRequest> validator)
    {
        var response = await _mediator.Send(new GetItemQuery(id));

        if (response is null)
        {
            _logger.LogError("Item does not exist.");
            return NotFound();
        }   
        
        var request = _mapper.Map<ItemRequest>(response);
        patchDoc.ApplyTo(request);

        ValidationResult result = validator.Validate(request);

        if (!result.IsValid)
        {
            ModelStateDictionary dictionary = new();

            foreach (ValidationFailure failure in result.Errors)
            {
                dictionary.AddModelError(failure.PropertyName, failure.ErrorMessage);
            }

            _logger.LogError("Item is invalid.");
            return ValidationProblem(dictionary);
        }

        await _mediator.Send(new UpdateItemCommand(request));
        
        _logger.LogInformation("Item updated successfully.");
        return NoContent();
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpDelete("{id}")] /* DELETE: {host}/api/item/{id} */
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _mediator.Send(new GetItemQuery(id));

        if (response is null)
        {
            _logger.LogError("Item does not exist.");
            return NotFound();
        }

        var request = _mapper.Map<ItemRequest>(response);
        await _mediator.Send(new DeleteItemCommand(request));

        _logger.LogInformation("Item deleted successfully.");
        return NoContent();
    }
}
