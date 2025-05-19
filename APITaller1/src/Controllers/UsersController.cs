using APITaller1.src.Data;
using APITaller1.src.Dtos;
using APITaller1.src.Dtos.User;
using APITaller1.src.Models;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly StoreContext _context;
    private readonly IMapper _mapper;

    public UsersController(StoreContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
    {
        var users = await _context.Users
            .Include(u => u.Role) // Muy importante para que se cargue Role
            .ToListAsync();

        var userDtos = _mapper.Map<List<UserDto>>(users);

        return Ok(userDtos);
    }
}
