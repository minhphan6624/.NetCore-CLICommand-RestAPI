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
}