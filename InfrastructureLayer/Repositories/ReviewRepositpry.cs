using ApplicationLayer.Reviews.Interfaces;
using DomainLayer.Models;
using InfrastructureLayer.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        public readonly AppDbContext _Context;

        public ReviewRepository(AppDbContext context) { _Context = context; }

        public async Task<string> AddReviewAsync(Review review)
        {
            _Context.Reviews.Add(review);
            await _Context.SaveChangesAsync();
            return review.Content;  
        }

        public async Task<List<Review>> GetAllReviewsFromDbAsync()
        {
            return await _Context.Reviews.ToListAsync();
        }

        public async Task UpdateReviewAsync(Review review)
        {
           _Context.Update(review);
            await _Context.SaveChangesAsync();
        } 

        public async Task<Review> GetByIdAsync(int id)
        {
            return await _Context.Reviews.FindAsync(id);
        }

        public async Task DeleteReviewAsync(Review review)
        {
            _Context.Reviews.Remove(review);
            await _Context.SaveChangesAsync();
        }
    }
}
