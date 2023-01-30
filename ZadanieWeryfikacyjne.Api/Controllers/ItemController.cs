using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Zadanie_weryfikacyjne.Models;
using ZadanieWeryfikacyjne.Commands;
using ZadanieWeryfikacyjne.Models;
using ZadanieWeryfikacyjne.Queries;

namespace ZadanieWeryfikacyjne.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/item")]
    public class ItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("items")]
        [SwaggerOperation(Summary = "Get all items", OperationId = nameof(GetAllItems))]
        [SwaggerResponse(StatusCodes.Status200OK, "All items", typeof(GetAllItemsReponse), ContentType.Json)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "The user was not signed in", typeof(ProblemDetails), ContentType.JsonProblem)]
        public async Task<IActionResult> GetAllItems()
        {
            var query = new GetAllItems();
            var items = await _mediator.Send(query);

            var response = items?.Select(i => new GetAllItemsReponse(
                i.Id,
                i.Code,
                i.Name,
                i.Price));

            return Ok(response);
        }

        [HttpGet("items/{category}")]
        [SwaggerOperation(Summary = "Get all items within a category", OperationId = nameof(GetAllItemsByCategory))]
        [SwaggerResponse(StatusCodes.Status200OK, "All items within a category", typeof(GetAllItemsReponse), ContentType.Json)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "The user was not signed in", typeof(ProblemDetails), ContentType.JsonProblem)]
        public async Task<IActionResult> GetAllItemsByCategory([FromRoute]int category)
        {
            var query = new GetAllItemsByCategory(category);
            var items = await _mediator.Send(query);

            var response = items?.Select(i => new GetAllItemsReponse(
                i.Id,
                i.Code,
                i.Name,
                i.Price));

            return Ok(response);
        }

        [HttpPost("item")]
        [SwaggerOperation(Summary = "Add an item", OperationId = nameof(Item))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Item was successfully added")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "The user was not signed in", typeof(ProblemDetails), ContentType.JsonProblem)]
        public async Task<IActionResult> Item(
            [FromBody, SwaggerRequestBody("Item request payload", Required = true)] ItemRequest model)
        {
            var command = new AddItem(model.Name, model.Price, model.CategoryCode);
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost("category")]
        [SwaggerOperation(Summary = "Add a category", OperationId = nameof(Category))]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Category was successfully added")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "The user was not signed in", typeof(ProblemDetails), ContentType.JsonProblem)]
        public async Task<IActionResult> Category(
            [FromBody, SwaggerRequestBody("Category request payload", Required = true)] AddCategoryRequest model)
        {
            var command = new AddCategory(model.Name, model.Description, model.Code);
            await _mediator.Send(command);

            return NoContent();
        }
    }
}