using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Handlers
{
    public class CompleteTaskCommandHandler : IRequestHandler<CompleteTaskCommand>
    {
        private readonly IProjectRepository _repository;

        public CompleteTaskCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(CompleteTaskCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetByIdAsync(request.ProjectId) ?? throw new KeyNotFoundException("Project not found.");
            project.CompleteTask(request.TaskId);

            await _repository.SaveAsync(project);
        }


    }
}