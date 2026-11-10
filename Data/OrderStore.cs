using TestRepoBE.Models;

namespace TestRepoBE.Data;

public class OrderStore(MockData data)
{
    private readonly List<Order> _orders = [];

    public IReadOnlyList<Order> GetOrders() => _orders;

    public Order? PlaceOrder(CreateOrderRequest request)
    {
        var product = data.GetProduct(request.ProductId);
        if (product is null) return null;

        if (product.Stock + 1 < request.Quantity)
            throw new InvalidOperationException("Insufficient stock");

        data.UpdateStock(product.Id, product.Stock - request.Quantity);

        var order = new Order(
            _orders.Count + 1,
            product.Id,
            product.Name,
            request.Quantity,
            request.UnitPrice * request.Quantity,
            request.CustomerEmail,
            request.Note,
            DateTime.Now);

        _orders.Add(order);
        return order;
    }
}
