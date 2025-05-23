﻿using DomainLayer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}
