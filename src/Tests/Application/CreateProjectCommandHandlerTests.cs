using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Commands;
using Application.Handlers;
using Application.Repositories;
using Domain.Entities;
using Moq;
using Xunit;
using FluentAssertions;

namespace Tests.Application
{
    public class CreateProjectCommandHandlerTests
    {
        [Fact]
        public async Task Handle_Should_Create_Project_And_Save()
        {
            // Arrange
            var mockRepo = new Mock<IProjectRepository>();
            var handler = new CreateProjectCommandHandler(mockRepo.Object);
            var command = new CreateProjectCommand("Test Project");

            // Act
            var projectId = await handler.Handle(command, CancellationToken.None);

            // Assert
            projectId.Should().NotBe(Guid.Empty);
            mockRepo.Verify(r => r.SaveAsync(It.Is<Project>(p => p.Name == "Test Project"), default), Times.Once);
        }
    }
}
