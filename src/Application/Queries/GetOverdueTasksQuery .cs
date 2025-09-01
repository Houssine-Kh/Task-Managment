using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;

namespace Application.Queries
{
    public record GetOverdueTasksQuery(DateTime NowUtc) : IRequest<IEnumerable<TaskItem>>;

}