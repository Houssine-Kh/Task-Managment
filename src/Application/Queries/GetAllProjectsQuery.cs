using MediatR;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Queries
{
    public record GetAllProjectsQuery() : IRequest<IEnumerable<Project>>;
}
