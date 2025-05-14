using ApplicationLayer.DTOs.BookDTOs;
using DomainLayer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Books.Querries
{
    public class GetAllBooksQuery : IRequest<List<Book>>
    {


    }
}
