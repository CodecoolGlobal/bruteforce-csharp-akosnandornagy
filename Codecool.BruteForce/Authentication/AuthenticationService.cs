using Codecool.BruteForce.Users.Repository;

namespace Codecool.BruteForce.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;
    
    public AuthenticationService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public bool Authenticate(string userName, string password)
    {
        var users = _userRepository.GetAll();
        return users.Any(u => u.UserName == userName && u.Password == password);
    }
}