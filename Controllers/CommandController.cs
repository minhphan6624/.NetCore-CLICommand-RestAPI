using System.Windows.Input;
using AutoMapper;
using CLICommandStorage.Data;
using CLICommandStorage.DTOs;
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
        private readonly IMapper _mapper;

        //Dependency Injection
        public CommandController(ICommandRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET /api/commands
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDTO>> GetAllCommands()
        {
            var commands = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDTO>>(commands));
        }

        // GET /api/commands/{id}
        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult <CommandReadDTO> GetCommandById(int id)
        {
            var command = _repository.GetCommandById(id);
             if (command != null)
            {
                return Ok(_mapper.Map<CommandReadDTO>(command));
            }
            return NotFound();
        }

        // POST /api/commands
        [HttpPost]
        public ActionResult <CommandReadDTO> CreateCommand(CommandCreateDTO commandCreateDTO)
        {
            //Map a command from a commandCreateDTO
            var commandModel = _mapper.Map<Command>(commandCreateDTO);

            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var commandReadDTO = _mapper.Map<CommandReadDTO>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new {Id = commandReadDTO.Id}, commandReadDTO);
            //Create a commandReadDTO from the commandModel to return to the client
        }

        // PUT /api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDTO commandUpdateDTO)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            
            // Map the commandUpdateDTO to the commandModelFromRepo 
            _mapper.Map(commandUpdateDTO, commandModelFromRepo);

            //Good practice to update the command in the repository to reflect the changes in the dbcontext
            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChanges(); //Flush the changes to the DB

            return NoContent();
        }
    }
}