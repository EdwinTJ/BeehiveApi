using System;
using System.Linq;

public class LoremGenerator : ILoremGenerator
{
    private static readonly string[] Words =
    {
        "lorem", "ipsum", "dolor", "sit", "amet", "consectetur",
        "adipiscing", "elit", "pontificating", "fast", "blazing",
        "prime", "non", "officai", "mollit", "id", "nulla",
        "obseq", "eu", "in", "aliqua", "ex", "ae", "ea",
        "Ut", "xe", "fugiat", "working", "booping", "baking"
    };

    public string GenerateWords(int count)
    {
        var rnd = new Random();
        return string.Join(" ", Enumerable.Range(0, count)
            .Select(_ => Words[rnd.Next(Words.Length)]));
    }
}