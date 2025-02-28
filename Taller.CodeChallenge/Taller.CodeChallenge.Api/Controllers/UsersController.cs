using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;
using Taller.CodeChallenge.Domain.AggregateModels.Request;
using Taller.CodeChallenge.Domain.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Taller_CodeChallenge.Controllers;

[ApiController]
public class UsersController : ControllerBase
{    

    private readonly ILogger<UsersController> _logger;
    private readonly IUsersAdapter _usersAdapter;

    public UsersController(ILogger<UsersController> logger, IUsersAdapter usersAdapter)
    {
        _logger = logger;
        _usersAdapter = usersAdapter;
    }

    /// <summary>
    /// Get the users by Name
    /// </summary>
    /// <param name="userName">Name of user</param>
    /// <param name="cancellationToken">Cancellation the request</param>
    /// <returns>Return the user found by the UserName</returns>
    [HttpGet]
    [Route("get-users-by-name")]
    public async Task<IActionResult> GetUsersByName(string userName, CancellationToken cancellationToken)
    {
        _logger.Log(LogLevel.Debug, $"Getting the Users by name {userName}");

        var users = await _usersAdapter.GetUsers(userName.ToLower(), cancellationToken);

        if (users is null)
            return NotFound();

        return Ok(users);
    }

    /// <summary>
    /// Insert a new user in a memory database
    /// </summary>
    /// <param name="userModel">Model that has the new user to insert</param>
    /// <param name="cancellationToken">Cancellation the request</param>
    /// <returns>Return the link of get a User with you ID</returns>
    [HttpPost]
    [Route("insert-user-inmemory-database")]
    public async Task<IActionResult> InsertUserInMemoryDatabase(UserModelToAdd userModel, CancellationToken cancellationToken)
    {
        _logger.Log(LogLevel.Debug, $"Adding the Users in a memory");

        var idUser = await _usersAdapter.AddUsers(userModel, cancellationToken);        

        if(!idUser.Equals(Guid.Empty))
            return Created($"getUsers/{idUser}", idUser);

        return BadRequest($"Error to create a new User");
    }

    /// <summary>
    /// Delete a new user in a memory Database
    /// </summary>
    /// <param name="idUser">Tge ID of the user to delete in a database</param>
    /// <param name="cancellationToken">Cancellation the request</param>
    /// <returns>True if deleted otherwise return false</returns>
    [HttpDelete]
    [Route("delete-user-inmemory-database")]
    public async Task<IActionResult> DeleteUserById(Guid idUser, CancellationToken cancellationToken)
    {
        _logger.Log(LogLevel.Debug, $"Deleting the Users by id {idUser}");

        var users = await _usersAdapter.DeleteUsersById(idUser, cancellationToken);

        if (!users)
            return BadRequest($"Error to delete a user with ID {idUser}");

        return Ok(users);
    }
}
