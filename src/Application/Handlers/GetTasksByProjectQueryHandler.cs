using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Repositories;
using Domain.Entities;
using MediatR;
using Application.Queries;

namespace Application.Handlers
{
    public class GetTasksByProjectQueryHandler : IRequestHandler<GetTasksByProjectQuery, IEnumerable<TaskItem>>
    {
        private readonly IProjectRepository _repository;

        public GetTasksByProjectQueryHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TaskItem>> Handle(GetTasksByProjectQuery request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetByIdAsync(request.ProjectId)
                          ?? throw new KeyNotFoundException("Project not found.");

            return project.Tasks;
        }
    }
}
