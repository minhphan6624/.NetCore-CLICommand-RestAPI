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
    
   public void DeleteCommand(Command cmd)
   {
       if (cmd == null)
       {
           throw new ArgumentNullException(nameof(cmd));
       }

       _context.Commands.Remove(cmd);
   }

    public bool SaveChanges()
    {
        return _context.SaveChanges() >=0 ;
    }
}