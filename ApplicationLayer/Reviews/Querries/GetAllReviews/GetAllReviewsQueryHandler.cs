using ApplicationLayer.Reviews.Interfaces;
using ApplicationLayer.Users.Interfaces.UserInterface;
using DomainLayer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Reviews.Querries.GetAllReviews
{
    public class GetAllReviewsQueryHandler : IRequestHandler<GetAllReviewsQuery, List<Review>>
    {
        public readonly IReviewRepository _repository;

        public GetAllReviewsQueryHandler(IReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Review>> Handle(GetAllReviewsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllReviewsFromDbAsync();
        }
    }
}
