using ApplicationLayer.DTOs;
using ApplicationLayer.Users.Commands.CreateUser;
using ApplicationLayer.Users.Interfaces.UserInterface;
using DomainLayer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<bool>
    {
       public User User { get; set; }

        public UpdateUserCommand(User user)
        {
           User = user;
        }
    }
}
