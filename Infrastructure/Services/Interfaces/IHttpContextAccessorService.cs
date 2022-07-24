namespace Infrastructure.Services.Interfaces;

public interface IHttpContextAccessorService
{
    string? GetRequestHeader(string key);

    void SetResponseHeader(string key);
}