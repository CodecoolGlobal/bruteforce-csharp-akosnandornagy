using Codecool.BruteForce.Passwords.Generator;

namespace Codecool.BruteForce.Users.Generator;

public class UserGenerator : IUserGenerator
{
    private static readonly Random Random = new();
    private readonly List<IPasswordGenerator> _passwordGenerators;

    public UserGenerator(IEnumerable<IPasswordGenerator> passwordGenerators)
    {
        _passwordGenerators = passwordGenerators.ToList();
    }

    public IEnumerable<(string userName, string password)> Generate(int count, int maxPasswordLength)
    {
        var usersList = new List<(string userName, string password)>();
        for (var i = 0; i < count; i++)
        {
            var userName = $"user{i + 1}";
            var passwordGenerator = GetRandomPasswordGenerator();
            var password = passwordGenerator.Generate(GetRandomPasswordLength(maxPasswordLength));
            var user = (userName, password);
            usersList.Add(user);
        }
        return usersList.AsEnumerable();
    }

    private IPasswordGenerator GetRandomPasswordGenerator()
    {
        var passwordGeneratorsNumber = _passwordGenerators.Count;
        var randomPasswordGenerator = Random.Next(passwordGeneratorsNumber);
        return _passwordGenerators[randomPasswordGenerator];
    }

    private static int GetRandomPasswordLength(int maxPasswordLength)
    {
        var passwordLenght = Random.Next(1, maxPasswordLength);
        return passwordLenght;
    }
}
