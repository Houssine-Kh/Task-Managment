using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Domain.Entities;

namespace Application.Queries
{
    public record GetTasksByUserQuery( Guid UserId ) : IRequest<IEnumerable<TaskItem>>;
 
}