using System.Windows.Input;
using AutoMapper;
using CLICommandStorage.Data;
using CLICommandStorage.DTOs;
using CLICommandStorage.Models;
using Microsoft.AspNetCore.JsonPatch;
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

        //PATCH /api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUpdateCommand(int id, JsonPatchDocument<CommandUpdateDTO> patchDoc)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);

            //Check if the model is present
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            //Create a new CommandUpdateDTO with the content we get from the repo 
            var commandToPatch = _mapper.Map<CommandUpdateDTO>(commandModelFromRepo);

            //Apply the changes to the command, and check for the validity using ModelState
            patchDoc.ApplyTo(commandToPatch, ModelState);

            //Validation check
            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

             // Map the CommandToPatch to the commandModelFromRepo 
            _mapper.Map(commandToPatch, commandModelFromRepo);

            //Good practice to update the command in the repository to reflect the changes in the dbcontext
            _repository.UpdateCommand(commandModelFromRepo);

             _repository.SaveChanges(); //Flush the changes to the DB

             return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}