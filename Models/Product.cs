namespace TestRepoBE.Models;

public record Product(int Id, string Name, string Category, decimal Price, int Stock);

public record CreateProductRequest(string Name, string Category, decimal Price, int Stock);
