using System.Windows.Input;
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
        private readonly ICommandRepo _repository;

        //Dependency Injection
        public CommandController(ICommandRepo repository)
        {
            _repository = repository;
        }

        // GET /api/commands
        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllCommands()
        {
            var commands = _repository.GetAllCommands();
            return Ok(commands);
        }

        // GET /api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            var command = _repository.GetCommandById(id);
             if (command != null)
            {
                return Ok(command);
            }
            return NotFound();
        }
    }
}