using CLICommandStorage.Models;
using System.Collections.Generic;
using System.Linq;

namespace CLICommandStorage.Data
{
    public class MockCommandRepo
    {
        private readonly List<Command> _commands = new List<Command>
        {
            new Command{Id=0, CommandName="Example Command 1", Description="This is the first example command"},
            new Command{Id=1, CommandName="Example Command 2", Description="This is the second example command"},
            // Add more commands as needed
        };

        public IEnumerable<Command> GetAllCommands()
        {
            return _commands;
        }

        public Command GetCommandById(int id)
        {
            return _commands.FirstOrDefault(c => c.Id == id);
        }
    }
}