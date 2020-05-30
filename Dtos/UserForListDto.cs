using System;

namespace backend.Dtos
{
    public class UserForListDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string OfficeName { get; set; }
        public string GradePay { get; set; }
        public string Office { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string Url { get; set; }
     
        
    }
}