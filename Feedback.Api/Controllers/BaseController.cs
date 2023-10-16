using Feedback.Api.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Feedback.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected readonly FeedbackContext _context;

    protected BaseController(FeedbackContext context)
    {
        _context = context;
    }

    public override BadRequestObjectResult BadRequest([ActionResultObjectValue] object? error) =>
        base.BadRequest(new ProblemDetails() 
            { Status = StatusCodes.Status400BadRequest, Detail = error.ToString() });

    public override NotFoundObjectResult NotFound([ActionResultObjectValue] object? value) =>
        base.NotFound(new ProblemDetails() 
            {  Status = StatusCodes.Status404NotFound, Detail = value.ToString() });
}