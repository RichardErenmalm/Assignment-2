using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;
using MediatR;

namespace ApplicationLayer.Reviews.Querries.GetAllReviews
{
    public class GetAllReviewsQuery : IRequest<List<Review>>
    {
    }
}
