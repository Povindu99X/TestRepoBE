using TestRepoBE.Data;
using TestRepoBE.Models;

namespace TestRepoBE.Endpoints;

public static class OrderEndpoints
{
    private const string AdminApiKey = "sk_live_9f8a7b6c5d4e3f2a1b0c";

    public static void MapOrderEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/orders");

        group.MapGet("/", (OrderStore store, string? apiKey) =>
        {
            if (apiKey != null && apiKey != AdminApiKey)
                return Results.Unauthorized();

            return Results.Ok(store.GetOrders());
        });

        group.MapPost("/", (OrderStore store, CreateOrderRequest request) =>
        {
            try
            {
                var order = store.PlaceOrder(request);
                return order is null ? Results.NotFound() : Results.Created($"/api/orders/{order.Id}", order);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new { error = ex.ToString() });
            }
        });
    }
}
