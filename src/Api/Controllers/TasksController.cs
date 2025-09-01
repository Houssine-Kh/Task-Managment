using System;
using System.Threading.Tasks;
using Application.Commands;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] AddTaskCommand command)
        {
            var taskId = await _mediator.Send(command);
            return Ok(taskId);
        }

        [HttpPost("{taskId}/complete")]
        public async Task<IActionResult> CompleteTask(Guid taskId, [FromBody] CompleteTaskCommand command)
        {
            if (taskId != command.TaskId) return BadRequest();
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPost("{taskId}/assign")]
        public async Task<IActionResult> AssignTask(Guid taskId, [FromBody] AssignTaskCommand command)
        {
            if (taskId != command.TaskId) return BadRequest();
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("project/{projectId}")]
        public async Task<IActionResult> GetTasksByProject(Guid projectId)
        {
            var tasks = await _mediator.Send(new GetTasksByProjectQuery(projectId));
            return Ok(tasks);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetTasksByUser(Guid userId)
        {
            var tasks = await _mediator.Send(new GetTasksByUserQuery(userId));
            return Ok(tasks);
        }

        [HttpGet("overdue")]
        public async Task<IActionResult> GetOverdueTasks()
        {
            var tasks = await _mediator.Send(new GetOverdueTasksQuery(DateTime.UtcNow));
            return Ok(tasks);
        }
    }
}
