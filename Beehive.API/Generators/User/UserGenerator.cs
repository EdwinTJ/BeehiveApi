using System;
using System.Collections.Generic;
using System.Linq;
public class UserGenerator  : IUserGenerator
{
    private static readonly string[] Names =
    {
        "alice", "bob", "carol", "edwin", "dave", "eve", "frank", "fabian",
        "grace", "heidi", "ivan", "judy"
    };

    private static readonly string[] Domains =
    {
        "example.com", "exmaple.org", "test.com", "test.org", "mail.com","mail.org", "demo.com", "demo.org",
    };

    public List<string> GenerateEmails(int count)
    {
        var rnd = new Random();
        var emails = new List<string>();

        for (int i = 0; i < count; i++)
        {
            var name = Names[rnd.Next(Names.Length)];
            var number = rnd.Next(1, 1000);
            var domain = Domains[rnd.Next(Domains.Length)];
            emails.Add($"{name}{number}@{domain}");
        }

        return emails;
    }
}

