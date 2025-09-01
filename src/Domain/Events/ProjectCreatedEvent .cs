using System;
using Domain.Abstractions;

namespace Domain.Events
{
    public class ProjectCreatedEvent : IDomainEvent
    {
        public Guid ProjectId { get; }
        public string Name { get; }
        public DateTime OccurredOnUtc { get; } = DateTime.UtcNow;

        public ProjectCreatedEvent(Guid projectId, string name)
        {
            ProjectId = projectId;
            Name = name;
        }
    }
}
