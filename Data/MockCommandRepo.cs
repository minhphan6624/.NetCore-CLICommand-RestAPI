using CLICommandStorage.Models;
using System.Collections.Generic;

namespace CLICommandStorage.Data
{
    public class ConcreteCommandRepo : ICommandRepo
    {
        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command{Id = 0, HowTo = "Boil an egg", Line = "Boil water", Description = "Boil water, add egg, cook for 5 minutes"},
                new Command{Id = 1, HowTo = "Fry an egg", Line = "Fry egg", Description = "Fry egg in pan, add salt and pepper"},
                new Command{Id = 2, HowTo = "Scramble an egg", Line = "Scramble egg", Description = "Scramble egg in bowl, add salt and pepper"}
            };
            
            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command{Id = 0, HowTo = "Boil an egg", Line = "Boil water", Description = "Boil water, add egg, cook for 5 minutes"};
        }
    }
}