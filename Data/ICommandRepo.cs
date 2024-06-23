using CLICommandStorage.Models;

namespace CLICommandStorage.Data
{
    public interface ICommandRepo
    {
        IEnumerable<Command> GetAllCommands();// Get all commands
        Command GetCommandById(int id); //Get command by id
        void CreateCommand(Command cmd); // Create a command
        void UpdateCommand(Command cmd); // Update a command

        // //Delete a command
        // void DeleteCommand(int id);
        bool SaveChanges();// Save changes
    }
}