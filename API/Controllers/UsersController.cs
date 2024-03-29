using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Entities;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] // /api/users
public class UsersController : ControllerBase
{
    private readonly Data.DataContext _context;
    public UsersController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<AppUser>> GetUsers()
    {
        var users = _context.Users.ToList();
        return users;
    }

    [HttpGet("{id}")] // /api/users/3
    public ActionResult<AppUser> GetUser(int id)
    {
        var user = _context.Users.Find(id);
        return user;
    }
}