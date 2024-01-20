using GlobalTicket.TicketManagement.Application.Features.Categories.Commands;
using GlobalTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using GlobalTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GlobalTicket.TicketManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("all", Name = "GetAllCategories")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryListVm>>> GetAllCategories()
        {
            var dtos = await _mediator.Send(new GetCategoryListQuery());
            return Ok(dtos);
        }

        [Route("allwithevents", Name = "GetCategoriesWithEvents")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<List<CategoryEventListVm>>> GetCategoriesWithEvents(bool includeHistory)
        {
            var getCategoryListWithEventsQuery = new GetCategoriesListWithEventsQuery()
            { IncludeHistory = includeHistory };

            var dtos = await _mediator.Send(getCategoryListWithEventsQuery);
            return Ok(dtos);
        }

        [Route("addcategory", Name = "AddCategory")]
        [HttpPost]
        public async Task<ActionResult<CreateCategoryCommandResponse>> Create([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            var reponse = await _mediator.Send(createCategoryCommand);
            return Ok(reponse);
        }
    }
}
