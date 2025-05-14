using ApplicationLayer.Users.Interfaces.UserInterface;
using DomainLayer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            //denna är här för när du ändrar till dto sen så gör vi riktiga user här från dton
            var user = new User
            {
                Name = request.Name,
                Email = request.Email

            };
            return _userRepository.AddUserAsync(user);
        }
    }
}
