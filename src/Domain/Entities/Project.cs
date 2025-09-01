using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Abstractions;
using Domain.Events;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Project : AggregateRoot
    {
        public string Name { get; private set; }

        private readonly List<TaskItem> _tasks = new(); // Internal list to manage tasks
        public IReadOnlyList<TaskItem> Tasks => _tasks.AsReadOnly(); // Expose tasks as read-only list to outside world 

        public Project(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Raise(new ProjectCreatedEvent(Id, name));
        }

        public TaskItem AddTask(string title, DueDate dueDate)
        {
            var task = new TaskItem(title, dueDate);
            _tasks.Add(task);
            return task;
        }

        public void AssignTask(Guid taskId, Guid userId)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == taskId)
                       ?? throw new KeyNotFoundException("Task not found.");
            task.AssignTo(userId);
            Raise(new TaskAssignedEvent(Id, taskId, userId));
        }

        public void CompleteTask(Guid taskId)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == taskId)
                       ?? throw new KeyNotFoundException("Task not found.");
            task.Complete();
            Raise(new TaskCompletedEvent(Id, taskId));
        }
    }
}
