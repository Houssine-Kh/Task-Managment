using System.Threading;
using System.Threading.Tasks;
using Application.Repositories;
using Domain.Entities;
using MediatR;
using Application.Queries;

namespace Application.Handlers
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, Project>
    {
        private readonly IProjectRepository _repository;

        public GetProjectByIdQueryHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<Project> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.ProjectId, cancellationToken);
        }
    }
}
