using System;
using Domain.Abstractions;

namespace Domain.Events
{
    public class TaskCompletedEvent : IDomainEvent
    {
        public Guid ProjectId { get; }
        public Guid TaskId { get; }
        public DateTime OccurredOnUtc { get; } = DateTime.UtcNow;

        public TaskCompletedEvent(Guid projectId, Guid taskId)
        {
            ProjectId = projectId;
            TaskId = taskId;
        }
    }
}
