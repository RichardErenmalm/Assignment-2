using ApplicationLayer.Users.Commands.UpdateUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, bool>
    {
        public readonly IBookRepository _repository;

        public UpdateBookCommandHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _repository.GetByIdAsync(request.Book.Id);
            if (book ==null) return false;

            book.Author = request.Book.Author;
            book.Title = request.Book.Title;

            await _repository.UpdateBookAsync(book);
            return true;
        }

    }
}
