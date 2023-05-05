using FluentValidation;
using FluentValidation.Results;
using Game.Contracts.Item;
using Game.Core.Services.Commands;
using Game.Core.Services.Queries;
using Game.Domain.Entities;
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
    private readonly IValidator<ItemRequest> _validator;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public ItemController(ILogger<ItemController> logger, IValidator<ItemRequest> validator, IMapper mapper, IMediator mediator)
    {
        _logger = logger;
        _validator = validator;
        _mapper = mapper;
        _mediator = mediator;
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet("~/api/[controller]s")] /* GET: {host}/api/items */
    public async Task<ActionResult<List<ItemResponse>>> GetAll()
    {
        var getAll = new GetAllItemsQuery();
        var items = await _mediator.Send(getAll);

        if (items is null)
        {
            _logger.LogInformation("Items are currently empty.");
            return NoContent();
        }

        var response = _mapper.Map<List<Item>>(items);

        _logger.LogInformation("Items fetched successfully.");
        return Ok(response);
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet("{id}")] /* GET: {host}/api/item/{id} */
    public async Task<ActionResult<ItemResponse>> Get(Guid id)
    {
        var get = new GetItemQuery(id);
        var item = await _mediator.Send(get);

        if (item is null)
        {
            _logger.LogError("Item does not exist.");
            return NotFound();
        }

        var response = _mapper.Map<ItemResponse>(item);

        _logger.LogInformation("Item fetched successfully.");
        return Ok(response);
    }

    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [HttpPost] /* POST: {host}/api/item */
    public async Task<ActionResult<ItemResponse>> Post(ItemRequest request)
    {
        ValidationResult result = _validator.Validate(request);

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
        
        var item = _mapper.Map<Item>(request);
        var post = new PostItemCommand(item);
        await _mediator.Send(post);
        var response = _mapper.Map<ItemResponse>(item);
        
        _logger.LogInformation("Item created successfully.");
        return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpPut("{id}")] /* PUT: {host}/api/item/{id} */
    public async Task<IActionResult> Put(Guid id, ItemRequest request)
    {
        var get = new GetItemQuery(id);
        var item = await _mediator.Send(get);

        if (item is null)
        {
            _logger.LogError("Item does not exist.");
            return NotFound();
        }

        _mapper.Map(request, item);
        _mapper.Map(item, request);

        ValidationResult result = _validator.Validate(request);

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

        var update = new UpdateItemCommand(item);
        await _mediator.Send(update);

        _logger.LogInformation("Item updated successfully.");
        return NoContent();
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpPatch("{id}")] /* PATCH: {host}/api/item/{id} */
    public async Task<IActionResult> Patch(Guid id, JsonPatchDocument<ItemRequest> patchDoc)
    {
        var get = new GetItemQuery(id);
        var item = await _mediator.Send(get);

        if (item is null)
        {
            _logger.LogError("Item does not exist.");
            return NotFound();
        }   
        
        var request = _mapper.Map<ItemRequest>(item);
        patchDoc.ApplyTo(request);

        ValidationResult result = _validator.Validate(request);

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

        _mapper.Map(request, item);
        var update = new UpdateItemCommand(item);
        await _mediator.Send(update);
        
        _logger.LogInformation("Item updated successfully.");
        return NoContent();
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpDelete("{id}")] /* DELETE: {host}/api/item/{id} */
    public async Task<IActionResult> Delete(Guid id)
    {
        var get = new GetItemQuery(id);
        var item = await _mediator.Send(get);

        if (item is null)
        {
            _logger.LogError("Item does not exist.");
            return NotFound();
        }

        var delete = new DeleteItemCommand(item);
        await _mediator.Send(delete);

        _logger.LogInformation("Item deleted successfully.");
        return NoContent();
    }
}
