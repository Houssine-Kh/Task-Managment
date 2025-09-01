using MediatR;
using Application.Repositories;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Queries;

namespace Application.Handlers
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, IEnumerable<Project>>
    {
        private readonly IProjectRepository _repository;

        public GetAllProjectsQueryHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Project>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync(cancellationToken);
        }
    }
}
