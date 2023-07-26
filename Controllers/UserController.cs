using JsonFlatFileDataStore;
using Microsoft.AspNetCore.Mvc;

namespace test1.Controllers;

[ApiController]
[Route("[controller]")]

public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IDocumentCollection<User> _users;
    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;

        var store = new DataStore("db.json");
        _users = store.GetCollection<User>();
    }

    [HttpPost]
    public void Post([FromBody] User User)
    {
        _users.InsertOne(User);
    }

    [HttpGet]
    public IEnumerable<User> Get()
    {
        return _users.AsQueryable().ToList();
    }

}

public class User
{
    public string Name {get; set;}
}