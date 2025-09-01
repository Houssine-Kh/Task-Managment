using System;
using Domain.Entities;
using Domain.ValueObjects;
using Domain.Events;
using Xunit;
using FluentAssertions;

namespace Tests.Domain
{
    public class ProjectTests
    {
        [Fact]
        public void AddTask_Should_Add_Task_To_Project()
        {
            var project = new Project("Test Project");
            var dueDate = DueDate.FromUtc(DateTime.UtcNow.AddDays(1));

            var task = project.AddTask("New Task", dueDate);

            project.Tasks.Should().Contain(task);
            task.Title.Should().Be("New Task");
            task.Status.Should().Be(TaskState.Pending);
        }

        [Fact]
        public void CompleteTask_Should_Set_TaskStatus_To_Completed_And_Raise_Event()
        {
            var project = new Project("Test Project");
            var dueDate = DueDate.FromUtc(DateTime.UtcNow.AddDays(1));
            var task = project.AddTask("New Task", dueDate);

            project.CompleteTask(task.Id);

            task.Status.Should().Be(TaskState.Completed);
            project.DomainEvents.Should().ContainSingle(e => e is TaskCompletedEvent);
        }

        [Fact]
        public void AssignTask_Should_Assign_User_And_Raise_Event()
        {
            var project = new Project("Test Project");
            var dueDate = DueDate.FromUtc(DateTime.UtcNow.AddDays(1));
            var task = project.AddTask("New Task", dueDate);

            var userId = Guid.NewGuid();
            project.AssignTask(task.Id, userId);

            task.AssignedUserId.Should().Be(userId);
            project.DomainEvents.Should().ContainSingle(e => e is TaskAssignedEvent);
        }
    }
}
