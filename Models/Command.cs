using System.ComponentModel.DataAnnotations;

namespace CLICommandStorage.Models
{
    public class Command
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string CommandName { get; set; } = String.Empty;

        [Required]
        public string Description { get; set; } = String.Empty;

        [Required]
        public string Platform { get; set; } = String.Empty;
    }
}