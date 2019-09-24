using System.Linq;
using System.Threading.Tasks;
using Golmodoth.Shared;
using Microsoft.AspNetCore.Mvc;


namespace Golmodoth.Api
{
    [ApiController, Route("api/characters")]
    public class CharacterController : ControllerBase
    {
        public GolmodothContext SQL { get; }

        public CharacterController(GolmodothContext golmodothDb)
        {
            SQL = golmodothDb;
        }

        // GET: api/characters
        [HttpGet]
        public IQueryable<object> GetCharacters() => SQL.Characters;

        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            Character character = await SQL.Characters.FindAsync(id);

            if (character != null)
            {
                return Ok(character);
            }
            else
            {
                return NotFound();
            }
        }

        [Route("{name}")]
        public IActionResult Get(string name)
        {
            Character character = SQL.Characters.FirstOrDefault(x => x.Name == name);

            if (character != null)
            {
                return Ok(character);
            }
            {
                return NotFound();
            }
        }
    }
}
