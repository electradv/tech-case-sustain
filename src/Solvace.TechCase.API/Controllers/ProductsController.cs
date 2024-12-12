using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Solvace.TechCase.API.Controllers;


[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    #region QUESTION 4
    // TYPE YOUR RESPONSE HERE: 
    // Simulando operação assíncrona
    // Retorna erros de validação se houver
    // Simulando operação assíncrona
    // Atribuindo um novo ID ao produto
    #endregion
    private readonly List<Product> _products;

    public ProductsController()
    {
        _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Description = "High performance laptop", Price = 1200.00 },
            new Product { Id = 2, Name = "Smartphone", Description = "Latest model smartphone", Price = 800.00 },
            new Product { Id = 3, Name = "Headphones", Description = "Noise-cancelling headphones", Price = 150.00 },
        };
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProductById(int id)
    {
        await Task.Delay(100); 

        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPost("create")]
    public async Task<ActionResult<Product>> Create([FromBody] Product product)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await Task.Delay(100); 

        
        product.Id = _products.Max(p => p.Id) + 1;
        _products.Add(product);

        return Created($"/api/products/{product.Id}", product);
    }
}

public class Product
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    public string Description { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
    public double Price { get; set; }
}


