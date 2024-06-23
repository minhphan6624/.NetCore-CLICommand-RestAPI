using System.ComponentModel.DataAnnotations;

namespace CLICommandStorage.DTOs
{
    public class CommandUpdateDTO
    {
        [Required]
        [MaxLength(250)]
        public string CommandName { get; set; } = String.Empty;

        [Required]
        public string Desctiption { get; set; } = String.Empty;
    }
}