using APITaller1.src.Dtos.Product;
using APITaller1.src.Interfaces;
using APITaller1.src.Models;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;

namespace APITaller1.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinary;

        public ProductsController(IUnitOfWork unitOfWork, IMapper mapper, ICloudinaryService cloudinary)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cloudinary = cloudinary;
        }

        [HttpPost]
        public async Task<ActionResult<ProductResponseDto>> CreateProduct([FromForm] ProductCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var product = _mapper.Map<Product>(dto);

            // Subir imágenes a Cloudinary
            if (dto.Images != null && dto.Images.Any())
            {
                product.Images = new List<ProductImage>();

                foreach (var file in dto.Images)
                {
                    var uploadResult = await _cloudinary.UploadImageAsync(file);
                    if (!string.IsNullOrEmpty(uploadResult))
                    {
                        product.Images.Add(new ProductImage
                        {
                            Url = uploadResult
                        });
                    }
                }
            }

            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.CompleteAsync();

            var productDto = _mapper.Map<ProductResponseDto>(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, productDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponseDto>> GetProductById(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null) return NotFound();

            return _mapper.Map<ProductResponseDto>(product);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponseDto>>> GetAllProducts()
        {
            var products = await _unitOfWork.Products.GetAllAsync();
            var productsDto = _mapper.Map<List<ProductResponseDto>>(products);
            return Ok(productsDto);
        }
    }
}