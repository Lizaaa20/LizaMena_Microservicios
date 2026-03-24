using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
    private static readonly List<object> _customers = new()
    {
        new { Id = 1, Name = "Carlos Lopez", Email = "carlos@email.com", Phone = "9999-0001" },
        new { Id = 2, Name = "Ana Martinez", Email = "ana@email.com", Phone = "9999-0002" },
        new { Id = 3, Name = "Luis Reyes", Email = "luis@email.com", Phone = "9999-0003" }
    };

    [HttpGet]
    public IActionResult GetAll() => Ok(_customers);

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var customer = _customers.ElementAtOrDefault(id - 1);
        if (customer is null) return NotFound(new { Message = $"Cliente con id {id} no encontrado." });
        return Ok(customer);
    }
}
