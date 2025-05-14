using ApplicationLayer.DTOs.ReviewDTOs;
using DomainLayer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Reviews.Commands.CreateReview
{
    public class CreateReviewCommand : IRequest<string>
    {
        public ReviewDTO Review { get; set; }

        public CreateReviewCommand(ReviewDTO review)
        {
            Review = review;
        }
    }

}
