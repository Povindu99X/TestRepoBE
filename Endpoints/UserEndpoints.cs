using TestRepoBE.Data;

namespace TestRepoBE.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/users", (MockData data) => data.GetUsers());
    }
}
