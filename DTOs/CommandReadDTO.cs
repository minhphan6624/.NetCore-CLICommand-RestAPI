namespace CLICommandStorage.DTOs
{
    public class CommandReadDTO
    {
        public int Id { get; set; }

        public string CommandName { get; set; } = String.Empty;

        public string Description { get; set; } = String.Empty;
    }
}