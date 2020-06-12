using System;
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
        [Required]
        public string Gender { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        [Required]
        public string OfficeName { get; set; }
        [Required]
        public string GradePay { get; set; }
        [Required]
        public string Office { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }

        public UserforRegisterDto()
        {
            Created = DateTime.Now;
            LastActive = DateTime.Now;
        }
    }

}