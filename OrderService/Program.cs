var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/order", (OrderRequest req) =>
{
    return Results.Ok(new { success = true, orderId = Random.Shared.Next(10000, 99999), message = $"Placed order for {req.Quantity} of item {req.ItemId}" });
});

app.MapGet("/order/{id}", (int id) =>
{
    return Results.Ok(new { orderId = id, status = "Processing", totalAmount = 49.99, estimatedDelivery = DateTime.Now.AddDays(2).ToString("yyyy-MM-dd") });
});

app.Run();

public class OrderRequest
{
    public int ItemId { get; set; }
    public int Quantity { get; set; }
}
