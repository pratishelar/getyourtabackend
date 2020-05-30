using System.ComponentModel.DataAnnotations;

namespace backend.Dtos
{
    public class UserforRegisterDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "password must be between 4 and 8 character")]
        public string Password { get; set; }
    }
}