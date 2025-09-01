using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Commands
{
    public record CompleteTaskCommand(Guid ProjectId, Guid TaskId) : IRequest;
  
}