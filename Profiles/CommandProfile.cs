using AutoMapper;
using CLICommandStorage.DTOs;
using CLICommandStorage.Models;

namespace CLICommandStorage.Profiles
{
    public class CommandProfile : Profile
    {
        public CommandProfile()
        {
            CreateMap<Command, CommandReadDTO>();
        }
    }
}
