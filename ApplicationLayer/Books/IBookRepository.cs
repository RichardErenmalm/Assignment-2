using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLayer.DTOs.BookDTOs;
using DomainLayer.Models;

namespace ApplicationLayer.Books
{
    public interface IBookRepository
    {
        public List<Book> GetAllBooks();
        public Task<Book?> GetByIdAsync(int id);

        Task UpdateBookAsync(Book book);

        public Task<string> AddBookAsync(Book book);

        public Task DeleteBookAsync(Book book);
    }
}