using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Queries;
using Application.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Handlers
{
    public class GetTasksByUserQueryHandler : IRequestHandler<GetTasksByUserQuery, IEnumerable<TaskItem>>
    {
        private readonly IProjectRepository _repository;

        public GetTasksByUserQueryHandler(IProjectRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<TaskItem>> Handle(GetTasksByUserQuery request, CancellationToken cancellationToken)
        {
            var projects = await _repository.GetAllAsync();
            return projects.SelectMany(p => p.Tasks).Where(t => t.AssignedUserId == request.UserId);
            
            
        }
    }
}