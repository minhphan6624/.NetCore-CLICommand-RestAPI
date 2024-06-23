using CLICommandStorage.Data;
using CLICommandStorage.Models;

public class SqlCommandRepo : ICommandRepo
{
    private readonly AppDbContext _context;

    public SqlCommandRepo(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Command> GetAllCommands()
    {
        return _context.Commands.ToList();
    }

    public Command GetCommandById(int id)
    {
        return _context.Commands.FirstOrDefault(p => p.Id == id);
    }

    public void CreateCommand(Command cmd)
    {
        if (cmd == null)
        {
            throw new ArgumentNullException(nameof(cmd));
        }

        _context.Commands.Add(cmd);
    }

    public void UpdateCommand(Command cmd)
    {
        // Check if the command exists
        var existingCommand = _context.Commands.FirstOrDefault(p => p.Id == cmd.Id);
        if (existingCommand == null)
        {
            throw new ArgumentNullException(nameof(existingCommand));
        }
    }
    
    //     existingCommand.Property1 = cmd.Property1;
    //     existingCommand.Property2 = cmd.Property2;
        
    //     // Update other properties as needed
    //     _context.Commands.Update(existingCommand);
    // }

    // public void DeleteCommand(int id)
    // {
    //     var command = _context.Commands.FirstOrDefault(p => p.Id == id);
    //     if (command == null)
    //     {
    //         throw new ArgumentNullException(nameof(command));
    //     }

    //     _context.Commands.Remove(command);
    // }

    //Whene
    public bool SaveChanges()
    {
        return _context.SaveChanges() >=0 ;
    }
}