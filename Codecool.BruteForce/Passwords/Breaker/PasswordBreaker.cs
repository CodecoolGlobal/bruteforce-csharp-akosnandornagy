using System.Text;
using Codecool.BruteForce.Passwords.Model;

namespace Codecool.BruteForce.Passwords.Breaker;

public class PasswordBreaker : IPasswordBreaker
{
    public IEnumerable<string> GetCombinations(int passwordLength)
    {
        var allChars = GetAllCharacters();
    
        for (var i = 0; i < Math.Pow(allChars.Length, passwordLength); i++)
        {
            var sb = new StringBuilder();
            var temp = i;
            for (var j = 0; j < passwordLength; j++)
            {
                sb.Append(allChars[temp % allChars.Length]);
                temp /= allChars.Length;
            }
            yield return sb.ToString();
        }
    }

    private static IEnumerable<string> GetAllPossibleCombos(IEnumerable<IEnumerable<string>> strings)
    {
        IEnumerable<string> combos = new[] { "" };

        combos = strings
            .Aggregate(combos, (current, inner) => current.SelectMany(c => inner, (c, i) => c + i));

        return combos;
    }

    private char[] GetAllCharacters()
    {
        var lowercaseArray = Enumerable.Range(97, 26)
            .Select(i => (char)i).ToArray();
        var uppercaseArray = Enumerable.Range(65, 26)
            .Select(i => (char)i).ToArray();
        var numbersArray = Enumerable.Range(48, 10)
            .Select(i => (char)i).ToArray();
        
        var allChars = lowercaseArray.Concat(uppercaseArray).Concat(numbersArray).ToArray();

        return allChars;
    }
}
