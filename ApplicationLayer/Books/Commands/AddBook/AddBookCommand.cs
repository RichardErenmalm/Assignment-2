using ApplicationLayer.DTOs.BookDTOs;
using ApplicationLayer.Pipelinebehavior;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Books.Commands.AddBook
{
    public class AddBookCommand : IRequest<string>
    {
        public BookDTO Book { get; set; }

        public AddBookCommand(BookDTO book)
        {
            Book = book;
        }
    }
}
