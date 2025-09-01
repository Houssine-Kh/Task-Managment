using System;
using System.Collections.Generic;
using MediatR;
using Domain.Entities;

namespace Application.Queries
{
    public record GetTasksByProjectQuery(Guid ProjectId) : IRequest<IEnumerable<TaskItem>>;
}

