using Microsoft.AspNetCore.Mvc;
using APITaller1.src.Data;
using AutoMapper;
using APITaller1.src.Models;
using APITaller1.src.Dtos.User;
using APITaller1.src.Dtos;
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

    [HttpGet("{id}")] // /api/users/1
    public async Task<ActionResult<UserDto>> GetUser(int id)
    {
        var user = await _context.Users
            .Include(u => u.Role) // Muy importante para que se cargue Role
            .FirstOrDefaultAsync(u => u.Id == id);

        if (user == null)
        {
            return NotFound();
        }

        var userDto = _mapper.Map<UserDto>(user);

        return Ok(userDto);
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> CreateUser(CreateUserDto createUserDto)
    {
        var user = _mapper.Map<User>(createUserDto);

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    [HttpPut("{id}")] // /api/users/1
    public async Task<IActionResult> UpdateUser(int id, UpdateUserDto updateUserDto)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        _mapper.Map(updateUserDto, user);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")] // /api/users/1
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
