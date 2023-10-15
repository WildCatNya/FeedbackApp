using Microsoft.AspNetCore.Mvc;

namespace Feedback.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public abstract class BaseController : ControllerBase { }
