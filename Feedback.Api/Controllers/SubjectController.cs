using Feedback.Api.Database;
using Feedback.Api.Database.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Feedback.Api.Controllers;

public class SubjectController : BaseController
{
    public SubjectController(FeedbackContext context) 
        : base(context) { }

    [HttpGet]
    public IActionResult GetAll() =>
        Ok(_context.Subjects.Select(x => x.ToDictionaryRequest()).ToList());

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        Subject? subject = _context.Subjects.Find(id);

        if (subject is not null)
            return Ok(subject);

        return NotFound("Такой темы нет");
    }
}