namespace CLICommandStorage.Models
{
    public class Command
    {
        public int Id { get; set; }
        public string? HowTo { get; set; }

        public string? Line { get; set; }
        public string? Description { get; set; }
    }
}