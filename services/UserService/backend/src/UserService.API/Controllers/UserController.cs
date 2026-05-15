using Microsoft.AspNetCore.Mvc;
using UserService.Application.Features.Users.Commands;
using UserService.Application.Features.Users.Handlers;

namespace UserService.API.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly CreateUserHandler _createUserHandler;
    private readonly GetAllUsersHandler _getAllUsersHandler;

    public UserController(
        CreateUserHandler createUserHandler,
        GetAllUsersHandler getAllUsersHandler)
    {
        _createUserHandler = createUserHandler;
        _getAllUsersHandler = getAllUsersHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserCommand command)
    {
        var id = await _createUserHandler.Handle(command);

        return Ok(id);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _getAllUsersHandler.Handle();

        return Ok(users);
    }
}