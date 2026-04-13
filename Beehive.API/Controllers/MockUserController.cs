using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/mock-user")]
public class MockUserController : ControllerBase
{
    private readonly IMockuserService _service;

    public MockUserController(IMockuserService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get([FromQuery] MockUserRequest request)
    {
        var result = _service.Generate(request);

        if(request.Format?.ToLower() == "text")
        {
            return Content(result.ToString() ?? string.Empty, "text/plain");
        }
        return Ok(result);
    }
}