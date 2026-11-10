namespace TestRepoBE.Models;

public record Order(int Id, int ProductId, string ProductName, int Quantity, decimal Total, string CustomerEmail, string? Note, DateTime CreatedAt);

public record CreateOrderRequest(int ProductId, int Quantity, decimal UnitPrice, string CustomerEmail, string? Note);
