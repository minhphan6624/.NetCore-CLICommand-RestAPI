using CLICommandStorage.Models;

namespace CLICommandStorage.Data
{
    public interface ICommandRepo
    {
        // Get all commands
        IEnumerable<Command> GetAllCommands();

        //Get command by id
        Command GetCommandById(int id);
    }
}