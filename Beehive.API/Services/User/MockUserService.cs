public class MockUserService : IMockuserService
{
    private readonly IUserGenerator _generator;

    public MockUserService(IUserGenerator generator)
    {
        _generator = generator;
    }

    public object Generate(MockUserRequest request)
    {
        var emails = _generator.GenerateEmails(request.Count);

        if(request.Format.ToLower() == "text")
        {
            return string.Join(Environment.NewLine, emails);
        }

        return emails;
    }
}