using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private static readonly List<object> _orders = new()
    {
        new { Id = 1, CustomerId = 1, ProductId = 2, Quantity = 2, Total = 59.98, Status = "Completado" },
        new { Id = 2, CustomerId = 2, ProductId = 1, Quantity = 1, Total = 999.99, Status = "Pendiente" },
        new { Id = 3, CustomerId = 3, ProductId = 3, Quantity = 3, Total = 149.97, Status = "En proceso" }
    };

    [HttpGet]
    public IActionResult GetAll() => Ok(_orders);

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var order = _orders.ElementAtOrDefault(id - 1);
        if (order is null) return NotFound(new { Message = $"Orden con id {id} no encontrada." });
        return Ok(order);
    }
}
