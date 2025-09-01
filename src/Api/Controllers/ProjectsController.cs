using System;
using System.Collections.Generic;
using System.Linq;
using Application.Commands;
using Application.Queries;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] CreateProjectCommand command)
        {
            var projectId = await _mediator.Send(command);
            return Ok(projectId);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            var projects = await _mediator.Send(new GetAllProjectsQuery());
            return Ok(projects);
        }
        [HttpGet("{projectId}")]
        public async Task<IActionResult> GetProjectById(Guid projectId)
        {
            var project = await _mediator.Send(new GetProjectByIdQuery(projectId));
            if (project == null) return NotFound();
            return Ok(project);
        }

        [HttpGet("overdue")]
        public async Task<IActionResult> GetOverdueTasks()
        {
            var tasks = await _mediator.Send(new GetOverdueTasksQuery(DateTime.UtcNow));
            return Ok(tasks);
        }

    }
}