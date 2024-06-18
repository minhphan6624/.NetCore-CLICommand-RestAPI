using CLICommandStorage.Data;
using CLICommandStorage.Models;
using Microsoft.AspNetCore.Mvc;

namespace CLICommandStorage.Controllers
{
    // api/commands
    [Route ("api/commands")]
    [ApiController]
    public class CommandController : ControllerBase 
    {
        private readonly ConcreteCommandRepo _repository = new ConcreteCommandRepo();

        // GET /api/commands
        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllCommands()
        {
            var commands = _repository.GetAllCommands();
            return Ok(commands);
        }

        // GET /api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult <IEnumerable<Command>> GetCommandById(int id)
        {
            var command = _repository.GetCommandById(id);
            return Ok(command);
        }
    }
}