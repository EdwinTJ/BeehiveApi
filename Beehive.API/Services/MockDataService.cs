using System.Collections.Generic;

public class MockDataService : IMockDataService
{
    private readonly ILoremGenerator _generator;

    public MockDataService(ILoremGenerator generator)
    {
        _generator = generator;
    }

    public object Generate(MockDataRequest request)
    {
        var text = _generator.GenerateWords(request.Lorem);

        if (string.Equals(request.Format, "text", StringComparison.OrdinalIgnoreCase))
            return text;

        return BuildNested(text, request.Nested);
    }

    private object BuildNested(string text, int levels)
    {
        object current = new { data = text };

        for (int i = 0; i < levels; i++)
        {
            current = new Dictionary<string, object>
            {
                [$"level{i + 1}"] = current
            };
        }

        return current;
    }
}