using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Commands
{
    public record CreateProjectCommand(string Name) : IRequest<Guid>; 
   
}