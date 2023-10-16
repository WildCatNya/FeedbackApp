using Feedback.Api.Database;
using Feedback.Api.Database.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Feedback.Api.Controllers;

public class TopicController : BaseController
{
    public TopicController(FeedbackContext context) 
        : base(context) { }

    [HttpGet]
    public IActionResult GetAll() =>
        Ok(_context.Topics.Select(x => x.ToDictionaryRequest()).ToList());

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        Topic? topic = _context.Topics.Find(id);

        if (topic is not null)
            return Ok(topic);

        return NotFound("Такого предмета нет");
    }
}