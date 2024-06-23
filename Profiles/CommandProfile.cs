using AutoMapper;
using CLICommandStorage.DTOs;
using CLICommandStorage.Models;

namespace CLICommandStorage.Profiles
{
    public class CommandProfile : Profile
    {
        public CommandProfile()
        {
            //Map a Command to a CommandReadDTO for GET requests
            CreateMap<Command, CommandReadDTO>();

            //Map a CommandCreateDTO to a Command for POST requests
            CreateMap<CommandCreateDTO, Command>();
        }
    }
}
