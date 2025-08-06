using MediatR;
using Microsoft.AspNetCore.Mvc;
using Search.UseCase.GetTasks;

namespace Search.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {

        private readonly ILogger<TaskController> _logger;
        private readonly IMediator _mediator;
        public TaskController(ILogger<TaskController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks([FromQuery] GetTasksQuery getTasksQuery)
        {
            var response = await _mediator.Send(getTasksQuery);

            return Ok(response);
        }
    }
}
