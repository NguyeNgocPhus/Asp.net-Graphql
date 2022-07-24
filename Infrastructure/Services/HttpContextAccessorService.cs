using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Infrastructure.Services;

public class HttpContextAccessorService : IHttpContextAccessorService
{
    private readonly IHttpContextAccessor _httpContextAccessor;


    public HttpContextAccessorService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? GetRequestHeader(string key)
    {
        StringValues jwt = _httpContextAccessor.HttpContext.Request.Headers.ContainsKey(key) ?  _httpContextAccessor.HttpContext.Request.Headers[key]:new StringValues();

        return jwt;
    }

    public void SetResponseHeader(string key)
    {
        throw new NotImplementedException();
    }
}