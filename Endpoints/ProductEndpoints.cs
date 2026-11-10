using TestRepoBE.Data;
using TestRepoBE.Models;

namespace TestRepoBE.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/products");

        group.MapGet("/", (MockData data, string? category) =>
        {
            var products = data.GetProducts();
            return string.IsNullOrWhiteSpace(category)
                ? products
                : products.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
        });

        group.MapGet("/{id:int}", (MockData data, int id) =>
            data.GetProduct(id) is { } product ? Results.Ok(product) : Results.NotFound());

        group.MapPost("/", (MockData data, CreateProductRequest request) =>
        {
            if (string.IsNullOrWhiteSpace(request.Name) || request.Price < 0 || request.Stock < 0)
                return Results.BadRequest(new { error = "Name is required and price/stock must be non-negative." });

            var product = data.AddProduct(request);
            return Results.Created($"/api/products/{product.Id}", product);
        });

        group.MapDelete("/{id:int}", (MockData data, int id) =>
            data.DeleteProduct(id) ? Results.NoContent() : Results.NotFound());
    }
}
