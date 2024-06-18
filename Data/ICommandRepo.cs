using CLICommandStorage.Models;

namespace CLICommandStorage.Data
{
    public interface ICommandRepo
    {
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
    }
}