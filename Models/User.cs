using System;
using System.Collections.Generic;

namespace backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string OfficeName { get; set; }
        public string GradePay { get; set; }
        public string Office { get; set; }
        public string Created { get; set; }
        public string LastActive { get; set; }
        public ICollection<Photo> Photos{ get; set; }
    }


}