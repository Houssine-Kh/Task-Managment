using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using MediatR;
using Application.Repositories;
using Domain.Entities;

namespace Application.Handlers
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Guid>
    {
        private readonly IProjectRepository _repository;

        public CreateProjectCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

         public async Task<Guid> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project(request.Name);
            await _repository.SaveAsync(project, cancellationToken);
            return project.Id;
        }
    }
}