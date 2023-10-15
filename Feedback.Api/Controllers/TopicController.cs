using Feedback.Api.Database;
using Feedback.Api.Database.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Feedback.Api.Controllers;

public class TopicController : BaseController
{
    private readonly FeedbackContext _context;

    public TopicController(FeedbackContext context)
    {
        _context = context;
    }

    [Authorize]
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Topics.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        Topic? topic = _context.Topics.Find(id);

        if (topic is not null)
            return Ok(topic);

        return NotFound(new ProblemDetails() 
            { Status = StatusCodes.Status404NotFound, Detail = "Такого предмета нет" });
    }
}