using System.Linq;
using System.Threading.Tasks;
using Golmodoth.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Golmodoth.Api
{
    [ApiController, Route("api/users")]
    public class UserController : ControllerBase
    {
        public GolmodothContext SQL { get; }

        public UserController(GolmodothContext golmodothDb)
        {
            SQL = golmodothDb;
        }

        // GET: api/users
        [HttpGet]
        public IQueryable<object> GetUsers() => SQL.Users.Select(x => new { x.Id, x.Username, x.Email });

        // GET: api/users/id
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUser(int id)
        { 
            User user = await SQL.Users.FindAsync(id);
            
            if(user != null) return Ok(user);
            else return NotFound();
        }

        [HttpGet("{id:int}/characters")]
        public async Task<IActionResult> GetUserCharacters(int id)
        {
            IQueryable<Character> characters = SQL.Characters.Where(x => x.UserId == id);

            if (characters != null) return Ok(characters);
            else return NotFound();
        }

        // GET: api/users/username
        [HttpGet("{username}")]
        public async Task<IActionResult> GetUser(string username)
        {
            User user = SQL.Users.FirstOrDefault(x => x.Username == username);

            if (user != null) return Ok(user);
            else return NotFound();
        }
    }
}