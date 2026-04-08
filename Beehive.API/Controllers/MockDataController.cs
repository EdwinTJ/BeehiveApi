using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/mockdata")]
public class MockDataController : ControllerBase
{
    private readonly IMockDataService _service;


    public MockDataController(IMockDataService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get([FromQuery] MockDataRequest request)
    {
        var result = _service.Generate(request);

        if(result == null)
        {
            return NotFound("Mock Data could not be generated");    
        }

        if (request.Format?.ToLower() == "text")
            return Content(result.ToString() ?? string.Empty ,"text/plain");

        return Ok(result);
    }
}