using System.ComponentModel.DataAnnotations;

namespace CLICommandStorage.DTOs
{
    public class CommandCreateDTO
    {
        [Required]
        [MaxLength(250)]
        public string CommandName { get; set; } = String.Empty;

        [Required]
        public string Description { get; set; } = String.Empty;

        [Required]
        public string Platform { get; set; } = String.Empty;
    }
}