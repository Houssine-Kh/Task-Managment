using System;
using Domain.Abstractions;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class TaskItem : Entity
    {
        public string Title { get; private set; }
        public TaskState Status { get; private set; } = TaskState.Pending;
        public DueDate DueDate { get; private set; }
        public Guid? AssignedUserId { get; private set; }

        public TaskItem(string title, DueDate dueDate)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            DueDate = dueDate ?? throw new ArgumentNullException(nameof(dueDate));
        }
        // Parameterless constructor for EF Core
        protected TaskItem() { }

        public void Complete()
        {
            if (Status == TaskState.Completed)
                throw new InvalidOperationException("Task is already completed.");

            Status = TaskState.Completed;
        }

        public void AssignTo(Guid userId)
        {
            AssignedUserId = userId;
        }
    }
}
