using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MockDataController : ControllerBase
{
    [HttpGet]
    public IActionResult Get(
        [FromQuery] int lorem = 5,
        [FromQuery] string format = "json",
        [FromQuery] int nested = 1)
    {
        var text = GenerateLorem(lorem);

        if(format.ToLower() == "text")
        {
            return Content(text, "text/plain");
        }

        var json = BuildNestedJson(text,nested);
        return Ok(json);
    }

    private string GenerateLorem(int wordCount)
    {
        var words = new[]
        {
            "lorem", "ipsum", "dolor", "sit", "amet", "consectetur", "adipiscing", "elit","pontificating",
            "fast", "blazing", "prime", "pontificating", "non", "officai", "mollit", "id", "nulla", "obseq", "eu",
            "in", "aliqua", "ex", "ae", "ea", "Ut", "xe", "fugiat", "working", "booping", "baking"
        };

        var rnd = new Random();
        return string.Join(" ",Enumerable.Range(0, wordCount).Select(_ => words[rnd.Next(words.Length)]));
    }

    private object BuildNestedJson(string text, int levels)
    {
        object current = new { data = text};

        for (int i = 0; i < levels; i++)
        {
            current = new Dictionary<string, object>
            {
                [$"level{i+1}"] = current
            };
        }
        return current;
    }
}