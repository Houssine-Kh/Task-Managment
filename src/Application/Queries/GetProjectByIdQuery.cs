using System;
using Domain.Entities;
using MediatR;

namespace Application.Queries
{
    public record GetProjectByIdQuery(Guid ProjectId) : IRequest<Project>;
}
