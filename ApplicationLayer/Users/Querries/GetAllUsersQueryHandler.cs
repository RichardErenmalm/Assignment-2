using ApplicationLayer.Users.Interfaces.UserInterface;
using DomainLayer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Users.Querries
{
    public class GetAllUsersQueryHandler : IRequestHandler<GettAllUsersQuery, List<User>>
    {
        public readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<List<User>> Handle(GettAllUsersQuery request, CancellationToken cancellationToken)
        {
           return Task.FromResult(_userRepository.GetUsersFromRepositoryAndDb());
      
        }
    }
}
