using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;
using MediatR;

namespace ApplicationLayer.Users.Querries
{
    public class GettAllUsersQuery : IRequest<List<User>>
    {
        
    }
}
