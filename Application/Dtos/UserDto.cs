using Core.ReadModels;

namespace Application.Dtos;

public class UserDto: BaseReadModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public ICollection<JwtEntity> AccessTokens { get; set; } = new List<JwtEntity>();
}