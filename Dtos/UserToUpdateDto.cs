using System;

namespace backend.Dtos
{
    public class UserToUpdateDto
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string OfficeName { get; set; }
        public string GradePay { get; set; }
        public string Office { get; set; }
    }
}