using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.Repositories;
using MediatR;

namespace Application.Handlers
{
    public class AssignTaskCommandHandler : IRequestHandler<AssignTaskCommand>
    {
        private readonly IProjectRepository _repository;
        public AssignTaskCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(AssignTaskCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetByIdAsync(request.ProjectId)?? throw new KeyNotFoundException("Project not found.");
            project.AssignTask(request.TaskId, request.UserId);
            await _repository.SaveAsync(project);

        }
    }
}