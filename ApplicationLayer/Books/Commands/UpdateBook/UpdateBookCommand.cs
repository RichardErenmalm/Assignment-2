
using ApplicationLayer.DTOs.BookDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Books.Commands.UpdateBook
{
    public class UpdateBookCommand : IRequest<bool>
    {
        public GetBookDTO Book { get; set; } 

        public UpdateBookCommand(GetBookDTO book)
        {
            Book = book;
        }
    }
}
