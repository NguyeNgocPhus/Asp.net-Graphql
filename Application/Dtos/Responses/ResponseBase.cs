namespace Application.Dtos.Responses;

public class ResponseBase
{
    public Guid Id { get; set; }
    public bool Success { get; set; } = true;
}