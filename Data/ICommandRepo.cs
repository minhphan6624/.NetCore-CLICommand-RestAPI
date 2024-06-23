using CLICommandStorage.Models;

namespace CLICommandStorage.Data
{
    public interface ICommandRepo
    {
        // Get all commands
        IEnumerable<Command> GetAllCommands();

        //Get command by id
        Command GetCommandById(int id);

        // Create a command
        void CreateCommand(Command cmd);

        // Update a command
        // void UpdateCommand(Command cmd);

        // //Delete a command
        // void DeleteCommand(int id);

        // Save changes
        bool SaveChanges();
    }
}