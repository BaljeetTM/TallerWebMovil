using Microsoft.AspNetCore.Mvc;
using APITaller1.src.Data;
using AutoMapper;
using APITaller1.src.Models;
using APITaller1.src.Dtos.Product;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly StoreContext _context;
    private readonly IMapper _mapper;

    public ProductsController(StoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductDto>>> GetProducts()
    {
        var products = await _context.Products.ToListAsync();
        var productsDto = _mapper.Map<List<ProductDto>>(products);
        return Ok(productsDto);
    }

    [HttpGet("{id}")] // /api/products/1
    public async Task<ActionResult<ProductDto>> GetProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        var productDto = _mapper.Map<ProductDto>(product);
        return Ok(productDto);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> CreateProduct(ProductCreateDto productCreateDto)
    {
        var product = _mapper.Map<Product>(productCreateDto);
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        var productDto = _mapper.Map<ProductDto>(product);
        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, productDto);
    }

    [HttpPut("{id}")] // /api/products/1
    public async Task<IActionResult> UpdateProduct(int id, ProductUpdateDto productUpdateDto)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        _mapper.Map(productUpdateDto, product);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")] // /api/products/1
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}