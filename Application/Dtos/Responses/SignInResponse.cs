namespace Application.Dtos.Responses;

public class SignInResponse : ResponseBase
{
    public string Token { get; set; } = "";
    public string RefreshToken { get; set; } = "";
}