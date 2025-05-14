using ApplicationLayer.DTOs.ReviewDTOs;
using ApplicationLayer.Responses;
using ApplicationLayer.Reviews.Commands.CreateReview;
using ApplicationLayer.Reviews.Commands.DeleteReview;
using ApplicationLayer.Reviews.Commands.UpdateReview;
using ApplicationLayer.Reviews.Querries.GetAllReviews;
using ApplicationLayer.Users.Commands.CreateUser;
using DomainLayer.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        public readonly IMediator _mediator;

        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<ActionResult> CreateReview([FromBody] ReviewDTO review)
        {
            var result = await _mediator.Send(new CreateReviewCommand(review));

            var response = OperationResult<string>.Ok(result, "Recension skapades.");

            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<OperationResult<List<ReviewDTO>>>> GetAllReviews()
        {
            var result = await _mediator.Send(new GetAllReviewsQuery());

            if (result == null || !result.Any())
                return NotFound(OperationResult<List<ReviewDTO>>.Fail("Inga recensioner hittades."));

            return Ok(OperationResult<List<Review>>.Ok(result));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OperationResult<bool>>> UpdateReview(int id, [FromBody] ReviewDTO dto)
        {
            var command = new UpdateReviewCommand(id, dto.Rating, dto.Content);

            var success = await _mediator.Send(command);

            if (!success)
                return NotFound(OperationResult<bool>.Fail("Recensionen kunde inte uppdateras."));

            return Ok(OperationResult<bool>.Ok(true, "Recensionen uppdaterades."));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<OperationResult<bool>>> DeleteReview(int id)
        {
            var success = await _mediator.Send(new DeleteReviewCommand(id));

            if (!success)
                return NotFound(OperationResult<bool>.Fail("Recensionen kunde inte hittas eller tas bort."));

            return Ok(OperationResult<bool>.Ok(true, "Recensionen togs bort."));
        }

    }
}
