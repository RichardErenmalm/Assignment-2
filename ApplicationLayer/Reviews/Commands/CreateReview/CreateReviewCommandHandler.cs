using ApplicationLayer.Books.Commands.AddBook;
using ApplicationLayer.Reviews.Interfaces;
using DomainLayer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Reviews.Commands.CreateReview
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, string>
    {
        public readonly IReviewRepository _repository;

        public CreateReviewCommandHandler(IReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {

            var review = new Review
            {
                Content = request.Review.Content,
                Rating = request.Review.Rating
            };
            

           return await _repository.AddReviewAsync(review);
        }
    }
}
