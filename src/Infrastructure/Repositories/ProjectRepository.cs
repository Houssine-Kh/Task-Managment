using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;
        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Project?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Projects.Include(p => p.Tasks).FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Project>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Projects.Include(p => p.Tasks).ToListAsync(cancellationToken);
        }

        public async Task SaveAsync(Project project, CancellationToken cancellationToken = default)
        {
            if (_context.Projects.Any(p => p.Id == project.Id))
            {
                _context.Projects.Update(project);
            }
            else
            {
                await _context.Projects.AddAsync(project, cancellationToken);
            }

            await _context.SaveChangesAsync(cancellationToken);
        }
        
    }
}