using System.Text;
using Codecool.BruteForce.Passwords.Model;

namespace Codecool.BruteForce.Passwords.Generator;

public class PasswordGenerator : IPasswordGenerator
{
    private static readonly Random Random = new();
    private readonly AsciiTableRange[] _characterSets;

    public PasswordGenerator(params AsciiTableRange[] characterSets)
    {
        _characterSets = characterSets;
    }

    public string Generate(int length)
    {
        var sb = new StringBuilder(length);
        for (var i = 0; i < length; i++)
        {
            var randomCharacterSet = GetRandomCharacterSet();
            var randomCharacter = GetRandomCharacter(randomCharacterSet);
            sb.Append(randomCharacter);
        }
        return sb.ToString();
    }

    private AsciiTableRange GetRandomCharacterSet()
    {
        var characterSetsNumber = _characterSets.Length;
        var randomCharacterSet = Random.Next(characterSetsNumber);
        return _characterSets[randomCharacterSet];
    }

    private static char GetRandomCharacter(AsciiTableRange characterSet)
    {
        var lowerBound = characterSet.Start;
        var upperBound = characterSet.End;
        var randomCharNum = Random.Next(lowerBound, upperBound + 1);
        return (char)randomCharNum;
    }
}
