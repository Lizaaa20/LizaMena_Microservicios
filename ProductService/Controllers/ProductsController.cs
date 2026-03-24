using Microsoft.AspNetCore.Mvc;

namespace ProductService.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private static readonly List<object> _products = new()
    {
        new { Id = 1, Name = "Laptop", Price = 999.99, Stock = 10 },
        new { Id = 2, Name = "Mouse", Price = 29.99, Stock = 50 },
        new { Id = 3, Name = "Teclado", Price = 49.99, Stock = 30 }
    };

    [HttpGet]
    public IActionResult GetAll() => Ok(_products);

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var product = _products.ElementAtOrDefault(id - 1);
        if (product is null) return NotFound(new { Message = $"Producto con id {id} no encontrado." });
        return Ok(product);
    }
}
