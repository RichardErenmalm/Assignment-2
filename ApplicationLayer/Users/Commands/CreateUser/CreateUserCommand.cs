using ApplicationLayer.Pipelinebehavior;
using DomainLayer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<string>
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
