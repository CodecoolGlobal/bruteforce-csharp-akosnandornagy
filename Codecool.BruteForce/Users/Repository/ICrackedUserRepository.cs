using Codecool.BruteForce.Users.Model;

namespace Codecool.BruteForce.Users.Repository;

public interface ICrackedUserRepository
{
    void Add(string password, TimeSpan elapsedTime);
    public void DeleteAll();
}