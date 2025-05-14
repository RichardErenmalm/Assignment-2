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
    //tror jag ska hitta user med rätt id och byta ut detaljerna till det nyskrivna 
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.User.Id);
            if (user == null) return false;

            user.Name = request.User.Name;
            user.Email = request.User.Email;


            await _userRepository.UpdateUserAsync(user);
            return true;
        }
    }
}
