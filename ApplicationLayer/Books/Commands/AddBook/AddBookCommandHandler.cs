using ApplicationLayer.DTOs.BookDTOs;
using ApplicationLayer.Users.Commands.CreateUser;
using DomainLayer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Books.Commands.AddBook
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, string>
    {
        public readonly IBookRepository _repository;

        public AddBookCommandHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {

            var book = new Book
            {
                Author = request.Book.Author,
                Title = request.Book.Title
            };

            return await _repository.AddBookAsync(book);
        }
    }
}
