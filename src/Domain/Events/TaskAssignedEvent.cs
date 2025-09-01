using System;
using Domain.Abstractions;

namespace Domain.Events
{
    public class TaskAssignedEvent : IDomainEvent
    {
        public Guid ProjectId { get; }
        public Guid TaskId { get; }
        public Guid UserId { get; }
        public DateTime OccurredOnUtc { get; } = DateTime.UtcNow;

        public TaskAssignedEvent(Guid projectId, Guid taskId, Guid userId)
        {
            ProjectId = projectId;
            TaskId = taskId;
            UserId = userId;
        }
    }
}
