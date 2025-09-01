using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IProjectRepository
    {
        Task<Project?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task SaveAsync(Project project, CancellationToken cancellationToken = default);
        Task<IEnumerable<Project>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
