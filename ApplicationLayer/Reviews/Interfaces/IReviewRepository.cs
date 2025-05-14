using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Reviews.Interfaces
{
    public interface IReviewRepository
    {
       Task<string> AddReviewAsync(Review review);
        Task<List<Review>> GetAllReviewsFromDbAsync();

        Task UpdateReviewAsync(Review review);

        Task<Review> GetByIdAsync(int id);

        Task DeleteReviewAsync(Review review);
    }
}
