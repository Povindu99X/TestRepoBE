using TestRepoBE.Models;

namespace TestRepoBE.Data;

public class MockData
{
    private readonly Lock _lock = new();

    private readonly List<Product> _products =
    [
        new(1, "Wireless Mouse", "Electronics", 24.99m, 120),
        new(2, "Mechanical Keyboard", "Electronics", 89.50m, 45),
        new(3, "Coffee Mug", "Kitchen", 9.99m, 300),
        new(4, "Desk Lamp", "Home", 34.00m, 60),
        new(5, "Notebook", "Stationery", 4.25m, 500),
    ];

    private readonly List<User> _users =
    [
        new(1, "Alice Perera", "alice@example.com", "Admin"),
        new(2, "Bob Silva", "bob@example.com", "User"),
        new(3, "Chamari Fernando", "chamari@example.com", "User"),
    ];

    public IReadOnlyList<Product> GetProducts()
    {
        lock (_lock) return _products.ToList();
    }

    public Product? GetProduct(int id)
    {
        lock (_lock) return _products.FirstOrDefault(p => p.Id == id);
    }

    public Product AddProduct(CreateProductRequest request)
    {
        lock (_lock)
        {
            var product = new Product(
                _products.Count == 0 ? 1 : _products.Max(p => p.Id) + 1,
                request.Name,
                request.Category,
                request.Price,
                request.Stock);
            _products.Add(product);
            return product;
        }
    }

    public bool DeleteProduct(int id)
    {
        lock (_lock) return _products.RemoveAll(p => p.Id == id) > 0;
    }

    public void UpdateStock(int id, int stock)
    {
        lock (_lock)
        {
            var index = _products.FindIndex(p => p.Id == id);
            if (index >= 0) _products[index] = _products[index] with { Stock = stock };
        }
    }

    public IReadOnlyList<User> GetUsers()
    {
        lock (_lock) return _users.ToList();
    }
}
