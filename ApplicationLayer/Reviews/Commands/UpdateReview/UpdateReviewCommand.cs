using ApplicationLayer.DTOs.ReviewDTOs;
using DomainLayer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Reviews.Commands.UpdateReview
{
    public class UpdateReviewCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public int Rating { get; set; }

        public UpdateReviewCommand(int id, int rating, string? content)
        {
            Id = id;
            Rating = rating;
            Content = content;
        }
    }
}
