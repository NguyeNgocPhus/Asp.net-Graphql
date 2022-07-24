using Infrastructure.Services.Interfaces;

namespace Infrastructure.Services;

public class PasswordGeneratorService : IPasswordGeneratorService
{
    public string GenerateRandomPassword()
    {
        throw new NotImplementedException();
    }

    public string GenerateRandomOtp()
    {
        throw new NotImplementedException();
    }

    public string HashPassword(string password)
    {
        throw new NotImplementedException();
    }

    public bool VerifyHashPassword(string? hashedPassword, string password)
    {
        throw new NotImplementedException();
    }
}