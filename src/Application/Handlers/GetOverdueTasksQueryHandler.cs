using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR.Pipeline;
using Application.Queries;
using Application.Repositories;
using Domain.ValueObjects;
using MediatR;

namespace Application.Handlers
{
    public class GetOverdueTasksQueryHandler : IRequestHandler<GetOverdueTasksQuery, IEnumerable<TaskItem>>
    {
        private readonly IProjectRepository _repository;

        public GetOverdueTasksQueryHandler(IProjectRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<TaskItem>> Handle(GetOverdueTasksQuery request, CancellationToken cancellationToken)
        {
            var projects = await _repository.GetAllAsync();
            return projects.SelectMany(p => p.Tasks).Where(t => t.DueDate.ValueUtc < request.NowUtc && t.Status != TaskState.Completed);
        }
    }
}