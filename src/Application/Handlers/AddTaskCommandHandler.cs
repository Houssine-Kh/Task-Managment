using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Application.Commands;
using Application.Repositories;
using Domain.ValueObjects;

namespace Application.Handlers
{
    public class AddTaskCommandHandler : IRequestHandler<AddTaskCommand, Guid>
    {
        private readonly IProjectRepository _repository;

        public AddTaskCommandHandler(IProjectRepository repository) 
        {
            _repository = repository;
        }
        public async Task<Guid> Handle(AddTaskCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetByIdAsync(request.ProjectId) ?? throw new KeyNotFoundException("Project not found.");

            var task = project.AddTask(request.Title, DueDate.FromUtc(request.DueDateUtc));
            await _repository.SaveAsync(project);

            return task.Id;
        }
    }
}