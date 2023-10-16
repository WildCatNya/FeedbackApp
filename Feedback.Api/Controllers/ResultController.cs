using Feedback.Api.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Feedback.Api.Controllers;

public class ResultController : BaseController
{
    public ResultController(FeedbackContext context) : base(context) { }

    [Authorize]
    [HttpGet]
    public IActionResult GetAll() =>
        Ok(_context.Results.ToList());
}